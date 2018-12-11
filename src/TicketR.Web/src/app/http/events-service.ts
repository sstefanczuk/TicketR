import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EventDetails } from '../event-details/event-details';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class EventsService {

    private apiUrl = 'http://localhost:5000/api/';

    constructor(private http: HttpClient)
    {
    }

    getEvent(id: number): Observable<EventDetails> {
        return this.http.get<EventDetails>(this.apiUrl + 'events/' + id);
    }

}