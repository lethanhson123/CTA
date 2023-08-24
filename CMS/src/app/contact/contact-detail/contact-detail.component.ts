import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/Notification.service';
import { CategoryLanguage } from 'src/app/shared/CategoryLanguage.model';
import { CategoryLanguageService } from 'src/app/shared/CategoryLanguage.service';
import { Contact } from 'src/app/shared/Contact.model';
import { ContactService } from 'src/app/shared/Contact.service';

@Component({
  selector: 'app-contact-detail',
  templateUrl: './contact-detail.component.html',
  styleUrls: ['./contact-detail.component.css']
})
export class ContactDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  isShowLoading: boolean = false;
  constructor(
    public ContactService: ContactService,
    public CategoryLanguageService: CategoryLanguageService,
    public NotificationService: NotificationService,
    public dialogRef: MatDialogRef<ContactDetailComponent>,
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
            if (this.ContactService.formData) {
              if (this.ContactService.formData.ID == 0) {
                this.ContactService.formData.ParentID = this.CategoryLanguageService.list[0].ID;
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
    this.ContactService.SaveAsync(form.value).subscribe(
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