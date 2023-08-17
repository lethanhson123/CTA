import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
@Injectable({
    providedIn: 'root'
})
export class DownloadService {    
    aPIURL: string = environment.APIURL;
    controller: string = "Download";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {       
    }        
    InvoiceOutputByIDToHTML(ID: number) {
        let url = this.aPIURL + this.controller + '/InvoiceOutputByIDToHTML';
        const params = new HttpParams()
            .set('ID', JSON.stringify(ID))
        return this.httpClient.get(url, { params }).toPromise();
    }
    InvoiceInputByIDToHTML(ID: number) {
        let url = this.aPIURL + this.controller + '/InvoiceInputByIDToHTML';
        const params = new HttpParams()
            .set('ID', JSON.stringify(ID))
        return this.httpClient.get(url, { params }).toPromise();
    }
    InvoiceInputGetBySupplierIDAndDateTimeBeginAndDateTimeEndToHTMLAsync(supplierID: number, dateTimeBegin: Date, dateTimeEnd: Date) {
        let url = this.aPIURL + this.controller + '/InvoiceInputGetBySupplierIDAndDateTimeBeginAndDateTimeEndToHTMLAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('supplierID', JSON.stringify(supplierID));
        formUpload.append('dateTimeBegin', JSON.stringify(dateTimeBegin));
        formUpload.append('dateTimeEnd', JSON.stringify(dateTimeEnd));        
        return this.httpClient.post(url, formUpload);
    }
    InvoiceOutputGetByCustomerIDAndDateTimeBeginAndDateTimeEndToHTMLAsync(customerID: number, dateTimeBegin: Date, dateTimeEnd: Date) {
        let url = this.aPIURL + this.controller + '/InvoiceOutputGetByCustomerIDAndDateTimeBeginAndDateTimeEndToHTMLAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('customerID', JSON.stringify(customerID));
        formUpload.append('dateTimeBegin', JSON.stringify(dateTimeBegin));
        formUpload.append('dateTimeEnd', JSON.stringify(dateTimeEnd));        
        return this.httpClient.post(url, formUpload);
    }
}

