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
import { Ideas } from 'src/app/shared/Ideas.model';
import { IdeasService } from 'src/app/shared/Ideas.service';
import { IdeasFile } from 'src/app/shared/IdeasFile.model';
import { IdeasFileService } from 'src/app/shared/IdeasFile.service';
import { CategoryIdeas } from 'src/app/shared/CategoryIdeas.model';
import { CategoryIdeasService } from 'src/app/shared/CategoryIdeas.service';

@Component({
  selector: 'app-ideas-detail',
  templateUrl: './ideas-detail.component.html',
  styleUrls: ['./ideas-detail.component.css']
})
export class IdeasDetailComponent implements OnInit {

  dataSourceFile: MatTableDataSource<any>;
  displayColumnsFile: string[] = ['Note', 'FileName', 'Name', 'SortOrder', 'Save'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  isShowLoading: boolean = false;
  fileToUpload: any;
  fileToUpload0: File = null;
  fileToUpload001: any;
  detailURL: string = "/Ideas/Info";
  liveURL: string = environment.Website;
  constructor(
    public IdeasService: IdeasService,
    public IdeasFileService: IdeasFileService,
    public CategoryIdeasService: CategoryIdeasService,
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
        this.IdeasService.GetByIDAsync(ID).subscribe(
          res => {
            this.IdeasService.formData = res as Ideas;
            if (this.IdeasService.formData) {
              this.onGetCategoryLanguageToListAsync();
              this.onGetCategoryIdeasToListAsync();
              if (this.IdeasService.formData.ID > 0) {
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
            if (this.IdeasService.formData) {
              if (this.IdeasService.formData.ID == 0) {
                this.IdeasService.formData.ParentID = this.CategoryLanguageService.list[0].ID;
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
  onGetCategoryIdeasToListAsync() {
    this.isShowLoading = true;
    this.CategoryIdeasService.GetByActiveToListAsync(true).subscribe(
      res => {
        this.CategoryIdeasService.list = (res as CategoryIdeas[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        if (this.CategoryIdeasService.list) {
          if (this.CategoryIdeasService.list.length > 0) {
            if (this.IdeasService.formData) {
              if (this.IdeasService.formData.ID == 0) {
                this.IdeasService.formData.CategoryIdeasID = this.CategoryIdeasService.list[0].ID;
              }
            }

            for(let i=0;i<this.CategoryIdeasService.list.length;i++){
              if(this.CategoryIdeasService.list[i].CategoryID>0){
                this.CategoryIdeasService.list[i].Name = "..." + this.CategoryIdeasService.list[i].Name;
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
    this.IdeasFileService.GetByParentIDAndEmptyToListAsync(this.IdeasService.formData.ID).subscribe(
      res => {
        this.IdeasFileService.list = res as IdeasFile[];
        this.dataSourceFile = new MatTableDataSource(this.IdeasFileService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
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
    this.IdeasService.SaveAndUploadFileAsync(form.value, this.fileToUpload).subscribe(
      res => {
        if (form.value.ID > 0) {
          this.NotificationService.success(environment.SaveSuccess);
          this.isShowLoading = false;
        }
        else {
          this.IdeasService.formData = res as Ideas;
          let url = this.detailURL + "/" + this.IdeasService.formData.ID;
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
        this.IdeasService.formData.FileName = event.target.result;
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
    if (this.IdeasService.formData) {
      if (this.IdeasService.formData.ID > 0) {
        if (this.IdeasFileService.formData) {
          this.isShowLoading = true;
          this.IdeasFileService.formData.ParentID = this.IdeasService.formData.ID;
          this.IdeasFileService.formData.Name = this.IdeasService.formData.Name;
          this.IdeasFileService.SaveAndUploadFilesAsync(this.IdeasFileService.formData, this.fileToUpload001).subscribe(
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
  onSaveFile(element: IdeasFile) {
    if (this.IdeasService.formData) {
      if (this.IdeasService.formData.ID > 0) {
        if (element) {
          this.isShowLoading = true;
          element.ParentID = this.IdeasService.formData.ID;
          element.Name = this.IdeasService.formData.Name;
          this.IdeasFileService.SaveAsync(element).subscribe(
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
  onDeleteFile(element: IdeasFile) {
    if (confirm(element.FileName + ': ' + environment.DeleteConfirm)) {
      this.isShowLoading = true;
      this.IdeasFileService.RemoveAsync(element.ID).subscribe(
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