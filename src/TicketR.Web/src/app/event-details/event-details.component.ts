import { Component, OnInit } from '@angular/core';
import { EventDetails } from './event-details';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent implements OnInit {
  event: EventDetails;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.event = new EventDetails();
    this.event.id = Number(this.route.snapshot.paramMap.get('id'));
  }

}
