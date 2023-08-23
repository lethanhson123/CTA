import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { SocialNetwork } from 'src/app/shared/SocialNetwork.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class SocialNetworkService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "SocialNetwork";
    }    
}
