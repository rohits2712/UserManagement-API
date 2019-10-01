import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from '../user.service';
import { UserElement } from '../interfaces/UserElement';
import { Type } from '../interfaces/Type';

@Component({
  selector: 'app-new-user',
  templateUrl: './new-user.component.html',
  styleUrls: ['./new-user.component.css']
})

export class NewUserComponent implements OnInit {

  types: Type[] = [];
  constructor(private service: UserService) { }


  userForm = new FormGroup({
    givenName: new FormControl('',Validators.required),
    surname: new FormControl('',Validators.required),
    emailAddress: new FormControl('',[Validators.required, Validators.pattern(new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/))]),
    phoneNumber: new FormControl('',[Validators.required,Validators.pattern(new RegExp(/^\d{7}$/))]),
    managerId: new FormControl('',Validators.required),
  })

  onSubmit(){
    console.log(this.userForm.value);
    this.service.createUser(this.userForm.value).subscribe((data)=> {
      console.log('Data - ',data);
    })
  }
  ngOnInit() {
    this.service.getAll().subscribe((data) => {
      console.log('Result - ', data);
      var userElements = data as UserElement[];
      var datalength = userElements.length-1;
      while (datalength > 0) {
        console.log((userElements[datalength] as UserElement).id);
        this.types.push(new Type(userElements[datalength].id, userElements[datalength].givenName + " " + userElements[datalength].surname))
        datalength--;
      }
    })
  }



}


