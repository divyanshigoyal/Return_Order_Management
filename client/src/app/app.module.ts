import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import { CoreModule } from './core/core.module';
import { RequestsModule } from './requests/requests.module';
import { HomeModule } from './home/home.module';
import { ContactModule } from './contact/contact.module';
import { AccountModule } from './account/account.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CoreModule,
    RequestsModule,
    HomeModule,
    ContactModule,
    AccountModule,
    RequestsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
