import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoreRoutingModule } from './core-routing.module';
import { EventsService } from './http/events-service';
import { SharedModule } from '../shared/shared.module';
import { HomeComponent } from './pages/home/home.component';

@NgModule({
  imports: [
    CommonModule,
    CoreRoutingModule,
    SharedModule,
  ],
  declarations: [
    HomeComponent,
  ]
})
export class CoreModule {
}
