import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { TripService } from './trip.service';
import { TripComponent } from './trip.component';

@NgModule({
  declarations: [
    AppComponent,
    TripComponent
  ],
	imports: [
		AppRoutingModule,
		BrowserModule,
    FormsModule,
    HttpModule
  ],
  providers: [ TripService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
