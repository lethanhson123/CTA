import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AboutFile } from 'src/app/shared/AboutFile.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class AboutFileService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "AboutFile";
    }    
}
