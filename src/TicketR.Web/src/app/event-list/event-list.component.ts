import { Component, OnInit, Input } from '@angular/core';
import { EventPreview } from '../models/eventPreview';
import { EventsService } from '../http/events-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {

  @Input() eventList: EventPreview[];

  constructor(private eventsService: EventsService,
    private router: Router) { }

  ngOnInit() {
    this.eventsService
      .getEvents()
      .subscribe(data => {
        this.eventList = data;
      });
  }

  goToDetails(eventId: number) {
      this.router.navigate([`/event/${eventId}`]);
  }
}
