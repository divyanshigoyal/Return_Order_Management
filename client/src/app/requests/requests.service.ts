import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProcessRequest } from '../shared/models/processRequest';

@Injectable({
  providedIn: 'root'
})
export class RequestsService {

  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getRequests(){
    return this.http.get<IProcessRequest[]>(this.baseUrl + 'admin');
  }
}
