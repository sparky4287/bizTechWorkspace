import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Mechwarrior } from '../models/mechwarrior';
import { ExperienceLevel } from '../models/experience-level';
import { Rank } from '../models/rank';

@Injectable({
  providedIn: 'root'
})
export class MechwarriorService {
  constructor() { }

  private http = inject(HttpClient);
  private apiUrl = 'http://localhost:5246/api/';

  // Mechwarriors methods
  // GETS
  getMechwarriors(): Observable<Mechwarrior[]> {
    return this.http.get<Mechwarrior[]>(this.apiUrl + 'Mechwarriors');
  }
  getMechwarrior(id: number): Observable<Mechwarrior> {
    return this.http.get<Mechwarrior>(this.apiUrl + `Mechwarrior/${id}`);
  }

  // PUTS
  putMechwarrior(mechwarrior: Mechwarrior): void {
    this.http.put(this.apiUrl + `Mechwarriors`, mechwarrior);
  }

  // POSTS
  postMechwarrior(mechwarrior: Mechwarrior): Observable<Mechwarrior> {
    return this.http.post<Mechwarrior>(this.apiUrl + `Mechwarriors`, mechwarrior);
  }

  // DELETES
  deleteMechwarrior(id: number): void {
    this.http.delete(this.apiUrl + `Mechwarrior/${id}`)
  }

  // Experience levels methods
  // GETS
  getExperienceLevels(): Observable<ExperienceLevel[]> {
    return this.http.get<ExperienceLevel[]>(this.apiUrl + 'ExperienceLevels');
  }
  getExperienceLevel(id: number): Observable<ExperienceLevel> {
    return this.http.get<ExperienceLevel>(this.apiUrl + `ExperienceLevel/${id}`);
  }

  // PUTS
  putExperienceLevel(experienceLevel: ExperienceLevel): void {
    this.http.put(this.apiUrl + `ExperienceLevels`, experienceLevel);
  }
  
  // POSTS
  postExperienceLevel(experienceLevel: ExperienceLevel): Observable<ExperienceLevel> {
    return this.http.post<ExperienceLevel>(this.apiUrl + `ExperienceLevels`, experienceLevel);
  }

  // DELETES
  deleteExperienceLevel(id: number): void {
    this.http.delete(this.apiUrl + `ExperienceLevel/${id}`)
  }

  // Ranks methods
  // GETS
  getRanks(): Observable<Rank[]> {
    return this.http.get<Rank[]>(this.apiUrl + 'Ranks');
  }
  getRank(id: number): Observable<Rank> {
    return this.http.get<Rank>(this.apiUrl + `Rank/${id}`);
  }

  // PUTS
  putRank(rank: Rank): void {
    this.http.put(this.apiUrl + `Ranks`, rank);
  }
  
  // POSTS
  postRank(rank: Rank): Observable<Rank> {
    return this.http.post<Rank>(this.apiUrl + `Ranks`, rank);
  }

  // DELETES
  deleteRank(id: number): void {
    this.http.delete(this.apiUrl + `Rank/${id}`)
  }
}
