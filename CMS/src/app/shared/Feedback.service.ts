import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Feedback } from 'src/app/shared/Feedback.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class FeedbackService extends BaseService {
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Feedback";
    }    
}

