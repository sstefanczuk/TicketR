import { Component, OnInit } from '@angular/core';
import { EventPreview } from '../models/eventPreview';
import { EventsService } from '../http/events-service';
import { Router } from '@angular/router';
import { EventCategory } from '../enums/eventCategory';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {

  eventList: EventPreview[] = [];
  categoryFilter: EventCategory = EventCategory.Any;

  constructor(private eventsService: EventsService,
    private router: Router) { }

  ngOnInit() {
    this.getEvents();
  }

  getEvents() {
    this.eventsService
      .getEvents(this.categoryFilter)
      .subscribe(data => {
        this.eventList = data;
      });
  }

  goToDetails(eventId: number) {
      this.router.navigate([`/event/${eventId}`]);
  }

  selectCategory(eventCategory: EventCategory) {
    this.categoryFilter = eventCategory;
    this.getEvents();
  }

  isActiveCategory(category: Number) {
    return category === this.categoryFilter;
  }
}
