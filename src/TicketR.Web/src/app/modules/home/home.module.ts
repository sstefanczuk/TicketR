import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './pages/home/home.component';
import { EventsModule } from '../events/events.module';
import { EventListComponent } from '../events/components/event-list/event-list.component';

@NgModule({
  imports: [
    CommonModule,
    HomeRoutingModule,
    EventsModule,
  ],
  declarations: [
    HomeComponent,
  ],
  exports: [
    HomeComponent
  ]
})
export class HomeModule { }
