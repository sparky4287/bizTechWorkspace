import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home';
import { MechwarriorComponent } from './components/mechwarrior/mechwarrior';
import { MechComponent } from './components/mech/mech';

export const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'mech/:id', component: MechComponent },
    { path: 'mechwarrior/:id', component: MechwarriorComponent }
];
