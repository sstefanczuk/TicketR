import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { EventDetails } from 'src/app/modules/events/models/eventDetails';

@Injectable({ providedIn: 'root' })
export class EventsService {

    private apiUrl = 'http://localhost:5000/api/';

    constructor(private http: HttpClient) {
    }

    getEvent(id: number): Observable<EventDetails> {
        return this.http.get<EventDetails>(this.apiUrl + 'events/' + id);
    }
}
