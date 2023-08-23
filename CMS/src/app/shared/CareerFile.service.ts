import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CareerFile } from 'src/app/shared/CareerFile.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class CareerFileService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "CareerFile";
    }    
}

