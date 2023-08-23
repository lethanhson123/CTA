import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Ideas } from 'src/app/shared/Ideas.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class IdeasService extends BaseService {
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Ideas";
    }    
}

