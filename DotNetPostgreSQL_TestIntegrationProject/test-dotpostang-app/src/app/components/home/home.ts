import { Component } from '@angular/core';
import { Mech } from '../../models/mech' 
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-home',
  imports: [RouterLink],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class HomeComponent {

  currentMech: Mech = {
    id: 7,
    name: 'Marauder',
    description: '75-ton BattleMech, one of the most popular in the Inner Sphere.',
    mechwarriorId: 1
  }

}
