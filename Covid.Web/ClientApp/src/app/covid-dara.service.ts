import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { StateData } from  './model/states-data';


@Injectable({
    providedIn: 'root'
  })
  export class CovidDataService {
  
    constructor(private http: HttpClient) { }
  
    public getCovidDate() : Observable<StateData[]> {
  
        return this.http.get<StateData[]>('/Covid');
  
    }
  }
  