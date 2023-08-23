import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Career } from 'src/app/shared/Career.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class CareerService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Career";
    }    
}

