import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EventDetails } from '../event-details/event-details';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { EventPreview } from '../models/eventPreview';

@Injectable({ providedIn: 'root' })
export class EventsService {

    private apiUrl = 'http://localhost:5000/api/';

    constructor(private http: HttpClient) {
    }

    getEvent(id: number): Observable<EventDetails> {
        return this.http.get<EventDetails>(this.apiUrl + 'events/' + id);
    }

    getEvents(): Observable<EventPreview[]> {
        return this.http.get<EventPreview[]>(this.apiUrl + 'events/');
    }
}
