import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterModel } from '../models/account/registerModel';


@Injectable({ providedIn: 'root' })
export class AccountService {

    private apiUrl = 'http://localhost:5000/api/';

    constructor(private http: HttpClient) { }

    register(registerModel: RegisterModel) {
        return this.http.post(this.apiUrl + 'account/register', JSON.stringify(registerModel))
            .subscribe(() => console.log("registration"));
    }
}
