import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { EventDetails } from '../event-details/event-details';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { EventPreview } from '../models/eventPreview';
import { EventCategory } from '../enums/eventCategory';

@Injectable({ providedIn: 'root' })
export class EventsService {

    private apiUrl = 'http://localhost:5000/api/';

    constructor(private http: HttpClient) {
    }

    getEvent(id: number): Observable<EventDetails> {
        return this.http.get<EventDetails>(this.apiUrl + 'events/' + id);
    }

    getEvents(category: EventCategory): Observable<EventPreview[]> {
        const urlParams = new HttpParams().set('category', category.toString());
        return this.http.get<EventPreview[]>(this.apiUrl + 'events', { params: urlParams });
    }
}
