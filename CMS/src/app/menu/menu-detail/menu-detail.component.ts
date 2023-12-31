import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/Notification.service';
import { CategoryLanguage } from 'src/app/shared/CategoryLanguage.model';
import { CategoryLanguageService } from 'src/app/shared/CategoryLanguage.service';
import { Menu } from 'src/app/shared/Menu.model';
import { MenuService } from 'src/app/shared/Menu.service';

@Component({
  selector: 'app-menu-detail',
  templateUrl: './menu-detail.component.html',
  styleUrls: ['./menu-detail.component.css']
})
export class MenuDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  isShowLoading: boolean = false;
  fileToUpload: any;
  fileToUpload0: File = null;
  constructor(
    public MenuService: MenuService,
    public CategoryLanguageService: CategoryLanguageService,
    public NotificationService: NotificationService,
    public dialogRef: MatDialogRef<MenuDetailComponent>,
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
            if (this.MenuService.formData) {
              if (this.MenuService.formData.ID == 0) {
                this.MenuService.formData.ParentID = this.CategoryLanguageService.list[0].ID;
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
    this.MenuService.SaveAndUploadFileAsync(form.value, this.fileToUpload).subscribe(
      res => {
        this.NotificationService.success(environment.SaveSuccess);
        this.onClose();
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
        this.MenuService.formData.FileName = event.target.result;
      };
      reader.readAsDataURL(this.fileToUpload0);
    }
  }
  onCopy() {
    this.isShowLoading = true;
    this.MenuService.formData.ID = environment.InitializationNumber;
    this.MenuService.SaveAsync(this.MenuService.formData).subscribe(
      res => {
        this.NotificationService.success(environment.SaveSuccess);
        this.onClose();
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
}