import { Component, OnInit } from '@angular/core';
import { IProcessRequest } from '../shared/models/processRequest';
import { RequestsService } from './requests.service';

@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.scss']
})
export class RequestsComponent implements OnInit {

  requests: IProcessRequest[];

  constructor(private requestsService: RequestsService) { }

  ngOnInit(): void {

    this.requestsService.getRequests().subscribe(response => {
      this.requests = response;
    }, error => {
      console.log(error);
    });
  }

}
