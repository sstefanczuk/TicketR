import { Component, OnInit } from '@angular/core';
import { EventsService } from 'src/app/core/http/events-service';
import { Router } from '@angular/router';
import { EventPreview } from '../../models/eventPreview';
import { EventCategory } from '../../enums/eventCategory';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})

export class EventListComponent implements OnInit {

  constructor(private eventsService: EventsService,
    private router: Router) { }

  eventList: EventPreview[] = [];
  categoryFilter: EventCategory = EventCategory.Any;

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
