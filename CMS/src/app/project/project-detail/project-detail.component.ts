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
import { Project } from 'src/app/shared/Project.model';
import { ProjectService } from 'src/app/shared/Project.service';
import { ProjectFile } from 'src/app/shared/ProjectFile.model';
import { ProjectFileService } from 'src/app/shared/ProjectFile.service';

@Component({
  selector: 'app-project-detail',
  templateUrl: './project-detail.component.html',
  styleUrls: ['./project-detail.component.css']
})
export class ProjectDetailComponent implements OnInit {

  dataSourceFile: MatTableDataSource<any>;
  displayColumnsFile: string[] = ['Note', 'FileName', 'Name', 'SortOrder', 'Save'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  isShowLoading: boolean = false;
  fileToUpload: any;
  fileToUpload0: File = null;
  fileToUpload001: any;
  detailURL: string = "/Project/Info";
  liveURL: string = environment.Website;
  constructor(
    public ProjectService: ProjectService,
    public ProjectFileService: ProjectFileService,
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
        this.ProjectService.GetByIDAsync(ID).subscribe(
          res => {
            this.ProjectService.formData = res as Project;
            if (this.ProjectService.formData) {
              this.onGetCategoryLanguageToListAsync();
              if (this.ProjectService.formData.ID > 0) {
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
            if (this.ProjectService.formData) {
              if (this.ProjectService.formData.ID == 0) {
                this.ProjectService.formData.ParentID = this.CategoryLanguageService.list[0].ID;
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
    this.ProjectFileService.GetByParentIDAndEmptyToListAsync(this.ProjectService.formData.ID).subscribe(
      res => {
        this.ProjectFileService.list = res as ProjectFile[];
        this.dataSourceFile = new MatTableDataSource(this.ProjectFileService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
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
    this.ProjectService.SaveAndUploadFileAsync(form.value, this.fileToUpload).subscribe(
      res => {
        if (form.value.ID > 0) {
          this.NotificationService.success(environment.SaveSuccess);
          this.isShowLoading = false;
        }
        else {
          this.ProjectService.formData = res as Project;
          let url = this.detailURL + "/" + this.ProjectService.formData.ID;
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
    this.ProjectService.formData.ID = environment.InitializationNumber;
    this.ProjectService.SaveAsync(this.ProjectService.formData).subscribe(
      res => {
        this.ProjectService.formData = res as Project;
        let url = this.detailURL + "/" + this.ProjectService.formData.ID;
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
        this.ProjectService.formData.FileName = event.target.result;
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
    if (this.ProjectService.formData) {
      if (this.ProjectService.formData.ID > 0) {
        if (this.ProjectFileService.formData) {
          this.isShowLoading = true;
          this.ProjectFileService.formData.ParentID = this.ProjectService.formData.ID;
          this.ProjectFileService.formData.Name = this.ProjectService.formData.Name;
          this.ProjectFileService.SaveAndUploadFilesAsync(this.ProjectFileService.formData, this.fileToUpload001).subscribe(
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
  onSaveFile(element: ProjectFile) {
    if (this.ProjectService.formData) {
      if (this.ProjectService.formData.ID > 0) {
        if (element) {
          this.isShowLoading = true;
          element.ParentID = this.ProjectService.formData.ID;
          element.Name = this.ProjectService.formData.Name;
          this.ProjectFileService.SaveAsync(element).subscribe(
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
  onDeleteFile(element: ProjectFile) {
    if (confirm(element.FileName + ': ' + environment.DeleteConfirm)) {
      this.isShowLoading = true;
      this.ProjectFileService.RemoveAsync(element.ID).subscribe(
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