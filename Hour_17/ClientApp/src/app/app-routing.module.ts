import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TripComponent } from './trip.component';

const appRoutes: Routes = [
	{ path: 'mytrips', component: TripComponent }
]; 

@NgModule({
  imports: [
		RouterModule.forRoot(appRoutes)
  ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
