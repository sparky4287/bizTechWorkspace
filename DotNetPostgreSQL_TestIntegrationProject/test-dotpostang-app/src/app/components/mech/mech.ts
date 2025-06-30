import { CommonModule } from '@angular/common';
import { Component, effect, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MechService } from '../../services/mech-service';
import { Observable } from 'rxjs';
import { Mech } from '../../models/mech';

@Component({
  selector: 'app-mech',
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './mech.html',
  styleUrl: './mech.css'
})
export class MechComponent {
  private mechService = inject(MechService);

  selectedMech!: Mech;
  selectableMechs: Mech[] = [];
  
  constructor() {}

  ngOnInit() {
    this.mechService.getMechs()
      .subscribe({
        next: (data) => {
          this.selectableMechs = data;
          this.selectedMech = data[0];
          console.log(data);
        },
        error: (err) => console.error(err)
      });
  }
}