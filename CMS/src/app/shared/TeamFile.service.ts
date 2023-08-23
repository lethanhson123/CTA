import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { TeamFile } from 'src/app/shared/TeamFile.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class TeamFileService extends BaseService {
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "TeamFile";
    }    
}

