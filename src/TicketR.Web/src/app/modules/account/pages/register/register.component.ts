import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../../../core/http/account-service';
import { RegisterModel } from '../../models/registerModel';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  constructor(private accountService: AccountService, private router: Router) { }
  model = new RegisterModel();
  errors: string[];
  ngOnInit() {
  }

  onSubmit() {
    this.accountService.register(this.model)
      .subscribe(response => {
        console.log(response);
        if (response.ok) {
          this.errors = null;
          this.router.navigate(['/account/login']);
        }
      },
        (ex: HttpErrorResponse) => {
          console.log(ex);
          this.errors = (ex.error as string).split(',');
        });
  }
}
