import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../../../core/http/account-service';
import { LoginModel } from '../../models/loginModel';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private accountService: AccountService) { }
  model = new LoginModel();
  errors: string[];
  ngOnInit() {
  }
  onSubmit() {
    this.accountService.login(this.model)
      .subscribe(response => {
        if (response.ok) {
          this.errors = null;
          this.accountService.setToken(response.body);
        }
      },
        (ex: HttpErrorResponse) => {          console.log(ex);

          this.errors = (ex.error as string).split(',');
        });
  }
}