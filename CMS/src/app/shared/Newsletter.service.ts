import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Newsletter } from 'src/app/shared/Newsletter.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class NewsletterService extends BaseService {
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Newsletter";
    }    
}

