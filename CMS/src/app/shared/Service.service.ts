import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Service } from 'src/app/shared/Service.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ServiceService extends BaseService {
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Service";
    }    
}
