import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Banner } from 'src/app/shared/Banner.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class BannerService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Banner";
    }    
}

