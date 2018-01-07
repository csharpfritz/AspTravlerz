import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Headers } from '@angular/http';
import { Trip } from './trip';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';

@Injectable(
)
export class TripService {

  constructor(private http: Http) { }


    Get(): Observable<Trip[]> {

      return this.http.get('/api/trips')
        .map(response => response.json().map(item => {
         return new Trip(
            item.id,
            item.name,
            item.description,
            item.startDate,
            item.endDate
          );
        }));

    }

}
