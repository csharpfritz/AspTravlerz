import { Component, OnInit } from '@angular/core';

import { Trip } from './trip';
import { TripService } from './trip.service';

@Component({
  selector: 'app-trip',
  templateUrl: './trip.component.html',
  styleUrls: ['./trip.component.css']
})
export class TripComponent implements OnInit {

	trips: Trip[];
	selectedTrip: Trip = null;

	constructor(private service: TripService) { }

	ngOnInit(): void {
		this.service.Get().subscribe(trips => this.trips = trips);
	}

	onSelect(trip: Trip) {
		this.selectedTrip = trip;
	}

}
