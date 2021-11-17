import { Component, Input, OnInit } from '@angular/core';
import { IProcessRequest } from 'src/app/shared/models/processRequest';

@Component({
  selector: 'app-request-item',
  templateUrl: './request-item.component.html',
  styleUrls: ['./request-item.component.scss']
})
export class RequestItemComponent implements OnInit {

  @Input() request: IProcessRequest;

  constructor() { }

  ngOnInit(): void {
  }

}
