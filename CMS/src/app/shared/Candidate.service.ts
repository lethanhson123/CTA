import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Candidate } from 'src/app/shared/Candidate.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class CandidateService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Candidate";
    }    
}


