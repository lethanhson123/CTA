import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Award } from 'src/app/shared/Award.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class AwardService extends BaseService {
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Award";
    }    
}

