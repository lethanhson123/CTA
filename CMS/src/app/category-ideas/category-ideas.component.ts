import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { CategoryLanguage } from 'src/app/shared/CategoryLanguage.model';
import { CategoryLanguageService } from 'src/app/shared/CategoryLanguage.service';
import { CategoryIdeas } from 'src/app/shared/CategoryIdeas.model';
import { CategoryIdeasService } from 'src/app/shared/CategoryIdeas.service';

@Component({
  selector: 'app-category-ideas',
  templateUrl: './category-ideas.component.html',
  styleUrls: ['./category-ideas.component.css']
})
export class CategoryIdeasComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ParentID', 'CategoryID', 'Name', 'Description', 'SortOrder', 'Save'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public CategoryIdeasService: CategoryIdeasService,
    public CategoryLanguageService: CategoryLanguageService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.onGetCategoryLanguageToListAsync();
    this.onGetCategoryIdeasToListAsync();
    this.onGetToList();
  }
  onGetCategoryLanguageToListAsync() {
    this.isShowLoading = true;
    this.CategoryLanguageService.GetByActiveToListAsync(true).subscribe(
      res => {
        this.CategoryLanguageService.list = (res as CategoryLanguage[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.isShowLoading = false;       
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
        this.CategoryIdeasService.listSearch = (res as CategoryIdeas[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.isShowLoading = false;       
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onGetToList() {
    this.isShowLoading = true;
    this.CategoryIdeasService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.CategoryIdeasService.list = res as CategoryIdeas[];
        this.dataSource = new MatTableDataSource(this.CategoryIdeasService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
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
  onSave(element: CategoryIdeas) {    
    this.CategoryIdeasService.SaveAsync(element).subscribe(
      res => {
        this.onGetCategoryIdeasToListAsync();
        this.onSearch();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDelete(element: CategoryIdeas) {
    if (confirm(environment.DeleteConfirm)) {
      this.CategoryIdeasService.RemoveAsync(element.ID).subscribe(
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