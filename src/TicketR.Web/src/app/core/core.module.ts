import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoreRoutingModule } from './core-routing.module';
import { EventsService } from './http/events-service';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    CoreRoutingModule,
    SharedModule,
  ],
  declarations: [
  ]
})
export class CoreModule {
}
