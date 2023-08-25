import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { CategoryLanguage } from 'src/app/shared/CategoryLanguage.model';
import { CategoryLanguageService } from 'src/app/shared/CategoryLanguage.service';
import { Membership } from 'src/app/shared/Membership.model';
import { MembershipService } from 'src/app/shared/Membership.service';

@Component({
  selector: 'app-membership',
  templateUrl: './membership.component.html',
  styleUrls: ['./membership.component.css']
})
export class MembershipComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['Name', 'Display', 'Code', 'Description', 'Active', 'Save'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public MembershipService: MembershipService,
    public CategoryLanguageService: CategoryLanguageService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.onGetCategoryLanguageToListAsync();
    this.onGetMembershipToListAsync();
    this.onGetToList();
  }
  onGetCategoryLanguageToListAsync() {
    this.isShowLoading = true;
    this.CategoryLanguageService.GetByActiveToListAsync(true).subscribe(
      res => {
        this.CategoryLanguageService.list = (res as CategoryLanguage[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.isShowLoading = false;       
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onGetMembershipToListAsync() {
    this.isShowLoading = true;
    this.MembershipService.GetByActiveToListAsync(true).subscribe(
      res => {
        this.MembershipService.listSearch = (res as Membership[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.isShowLoading = false;       
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onGetToList() {
    this.isShowLoading = true;
    this.MembershipService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.MembershipService.list = res as Membership[];
        this.dataSource = new MatTableDataSource(this.MembershipService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearch() {
    if (this.searchString.length > 0) {
      this.dataSource.filter = this.searchString.toLowerCase();
    }
    else {
      this.onGetToList();
    }
  }
  onSave(element: Membership) {    
    this.MembershipService.SaveAsync(element).subscribe(
      res => {
        this.onGetMembershipToListAsync();
        this.onSearch();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDelete(element: Membership) {
    if (confirm(environment.DeleteConfirm)) {
      this.MembershipService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearch();
          this.NotificationService.warn(environment.DeleteSuccess);
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
        }
      );
    }
  }
  onSaveList() {    
    this.MembershipService.SaveListAsync(this.MembershipService.list).subscribe(
      res => {
        this.onSearch();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
}