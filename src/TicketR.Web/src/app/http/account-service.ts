import { HttpClient, HttpHeaders, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterModel } from '../models/account/registerModel';
import { Observable } from 'rxjs';
import { LoginModel } from '../models/account/loginModel';


@Injectable({ providedIn: 'root' })
export class AccountService {

    private apiUrl = 'http://localhost:5000/api/account/';

    constructor(private http: HttpClient) { }
    private httpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

    register(registerModel: RegisterModel): Observable<HttpResponse<any>> {
        return this.http.post(this.apiUrl + 'register', JSON.stringify(registerModel),
            { headers: this.httpHeaders, observe: 'response' });
    }

    login(loginModel: LoginModel): Observable<HttpResponse<any>> {
        console.log(loginModel);
        return this.http.post(this.apiUrl + 'login', JSON.stringify(loginModel),
            { headers: this.httpHeaders, observe: 'response' });
    }
}
