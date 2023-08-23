import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Contact } from 'src/app/shared/Contact.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ContactService extends BaseService {
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Contact";
    }    
}

