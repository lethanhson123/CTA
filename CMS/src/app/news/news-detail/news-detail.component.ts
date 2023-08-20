import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, NavigationEnd } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { CategoryLanguage } from 'src/app/shared/CategoryLanguage.model';
import { CategoryLanguageService } from 'src/app/shared/CategoryLanguage.service';
import { News } from 'src/app/shared/News.model';
import { NewsService } from 'src/app/shared/News.service';
import { NewsFile } from 'src/app/shared/NewsFile.model';
import { NewsFileService } from 'src/app/shared/NewsFile.service';

@Component({
  selector: 'app-news-detail',
  templateUrl: './news-detail.component.html',
  styleUrls: ['./news-detail.component.css']
})
export class NewsDetailComponent implements OnInit {

  dataSourceFile: MatTableDataSource<any>;
  displayColumnsFile: string[] = ['Note', 'FileName', 'Name', 'SortOrder', 'Save'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  isShowLoading: boolean = false;
  fileToUpload: any;
  fileToUpload0: File = null;
  fileToUpload001: any;
  detailURL: string = "/News/Info";
  liveURL: string = environment.Website;
  constructor(
    public NewsService: NewsService,
    public NewsFileService: NewsFileService,
    public CategoryLanguageService: CategoryLanguageService,
    public NotificationService: NotificationService,
    private router: Router
  ) {
    this.getByIDQueryString();
  }
  ngOnInit(): void {

  }
  getByIDQueryString() {
    this.isShowLoading = true;
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        let IDString = event.url;
        IDString = IDString.split('/')[IDString.split('/').length - 1];
        let ID = parseInt(IDString);
        this.NewsService.GetByIDAsync(ID).subscribe(
          res => {
            this.NewsService.formData = res as News;
            if (this.NewsService.formData) {
              this.onGetCategoryLanguageToListAsync();
              if (this.NewsService.formData.ID > 0) {
                this.onGetFileToList();
              }
            }
            this.isShowLoading = false;
          },
          err => {
            this.isShowLoading = false;
          }
        );
      }
    });
  }
  onGetCategoryLanguageToListAsync() {
    this.isShowLoading = true;
    this.CategoryLanguageService.GetByActiveToListAsync(true).subscribe(
      res => {
        this.CategoryLanguageService.list = (res as CategoryLanguage[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        if (this.CategoryLanguageService.list) {
          if (this.CategoryLanguageService.list.length > 0) {
            if (this.NewsService.formData) {
              if (this.NewsService.formData.ID == 0) {
                this.NewsService.formData.ParentID = this.CategoryLanguageService.list[0].ID;
              }
            }
            this.isShowLoading = false;
          }
        }
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onGetFileToList() {
    this.isShowLoading = true;
    this.NewsFileService.GetByParentIDAndEmptyToListAsync(this.NewsService.formData.ID).subscribe(
      res => {
        this.NewsFileService.list = res as NewsFile[];
        this.dataSourceFile = new MatTableDataSource(this.NewsFileService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
        this.dataSourceFile.sort = this.sort;
        this.dataSourceFile.paginator = this.paginator;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSubmit(form: NgForm) {
    this.isShowLoading = true;
    this.NewsService.SaveAndUploadFileAsync(form.value, this.fileToUpload).subscribe(
      res => {
        if (form.value.ID > 0) {
          this.NotificationService.success(environment.SaveSuccess);
          this.isShowLoading = false;
        }
        else {
          this.NewsService.formData = res as News;
          let url = this.detailURL + "/" + this.NewsService.formData.ID;
          this.router.navigateByUrl(url);
        }
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }
    );
  }
  onCopy() {
    this.isShowLoading = true;
    this.NewsService.formData.ID = environment.InitializationNumber;
    this.NewsService.SaveAsync(this.NewsService.formData).subscribe(
      res => {
        this.NewsService.formData = res as News;
        let url = this.detailURL + "/" + this.NewsService.formData.ID;
        this.router.navigateByUrl(url);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }
    );
  }
  changeImage(files: FileList) {
    if (files) {
      this.fileToUpload = files;
      this.fileToUpload0 = files.item(0);
      var reader = new FileReader();
      reader.onload = (event: any) => {
        this.NewsService.formData.FileName = event.target.result;
      };
      reader.readAsDataURL(this.fileToUpload0);
    }
  }
  changeFiles(files: FileList) {
    if (files) {
      this.fileToUpload001 = files;
    }
  }
  onAddFiles() {
    if (this.NewsService.formData) {
      if (this.NewsService.formData.ID > 0) {
        if (this.NewsFileService.formData) {
          this.isShowLoading = true;
          this.NewsFileService.formData.ParentID = this.NewsService.formData.ID;
          this.NewsFileService.formData.Name = this.NewsService.formData.Name;
          this.NewsFileService.SaveAndUploadFilesAsync(this.NewsFileService.formData, this.fileToUpload001).subscribe(
            res => {
              this.onGetFileToList();
              this.NotificationService.success(environment.SaveSuccess);
              this.isShowLoading = false;
            },
            err => {
              this.NotificationService.warn(environment.SaveNotSuccess);
              this.isShowLoading = false;
            }
          );
        }
      }
    }
  }
  onSaveFile(element: NewsFile) {
    if (this.NewsService.formData) {
      if (this.NewsService.formData.ID > 0) {
        if (element) {
          this.isShowLoading = true;
          element.ParentID = this.NewsService.formData.ID;
          element.Name = this.NewsService.formData.Name;
          this.NewsFileService.SaveAsync(element).subscribe(
            res => {
              this.onGetFileToList();
              this.NotificationService.warn(environment.SaveSuccess);
              this.isShowLoading = false;
            },
            err => {
              this.NotificationService.warn(environment.SaveNotSuccess);
              this.isShowLoading = false;
            }
          );
        }
      }
    }
  }
  onDeleteFile(element: NewsFile) {
    if (confirm(element.FileName + ': ' + environment.DeleteConfirm)) {
      this.isShowLoading = true;
      this.NewsFileService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onGetFileToList();
          this.NotificationService.warn(environment.DeleteSuccess);
          this.isShowLoading = false;
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
          this.isShowLoading = false;
        }
      );
    }
  }
}