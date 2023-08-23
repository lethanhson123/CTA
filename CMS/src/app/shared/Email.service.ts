import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Email } from 'src/app/shared/Email.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class EmailService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Email";
    }    
}
