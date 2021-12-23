import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IProcessRequest } from '../shared/models/processRequest';
import { ComponentDetail } from '../shared/models/tryComponentDetail';


@Injectable({
  providedIn: 'root'
})
export class FormsService {
  baseUrl = environment.apiUrl;

  private requestSource = new BehaviorSubject<ComponentDetail>(null);
  request$ = this.requestSource.asObservable();

  constructor(private http: HttpClient, private router: Router) { }
  

  
submitRequest(values: any) : Observable<any>{

  const httpOptions = {
    headers: { 
    'Content-Type': 'application/json',
    },
    params: values
  };
  console.log(values);
  return this.http.get(this.baseUrl + 'ComponentProcessing', values);
      }
}
