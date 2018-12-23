import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { EventDetails } from 'src/app/modules/events/models/eventDetails';
import { EventCategory } from 'src/app/modules/events/enums/eventCategory';
import { EventPreview } from 'src/app/modules/events/models/eventPreview';

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
