import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ComponentDetail } from 'src/app/shared/models/tryComponentDetail';
import { FormsService } from '../forms.service';

@Component({
  selector: 'app-returnform',
  templateUrl: './returnform.component.html',
  styleUrls: ['./returnform.component.scss']
})
export class ReturnformComponent implements OnInit {
  componentType: string[] = ['Accessory','Integral'];

  returnForm: FormGroup
  constructor(private formsservice: FormsService, private router: Router) { }

  ngOnInit(): void {
    this.createRequestForm();
  }

  createRequestForm(){
    this.returnForm = new FormGroup({
      userName: new FormControl('',Validators.required),
      contactNumber: new FormControl('',Validators.required),
      componentType: new FormControl('',Validators.required),
      componentName: new FormControl('',Validators.required),
      quantity: new FormControl('',Validators.required),
    });
  }

  onSubmit(){

    this.formsservice.submitRequest(this.returnForm.value).subscribe(()=>{
      this.router.navigateByUrl('/contact')
    }, error =>{
      console.log(error);
    });

  }

  

}
