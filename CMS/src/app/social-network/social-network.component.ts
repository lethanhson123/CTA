import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { CategoryLanguage } from 'src/app/shared/CategoryLanguage.model';
import { CategoryLanguageService } from 'src/app/shared/CategoryLanguage.service';
import { SocialNetwork } from 'src/app/shared/SocialNetwork.model';
import { SocialNetworkService } from 'src/app/shared/SocialNetwork.service';

@Component({
  selector: 'app-social-network',
  templateUrl: './social-network.component.html',
  styleUrls: ['./social-network.component.css']
})
export class SocialNetworkComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ParentID', 'Name','Code', 'SortOrder', 'Active', 'Save'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  parentID: number = environment.InitializationNumber;
  constructor(
    public SocialNetworkService: SocialNetworkService,
    public CategoryLanguageService: CategoryLanguageService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.onGetCategoryLanguageToListAsync();        
  }
  onGetCategoryLanguageToListAsync() {
    this.isShowLoading = true;
    this.CategoryLanguageService.GetByActiveToListAsync(true).subscribe(
      res => {
        this.CategoryLanguageService.list = (res as CategoryLanguage[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        if (this.CategoryLanguageService.list) {
          if (this.CategoryLanguageService.list.length > 0) {
            this.parentID=this.CategoryLanguageService.list[0].ID;
            this.onGetToList();
            this.isShowLoading = false;
          }
        }      
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }  
  onGetToList() {
    this.isShowLoading = true;
    this.SocialNetworkService.GetByParentIDAndEmptyToListAsync(this.parentID).subscribe(
      res => {
        this.SocialNetworkService.list = res as SocialNetwork[];
        this.dataSource = new MatTableDataSource(this.SocialNetworkService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
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
  onSave(element: SocialNetwork) {    
    this.SocialNetworkService.SaveAsync(element).subscribe(
      res => {        
        this.onSearch();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDelete(element: SocialNetwork) {
    if (confirm(environment.DeleteConfirm)) {
      this.SocialNetworkService.RemoveAsync(element.ID).subscribe(
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
    this.SocialNetworkService.SaveListAsync(this.SocialNetworkService.list).subscribe(
      res => {
        this.onSearch();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onChangeParentID($event) {
    this.onSearch();
  }
}