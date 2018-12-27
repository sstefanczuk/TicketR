import { HttpClient, HttpHeaders, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterModel } from '../models/account/registerModel';
import { Observable } from 'rxjs';


@Injectable({ providedIn: 'root' })
export class AccountService {

    private apiUrl = 'http://localhost:5000/api/account/';

    constructor(private http: HttpClient) { }

    register(registerModel: RegisterModel): Observable<HttpResponse<any>> {
        let httpheaders = new HttpHeaders().set('Content-Type', 'application/json');
        return this.http.post(this.apiUrl + 'register', JSON.stringify(registerModel),
            { headers: httpheaders, observe: 'response' });

    }
}
