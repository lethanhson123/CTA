import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { CategoryLanguage } from 'src/app/shared/CategoryLanguage.model';
import { CategoryLanguageService } from 'src/app/shared/CategoryLanguage.service';
import { Service } from 'src/app/shared/Service.model';
import { ServiceService } from 'src/app/shared/Service.service';

@Component({
  selector: 'app-service',
  templateUrl: './service.component.html',
  styleUrls: ['./service.component.css']
})
export class ServiceComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['FileName', 'Name', 'SortOrder', 'IsHomePage', 'Active', 'Save'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  parentID: number = environment.InitializationNumber;
  detailURL: string = "/Service/Info";
  liveURL: string = environment.Website;
  constructor(
    public ServiceService: ServiceService,
    public CategoryLanguageService: CategoryLanguageService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
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
    this.ServiceService.GetByParentIDToListAsync(this.parentID).subscribe(
      res => {
        this.ServiceService.list = res as Service[];
        this.dataSource = new MatTableDataSource(this.ServiceService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
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
  onDelete(element: Service) {
    if (confirm(element.Name + ': ' + environment.DeleteConfirm)) {
      this.ServiceService.RemoveAsync(element.ID).subscribe(
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
}