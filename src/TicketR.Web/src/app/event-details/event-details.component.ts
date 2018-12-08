import { Component, OnInit, Input } from '@angular/core';
import { EventDetails } from './event-details';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent implements OnInit {
  @Input() event: EventDetails;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.event = {
      id: Number(this.route.snapshot.paramMap.get('id')),
      title: 'Metallica',
      subtitle: 'WorldWired Tour',
      date: new Date(2018, 11, 20),
      category: 'Heavy Metal Concert',
      description: 'Metallica is an American thrash metal/heavy metal band. The band came together in Los Angeles in 1981 and helped to invent the thrash sub-genre of heavy metal. They are well known for many of their songs, including "Master of Puppets", "The Unforgiven", "One", "Enter Sandman", and "Nothing Else Matters." <br /> Since then, they have become one of metal\'s most popular and successful bands, and have sold over 100 million albums worldwide. The band\'s fifth album, Metallica, has sold over 21 million copies, making it the twenty-fifth biggest selling album of all time in America.',
      imagePath: 'https://image.ibb.co/iftwqA/metallica.png',
      ticketsPerClientLimit: 5,
      location: {
        name: 'Tauron Arena',
        city: 'Cracow',
        description: 'Tauron Arena Kraków is the largest and one of most modern entertainment and sports venues in Poland. It allows to host a variety of sports events, including badminton, boxing, curling, acrobatic and artistic gymnastics, indoor football, hockey, basketball, track and field, figure skating, volleyball, handball, martial arts, extreme sports, tennis, table tennis, equestrian competitions and sports dancing competitions.<br /><br />The facility area has 61,434 m2, with maximum area of the arena court of 4 546 m2. The average capacity is 18,000 for concerts, and 15,000 for sport events, with maximum number of spectators being 22,000.',
        imagePath: 'https://ebilet-media.azureedge.net/media/26679/tak_kontakt_foto450.jpg',
        addressLines: [
          'Tauron Arena',
          'Stanisława Lema 7',
          '31-571 Kraków'
        ],
        phone: '12 349 11 02'
      },
      ticketsPools: [
        {
          name: 'Golden Circle',
          price: 119.99,
          availableTickets: 3,
          totalTickets: 50
        },
        {
          name: 'Level A',
          price: 109.99,
          availableTickets: 26,
          totalTickets: 100
        },
        {
          name: 'Level B',
          price: 99.99,
          availableTickets: 39,
          totalTickets: 120
        },
        {
          name: 'Level C',
          price: 79.99,
          availableTickets: 112,
          totalTickets: 180
        }
      ]
    };
  }

}
