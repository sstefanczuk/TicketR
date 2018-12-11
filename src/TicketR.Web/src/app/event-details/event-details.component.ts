import { Component, OnInit, Input } from '@angular/core';
import { EventDetails, TicketsPool, Location } from './event-details';
import { ActivatedRoute } from '@angular/router';
import { EventsService } from '../http/events-service';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent implements OnInit {
  @Input() event: EventDetails;

  constructor(
    private route: ActivatedRoute,
    private eventsService: EventsService) { }

  ngOnInit() {
    this.event = new EventDetails();

    const id = +this.route.snapshot.paramMap.get('id');
    this.eventsService
      .getEvent(id)
      .subscribe(event => this.event = event);
  }

}
