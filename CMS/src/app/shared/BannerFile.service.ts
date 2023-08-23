import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BannerFile } from 'src/app/shared/BannerFile.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class BannerFileService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "BannerFile";
    }    
}

