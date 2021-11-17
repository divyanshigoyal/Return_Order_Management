import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RequestsComponent } from './requests.component';
import { RequestItemComponent } from './request-item/request-item.component';



@NgModule({
  declarations: [
    RequestsComponent,
    RequestItemComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [RequestsComponent]
})
export class RequestsModule { }
