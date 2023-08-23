import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Team } from 'src/app/shared/Team.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class TeamService extends BaseService {
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Team";
    }    
}

