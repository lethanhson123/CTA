import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Menu } from 'src/app/shared/Menu.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class MenuService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Menu";
    }    
}
