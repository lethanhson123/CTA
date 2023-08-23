import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CategoryLanguage } from 'src/app/shared/CategoryLanguage.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class CategoryLanguageService extends BaseService {
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "CategoryLanguage";
    }    
}

