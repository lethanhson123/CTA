import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { News } from 'src/app/shared/News.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class NewsService extends BaseService {
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "News";
    }    
}

