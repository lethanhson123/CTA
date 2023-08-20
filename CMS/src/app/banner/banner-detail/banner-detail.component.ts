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
import { Banner } from 'src/app/shared/Banner.model';
import { BannerService } from 'src/app/shared/Banner.service';
import { BannerFile } from 'src/app/shared/BannerFile.model';
import { BannerFileService } from 'src/app/shared/BannerFile.service';

@Component({
  selector: 'app-banner-detail',
  templateUrl: './banner-detail.component.html',
  styleUrls: ['./banner-detail.component.css']
})
export class BannerDetailComponent implements OnInit {

  dataSourceFile: MatTableDataSource<any>;
  displayColumnsFile: string[] = ['Note', 'FileName', 'Name', 'SortOrder', 'Save'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  isShowLoading: boolean = false;
  fileToUpload: any;
  fileToUpload0: File = null;
  fileToUpload001: any;
  detailURL: string = "/Banner/Info";
  liveURL: string = environment.Website;
  constructor(
    public BannerService: BannerService,
    public BannerFileService: BannerFileService,
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
        this.BannerService.GetByIDAsync(ID).subscribe(
          res => {
            this.BannerService.formData = res as Banner;
            if (this.BannerService.formData) {
              this.onGetCategoryLanguageToListAsync();
              if (this.BannerService.formData.ID > 0) {
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
            if (this.BannerService.formData) {
              if (this.BannerService.formData.ID == 0) {
                this.BannerService.formData.ParentID = this.CategoryLanguageService.list[0].ID;
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
    this.BannerFileService.GetByParentIDAndEmptyToListAsync(this.BannerService.formData.ID).subscribe(
      res => {
        this.BannerFileService.list = res as BannerFile[];
        this.dataSourceFile = new MatTableDataSource(this.BannerFileService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
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
    this.BannerService.SaveAndUploadFileAsync(form.value, this.fileToUpload).subscribe(
      res => {
        if (form.value.ID > 0) {
          this.NotificationService.success(environment.SaveSuccess);
          this.isShowLoading = false;
        }
        else {
          this.BannerService.formData = res as Banner;
          let url = this.detailURL + "/" + this.BannerService.formData.ID;
          this.router.navigateByUrl(url);
        }
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
        this.BannerService.formData.FileName = event.target.result;
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
    if (this.BannerService.formData) {
      if (this.BannerService.formData.ID > 0) {
        if (this.BannerFileService.formData) {
          this.isShowLoading = true;
          this.BannerFileService.formData.ParentID = this.BannerService.formData.ID;
          this.BannerFileService.formData.Name = this.BannerService.formData.Name;
          this.BannerFileService.SaveAndUploadFilesAsync(this.BannerFileService.formData, this.fileToUpload001).subscribe(
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
  onSaveFile(element: BannerFile) {
    if (this.BannerService.formData) {
      if (this.BannerService.formData.ID > 0) {
        if (element) {
          this.isShowLoading = true;
          element.ParentID = this.BannerService.formData.ID;
          element.Name = this.BannerService.formData.Name;
          this.BannerFileService.SaveAsync(element).subscribe(
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
  onDeleteFile(element: BannerFile) {
    if (confirm(element.FileName + ': ' + environment.DeleteConfirm)) {
      this.isShowLoading = true;
      this.BannerFileService.RemoveAsync(element.ID).subscribe(
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