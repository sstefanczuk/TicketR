import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../http/account-service';
import { RegisterModel } from '../../models/account/registerModel';
import { FormsModule } from '@angular/forms';
import { HttpErrorResponse } from '../../../../node_modules/@angular/common/http';
import { Router } from '../../../../node_modules/@angular/router';

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
          this.router.navigate(['/login']);
        }
      },
        (ex: HttpErrorResponse) => {
          console.log(ex);

          this.errors = ex.error;
        });
  }
}
