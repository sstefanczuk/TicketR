import { HttpClient, HttpHeaders, HttpParams, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterModel } from '../models/account/registerModel';
import { LoginModel } from '../models/account/loginModel';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { AuthModel } from '../models/account/AuthModel';
import { Roles } from '../models/account/roleEnum';

export const TOKEN_NAME = 'jwt_token';
export const EXPIRY = 'expiry';
export const USER_ROLE = 'user_role';
export const AUTH_TIMESTAMP = 'auth_timestamp';

@Injectable({ providedIn: 'root' })
export class AccountService {

    private apiUrl = 'http://localhost:5000/api/account/';

    constructor(private http: HttpClient) { }
    private httpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

    register(registerModel: RegisterModel): Observable<HttpResponse<any>> {
        return this.http.post(this.apiUrl + 'register', JSON.stringify(registerModel),
            { headers: this.httpHeaders, observe: 'response' });
    }

    login(loginModel: LoginModel) {
        let errors: string[];
        return this.http.post(this.apiUrl + 'login', JSON.stringify(loginModel), { headers: this.httpHeaders, observe: 'response' })
            .subscribe(response => {
                console.log(response);
                if (response.ok) {
                    errors = null;
                }
            },
                (ex: HttpErrorResponse) => {
                    console.log('ERROR: ' + ex.error);
                    errors = ex.error
                });
        return errors;
    }

    getToken(): string {
        return localStorage.getItem(TOKEN_NAME);
    }

    setToken(tokenModel: AuthModel) {
        localStorage.setItem(TOKEN_NAME, tokenModel.token);
        localStorage.setItem(EXPIRY, tokenModel.expiry);
        localStorage.setItem(USER_ROLE, tokenModel.role.toString());
    }

    getTokenExpirationDate(): number {
        const validTo = localStorage.getItem(EXPIRY);
        return Date.parse(validTo);
    }

    isTokenExpired(token?: string): boolean {
        if (!token) {
            token = this.getToken();
        }
        if (!token) {
            return true;
        }

        const date = this.getTokenExpirationDate();
        if (date === undefined) {
            return false;
        }
        return !(date.valueOf() > new Date().valueOf());
    }

    removeTokens(): void {
        localStorage.removeItem(TOKEN_NAME);
        localStorage.removeItem(EXPIRY);
        localStorage.removeItem(USER_ROLE);
    }

    getUserRole(): number {
        let userRole: string = JSON.parse(localStorage.getItem(USER_ROLE));
        return parseInt(userRole);
    }

    isAdmin(): boolean {
        if (localStorage.getItem(USER_ROLE) == null) {
            return false;
        }

        return this.getUserRole() === Roles.Admin;
    }
}
