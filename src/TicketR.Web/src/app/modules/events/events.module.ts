import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EventsRoutingModule } from './events-routing.module';
import { EventDetailsComponent } from './pages/event-details/event-details.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CoreModule } from 'src/app/core/core.module';

@NgModule({
  imports: [
    CommonModule,
    EventsRoutingModule,
    SharedModule,
    CoreModule
  ],
  declarations: [
    EventDetailsComponent
  ]
})
export class EventsModule { }
