import { TicketsPool } from './ticketsPool';
import { Location } from './location';

export class EventDetails {

    constructor() {
        this.location = new Location();
        this.ticketsPools = new Array<TicketsPool>();
    }

    id: number;
    title: string;
    subtitle: string;
    date: Date;
    category: string;
    imagePath: string;
    description: string;
    ticketsPerClientLimit: number;

    ticketsPools: TicketsPool[];
    location: Location;
}
