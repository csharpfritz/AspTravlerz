import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FaqComponent } from './faq.component';
import { TripComponent } from './trip.component';
import { PageNotFoundComponent } from './page-not-found.component';

const appRoutes: Routes = [
	{ path: '', redirectTo: '/mytrips', pathMatch: 'full' },
	{ path: 'mytrips', component: TripComponent },
	{ path: 'faq', component: FaqComponent },
  { path: '**', component: PageNotFoundComponent }
]; 

@NgModule({
  imports: [
		RouterModule.forRoot(appRoutes)
  ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
