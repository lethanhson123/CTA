import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { About } from 'src/app/shared/About.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class AboutService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "About";
    }    
}
