/**

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { TripService } from './trip.service';
import { TripComponent } from './trip.component';
import { PageNotFoundComponent } from './page-not-found.component';
import { FaqComponent } from './faq.component';
import { FaqService } from './faq.service';

@NgModule({
  declarations: [
    AppComponent,
    TripComponent,
    PageNotFoundComponent,
    FaqComponent
  ],
	imports: [
		AppRoutingModule,
		BrowserModule,
    FormsModule,
    HttpModule
  ],
  providers: [ TripService, FaqService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
**/