import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { CoreModule } from '../../core/core.module';
import { SharedModule } from '../../shared/shared.module';
import { AccountRoutingModule } from './account-routing.module';
import { FormsModule }   from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    CoreModule,
    AccountRoutingModule,
    FormsModule
  ],
  declarations: [LoginComponent, RegisterComponent]
})
export class AccountModule { }
