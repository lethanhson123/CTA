import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ProjectFile } from 'src/app/shared/ProjectFile.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class ProjectFileService extends BaseService {
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "ProjectFile";
    }    
}

