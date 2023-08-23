import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { IdeasFile } from 'src/app/shared/IdeasFile.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class IdeasFileService extends BaseService {
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "IdeasFile";
    }    
}
