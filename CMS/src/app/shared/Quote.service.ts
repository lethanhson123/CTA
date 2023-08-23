import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Quote } from 'src/app/shared/Quote.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class QuoteService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Quote";
    }    
}
