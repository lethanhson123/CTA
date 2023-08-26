import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Base } from 'src/app/shared/Base.model';
@Injectable({
    providedIn: 'root'
})
export class BaseService {
    list: Base[] | undefined;
    listSearch: Base[] | undefined;
    listSearch001: Base[] | undefined;
    formData!: Base;
    aPIURL: string = environment.APIURL;
    controller: string = "Base";
    constructor(public httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    SaveAndUploadFiles(formData: Base, fileToUpload: FileList) {
        let url = this.aPIURL + this.controller + '/SaveAndUploadFiles';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(formData));
        if (fileToUpload) {
            if (fileToUpload.length > 0) {
                for (var i = 0; i < fileToUpload.length; i++) {
                    formUpload.append('file[]', fileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload);
    }
    SaveAndUploadFilesAsync(formData: Base, fileToUpload: FileList) {
        let url = this.aPIURL + this.controller + '/SaveAndUploadFilesAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(formData));
        if (fileToUpload) {
            if (fileToUpload.length > 0) {
                for (var i = 0; i < fileToUpload.length; i++) {
                    formUpload.append('file[]', fileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload);
    }
    SaveAndUploadTwoFiles(formData: Base, fileToUpload0: File, fileToUpload1: File) {
        let url = this.aPIURL + this.controller + '/SaveAndUploadTwoFiles';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(formData));
        if (fileToUpload1 == null) {
            fileToUpload1 = new File(["fileToUpload1"], "fileToUpload1.txt", {
                type: "text/plain",
            });
        }
        if (fileToUpload0 == null) {
            fileToUpload0 = new File(["fileToUpload0"], "fileToUpload0.txt", {
                type: "text/plain",
            });
        }       
        formUpload.append('file', fileToUpload1, fileToUpload1.name);
        formUpload.append('file', fileToUpload0, fileToUpload0.name);       
        return this.httpClient.post(url, formUpload);
    }
    SaveAndUploadTwoFilesAsync(formData: Base, fileToUpload0: File, fileToUpload1: File) {
        let url = this.aPIURL + this.controller + '/SaveAndUploadTwoFilesAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(formData));        
        if (fileToUpload0 == null) {
            fileToUpload0 = new File(["fileToUpload0"], "fileToUpload0.txt", {
                type: "text/plain",
            });
        }       
        if (fileToUpload1 == null) {
            fileToUpload1 = new File(["fileToUpload1"], "fileToUpload1.txt", {
                type: "text/plain",
            });
        }
        formUpload.append('file', fileToUpload0, fileToUpload0.name);      
        formUpload.append('file', fileToUpload1, fileToUpload1.name);
        return this.httpClient.post(url, formUpload);
    }
    SaveAndUploadFile(formData: Base, fileToUpload: FileList) {
        let url = this.aPIURL + this.controller + '/SaveAndUploadFile';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(formData));
        if (fileToUpload) {
            if (fileToUpload.length > 0) {
                for (var i = 0; i < fileToUpload.length; i++) {
                    formUpload.append('file[]', fileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload);
    }
    SaveAndUploadFileAsync(formData: Base, fileToUpload: FileList) {
        let url = this.aPIURL + this.controller + '/SaveAndUploadFileAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(formData));
        if (fileToUpload) {
            if (fileToUpload.length > 0) {
                for (var i = 0; i < fileToUpload.length; i++) {
                    formUpload.append('file[]', fileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload);
    }
    SaveList(list: Base[]) {
        let url = this.aPIURL + this.controller + '/SaveList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(list));
        return this.httpClient.post(url, formUpload);
    }
    SaveListAsync(list: Base[]) {
        let url = this.aPIURL + this.controller + '/SaveListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(list));
        return this.httpClient.post(url, formUpload);
    }
    Save(formData: Base) {
        let url = this.aPIURL + this.controller + '/Save';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(formData));
        return this.httpClient.post(url, formUpload);
    }
    SaveAsync(formData: Base) {
        let url = this.aPIURL + this.controller + '/SaveAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(formData));
        return this.httpClient.post(url, formUpload);
    }
    Remove(ID: number) {
        let url = this.aPIURL + this.controller + '/Remove';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(ID));
        return this.httpClient.post(url, formUpload);
    }
    RemoveAsync(ID: number) {
        let url = this.aPIURL + this.controller + '/RemoveAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(ID));
        return this.httpClient.post(url, formUpload);
    }
    GetByID(ID: number) {
        let url = this.aPIURL + this.controller + '/GetByID';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(ID));
        return this.httpClient.post(url, formUpload);
    }
    GetByIDAsync(ID: number) {
        let url = this.aPIURL + this.controller + '/GetByIDAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(ID));
        return this.httpClient.post(url, formUpload);
    }
    GetAllToList() {
        let url = this.aPIURL + this.controller + '/GetAllToList';
        const formUpload: FormData = new FormData();
        return this.httpClient.post(url, formUpload);
    }
    GetAllToListAsync() {
        let url = this.aPIURL + this.controller + '/GetAllToListAsync';
        const formUpload: FormData = new FormData();
        return this.httpClient.post(url, formUpload);
    }
    GetAllAndEmptyToList() {
        let url = this.aPIURL + this.controller + '/GetAllAndEmptyToList';
        const formUpload: FormData = new FormData();
        return this.httpClient.post(url, formUpload);
    }
    GetAllAndEmptyToListAsync() {
        let url = this.aPIURL + this.controller + '/GetAllAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        return this.httpClient.post(url, formUpload);
    }
    GetByActiveToList(active: boolean) {
        let url = this.aPIURL + this.controller + '/GetByActiveToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(active));
        return this.httpClient.post(url, formUpload);
    }
    GetByActiveToListAsync(active: boolean) {
        let url = this.aPIURL + this.controller + '/GetByActiveToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(active));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDToList(parentID: number) {
        if (parentID == 0) {
            return this.GetAllToList();
        }
        else {
            let url = this.aPIURL + this.controller + '/GetByParentIDToList';
            const formUpload: FormData = new FormData();
            formUpload.append('data', JSON.stringify(parentID));
            return this.httpClient.post(url, formUpload);
        }
    }
    GetByParentIDToListAsync(parentID: number) {
        if (parentID == 0) {
            return this.GetAllToListAsync();
        }
        else {
            let url = this.aPIURL + this.controller + '/GetByParentIDToListAsync';
            const formUpload: FormData = new FormData();
            formUpload.append('data', JSON.stringify(parentID));
            return this.httpClient.post(url, formUpload);
        }
    }
    GetByParentIDAndEmptyToList(parentID: number) {
        if (parentID == 0) {
            return this.GetAllAndEmptyToList();
        }
        else {
            let url = this.aPIURL + this.controller + '/GetByParentIDAndEmptyToList';
            const formUpload: FormData = new FormData();
            formUpload.append('data', JSON.stringify(parentID));
            return this.httpClient.post(url, formUpload);
        }
    }
    GetByParentIDAndEmptyToListAsync(parentID: number) {
        if (parentID == 0) {
            return this.GetAllAndEmptyToListAsync();
        }
        else {
            let url = this.aPIURL + this.controller + '/GetByParentIDAndEmptyToListAsync';
            const formUpload: FormData = new FormData();
            formUpload.append('data', JSON.stringify(parentID));
            return this.httpClient.post(url, formUpload);
        }
    }
    GetByParentIDAndActiveToList(parentID: number, active: boolean) {
        if (parentID == 0) {
            return this.GetByActiveToList(active);
        }
        else {
            let url = this.aPIURL + this.controller + '/GetByParentIDAndActiveToList';
            const formUpload: FormData = new FormData();
            formUpload.append('parentID', JSON.stringify(parentID));
            formUpload.append('active', JSON.stringify(active));
            return this.httpClient.post(url, formUpload);

        }
    }
    GetByParentIDAndActiveToListAsync(parentID: number, active: boolean) {        
        if (parentID == 0) {
            return this.GetByActiveToListAsync(active);
        }
        else {
            let url = this.aPIURL + this.controller + '/GetByParentIDAndActiveToListAsync';
            const formUpload: FormData = new FormData();
            formUpload.append('parentID', JSON.stringify(parentID));
            formUpload.append('active', JSON.stringify(active));
            return this.httpClient.post(url, formUpload);
        }
    }
    GetByPageAndPageSizeToList(page: number, pageSize: number) {
        let url = this.aPIURL + this.controller + '/GetByPageAndPageSizeToList';
        const formUpload: FormData = new FormData();
        formUpload.append('page', JSON.stringify(page));
        formUpload.append('pageSize', JSON.stringify(pageSize));
        return this.httpClient.post(url, formUpload);
    }
    GetByPageAndPageSizeToListAsync(page: number, pageSize: number) {
        let url = this.aPIURL + this.controller + '/GetByPageAndPageSizeToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('page', JSON.stringify(page));
        formUpload.append('pageSize', JSON.stringify(pageSize));
        return this.httpClient.post(url, formUpload);
    }
}

