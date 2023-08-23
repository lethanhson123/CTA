import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { NewsFile } from 'src/app/shared/NewsFile.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class NewsFileService extends BaseService {
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "NewsFile";
    }    
}

