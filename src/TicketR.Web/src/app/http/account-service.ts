import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterModel } from '../models/account/registerModel';
import { Observable } from 'rxjs';


@Injectable({ providedIn: 'root' })
export class AccountService {

    private apiUrl = 'http://localhost:5000/api/account/';

    constructor(private http: HttpClient) { }

    register(registerModel: RegisterModel) {
        console.log(JSON.stringify(registerModel));
        let httpheaders = new HttpHeaders().set('Content-Type', 'application/json');
        return this.http.post(this.apiUrl + 'register', JSON.stringify(registerModel), { headers: httpheaders });

    }
}
