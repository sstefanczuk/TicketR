import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../http/account-service';
import { RegisterModel } from '../../models/account/registerModel';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private accountService: AccountService) { }

  ngOnInit() {
    let model = new RegisterModel();
    model.userName = "test";
    model.confirmPassword = "test";
    model.password = "test";
    model.email = "test@test.com";
    var x = this.accountService.register(model)
      .subscribe(() => console.log('dsad'));
  }

}
