import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CategoryIdeas } from 'src/app/shared/CategoryIdeas.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class CategoryIdeasService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "CategoryIdeas";
    }    
}


