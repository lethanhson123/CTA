import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/Notification.service';
import { CategoryLanguage } from 'src/app/shared/CategoryLanguage.model';
import { CategoryLanguageService } from 'src/app/shared/CategoryLanguage.service';
import { About } from 'src/app/shared/About.model';
import { AboutService } from 'src/app/shared/About.service';

@Component({
  selector: 'app-about-detail',
  templateUrl: './about-detail.component.html',
  styleUrls: ['./about-detail.component.css']
})
export class AboutDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  isShowLoading: boolean = false;
  fileToUpload: any;
  fileToUpload0: File = null;
  constructor(
    public AboutService: AboutService,
    public CategoryLanguageService: CategoryLanguageService,
    public NotificationService: NotificationService,
    public dialogRef: MatDialogRef<AboutDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.ID = data["ID"] as number;
  }
  ngOnInit(): void {
    this.onGetCategoryLanguageToListAsync();
  }
  onClose() {
    this.dialogRef.close();
  }
  onGetCategoryLanguageToListAsync() {
    this.isShowLoading = true;
    this.CategoryLanguageService.GetByActiveToListAsync(true).subscribe(
      res => {
        this.CategoryLanguageService.list = (res as CategoryLanguage[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        if (this.CategoryLanguageService.list) {
          if (this.CategoryLanguageService.list.length > 0) {
            if (this.AboutService.formData) {
              if (this.AboutService.formData.ID == 0) {
                this.AboutService.formData.ParentID = this.CategoryLanguageService.list[0].ID;
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
  onSubmit(form: NgForm) {
    this.AboutService.SaveAndUploadFileAsync(form.value, this.fileToUpload).subscribe(
      res => {
        this.NotificationService.success(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  changeImage(files: FileList) {
    if (files) {
      this.fileToUpload = files;
      this.fileToUpload0 = files.item(0);
      var reader = new FileReader();
      reader.onload = (event: any) => {
        this.AboutService.formData.FileName = event.target.result;
      };
      reader.readAsDataURL(this.fileToUpload0);
    }
  }
}