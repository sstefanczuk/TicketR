import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../../models/account/loginModel';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../http/account-service';
import { HttpErrorResponse } from '../../../../node_modules/@angular/common/http';

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
        console.log(response);
        if (response.ok) {
          this.errors = null;
        }
      },
        (ex: HttpErrorResponse) => {
          this.errors = ex.error;
          console.log(ex);
        });
  }
}
