import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Mech } from '../models/mech';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MechService {
  constructor() { }

  private http = inject(HttpClient);
  private apiUrl = 'http://localhost:5246/api/';

  getMechs(): Observable<Mech[]> {
    return this.http.get<Mech[]>(this.apiUrl + 'Mechs');
  }

  getMech(id: number): Observable<Mech> {
    return this.http.get<Mech>(this.apiUrl + `Mech/${id}`);
  }
}
