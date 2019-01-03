import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EventDetailsComponent } from './pages/event-details/event-details.component';

const routes: Routes = [
  {
    path: 'event',
    children: [
      {
        path: ':id',
        component: EventDetailsComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EventsRoutingModule {
}
