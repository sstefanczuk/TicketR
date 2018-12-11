export class EventDetails {

    constructor()
    {
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

export class TicketsPool {
    name: string;
    price: number;
    availableTickets: number;
    totalTickets: number;
}

export class Location {
    name: string;
    description: string;
    imagePath: string;
    city: string;
    addressLines: string[];
    phone: string;
}