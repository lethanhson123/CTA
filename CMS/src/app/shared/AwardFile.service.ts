import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AwardFile } from 'src/app/shared/AwardFile.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class AwardFileService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "AwardFile";
    }   
    
}

