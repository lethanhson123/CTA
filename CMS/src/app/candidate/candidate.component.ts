import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { Career } from 'src/app/shared/Career.model';
import { CareerService } from 'src/app/shared/Career.service';
import { Candidate } from 'src/app/shared/Candidate.model';
import { CandidateService } from 'src/app/shared/Candidate.service';

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css']
})
export class CandidateComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  displayColumns: string[] = ['ParentID', 'Name', 'Code', 'Display', 'LastUpdatedDate', 'FileName', 'Save'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  parentID: number = environment.InitializationNumber;
  detailURL: string = "/Candidate/Info";
  constructor(
    public CandidateService: CandidateService,
    public CareerService: CareerService,
    public NotificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.onGetCareerToListAsync();
    this.onGetToList();
  }

  onGetCareerToListAsync() {
    this.isShowLoading = true;
    this.CareerService.GetByActiveToListAsync(true).subscribe(
      res => {
        this.CareerService.list = (res as Career[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.isShowLoading = false;      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onGetToList() {
    this.isShowLoading = true;
    this.CandidateService.GetAllToListAsync().subscribe(
      res => {
        this.CandidateService.list = res as Candidate[];
        this.dataSource = new MatTableDataSource(this.CandidateService.list.sort((a, b) => (a.LastUpdatedDate > b.LastUpdatedDate ? 1 : -1)));
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
  onDelete(element: Candidate) {
    if (confirm(element.Name + ': ' + environment.DeleteConfirm)) {
      this.CandidateService.RemoveAsync(element.ID).subscribe(
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
