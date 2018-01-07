import { NgModule } from '@angular/core';

import { AppComponent } from './components/app.component'
import { FaqComponent } from './components/faq.component';
import { PageNotFoundComponent } from './components/page-not-found.component';
import { TripComponent } from './components/trip.component'

import { AppRoutingModule } from './components/app-routing.module';

import { FaqService } from './components/faq.service';
import { TripService } from './components/trip.service';

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        TripComponent,
        FaqComponent,
        PageNotFoundComponent
    ],
    imports: [
        AppRoutingModule
    ],
    providers: [
        TripService,
        FaqService
    ]
};
