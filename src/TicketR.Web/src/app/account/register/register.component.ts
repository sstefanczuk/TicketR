import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../http/account-service';
import { RegisterModel } from '../../models/account/registerModel';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private accountService: AccountService) { }
  model = new RegisterModel();
  ngOnInit() {


  }

  onSubmit() {
    console.log(this.model);
    // var x = this.accountService.register(this.model)
    //   .subscribe(() => console.log('dsad'));
  }
}
