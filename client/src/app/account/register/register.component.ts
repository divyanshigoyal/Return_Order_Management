import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  resgisterForm: FormGroup;
  errors: string[];

  constructor(private fb: FormBuilder, private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    this.createRegisterForm();
  }

  createRegisterForm(){
    this.resgisterForm = this.fb.group({
      displayName: [null, [Validators.required]],
      email: [null,[Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]],
      password: [null, [Validators.required]]
    });
  }

  onSubmit(){
    this.accountService.register(this.resgisterForm.value).subscribe(response =>{
      this.router.navigateByUrl('/admin');
    }, error => {
      console.log(error);
      this.errors = error.errors;
    });
  }

}
