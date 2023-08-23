import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ServiceFile } from 'src/app/shared/ServiceFile.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ServiceFileService extends BaseService {
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "ServiceFile";
    }    
}
