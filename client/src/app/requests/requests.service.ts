import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IProcessRequest } from '../shared/models/processRequest';

@Injectable({
  providedIn: 'root'
})
export class RequestsService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getRequests(){
    return this.http.get<IProcessRequest[]>(this.baseUrl + 'admin');
  }
}
