import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IProcessRequest } from '../shared/models/processRequest';


@Injectable({
  providedIn: 'root'
})
export class FormsService {
  baseUrl = environment.apiUrl;

  private requestSource = new BehaviorSubject<IProcessRequest>(null);
  request$ = this.requestSource.asObservable();
   
  constructor(private http: HttpClient, private router: Router) { }
  
  submitRequest(request: IProcessRequest) {
    console.log(request);
    return this.http.post(this.baseUrl + 'ComponentProcessing', request);
        }
  }
