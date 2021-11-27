import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { ContactComponent } from './contact/contact.component';
import { AuthGuard } from './core/guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { RequestsComponent } from './requests/requests.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'admin', canActivate: [AuthGuard],component: RequestsComponent},
  {path: 'contact', component: ContactComponent},
  {path: 'account', loadChildren: () => import('./account/account.module')
      .then(mod => mod.AccountModule)},
  {path: '**', redirectTo:'', pathMatch: 'full'}  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
