import { Component } from '@angular/core';
import { Trip } from './trip';
// import { TripService } from './trip.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'My Cool Application';
//   private service: TripService;

  constructor() {

    // this.service = svc;

  }

  trips: Trip[] = [
     new Trip('New York City', 5),
     new Trip('Las Vegas', 2)
  ];

}
