import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AccountService } from '../http/account-service';

@Injectable()
export class AuthGuardService implements CanActivate {

    constructor(public auth: AccountService, public router: Router) { }

    canActivate(): boolean {
        if (!this.auth.isTokenExpired()) {
            this.router.navigate(['login']);
            return false;
        }
        return true;
    }
}