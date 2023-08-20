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
import { Team } from 'src/app/shared/Team.model';
import { TeamService} from 'src/app/shared/Team.service';
import { TeamFile } from 'src/app/shared/TeamFile.model';
import { TeamFileService } from 'src/app/shared/TeamFile.service';

@Component({
  selector: 'app-team-detail',
  templateUrl: './team-detail.component.html',
  styleUrls: ['./team-detail.component.css']
})
export class TeamDetailComponent implements OnInit {

  dataSourceFile: MatTableDataSource<any>;
  displayColumnsFile: string[] = ['Note', 'FileName', 'Name', 'SortOrder', 'Save'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  isShowLoading: boolean = false;
  fileToUpload: any;
  fileToUpload0: File = null;
  fileToUpload001: any;
  detailURL: string = "/Team/Info";
  liveURL: string = environment.Website;
  constructor(
    public TeamService: TeamService,
    public TeamFileService: TeamFileService,
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
        this.TeamService.GetByIDAsync(ID).subscribe(
          res => {
            this.TeamService.formData = res as Team;
            if (this.TeamService.formData) {
              this.onGetCategoryLanguageToListAsync();
              if (this.TeamService.formData.ID > 0) {
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
            if (this.TeamService.formData) {
              if (this.TeamService.formData.ID == 0) {
                this.TeamService.formData.ParentID = this.CategoryLanguageService.list[0].ID;
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
    this.TeamFileService.GetByParentIDAndEmptyToListAsync(this.TeamService.formData.ID).subscribe(
      res => {
        this.TeamFileService.list = res as TeamFile[];
        this.dataSourceFile = new MatTableDataSource(this.TeamFileService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
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
    this.TeamService.SaveAndUploadFileAsync(form.value, this.fileToUpload).subscribe(
      res => {
        if (form.value.ID > 0) {
          this.NotificationService.success(environment.SaveSuccess);
          this.isShowLoading = false;
        }
        else {
          this.TeamService.formData = res as Team;
          let url = this.detailURL + "/" + this.TeamService.formData.ID;
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
    this.TeamService.formData.ID = environment.InitializationNumber;
    this.TeamService.SaveAsync(this.TeamService.formData).subscribe(
      res => {
        this.TeamService.formData = res as Team;
        let url = this.detailURL + "/" + this.TeamService.formData.ID;
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
        this.TeamService.formData.FileName = event.target.result;
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
    if (this.TeamService.formData) {
      if (this.TeamService.formData.ID > 0) {
        if (this.TeamFileService.formData) {
          this.isShowLoading = true;
          this.TeamFileService.formData.ParentID = this.TeamService.formData.ID;
          this.TeamFileService.formData.Name = this.TeamService.formData.Name;
          this.TeamFileService.SaveAndUploadFilesAsync(this.TeamFileService.formData, this.fileToUpload001).subscribe(
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
  onSaveFile(element: TeamFile) {
    if (this.TeamService.formData) {
      if (this.TeamService.formData.ID > 0) {
        if (element) {
          this.isShowLoading = true;
          element.ParentID = this.TeamService.formData.ID;
          element.Name = this.TeamService.formData.Name;
          this.TeamFileService.SaveAsync(element).subscribe(
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
  onDeleteFile(element: TeamFile) {
    if (confirm(element.FileName + ': ' + environment.DeleteConfirm)) {
      this.isShowLoading = true;
      this.TeamFileService.RemoveAsync(element.ID).subscribe(
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