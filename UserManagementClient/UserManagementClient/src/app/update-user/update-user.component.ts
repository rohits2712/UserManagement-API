import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Type } from '../interfaces/Type';
import { UserService } from '../user.service';
import { UserElement } from '../interfaces/UserElement';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.css']
})
export class UpdateUserComponent implements OnInit {

  form: FormGroup;
  id: string;
  types: Type[] = [];

  constructor(private service: UserService, private fb: FormBuilder, private dialogRef: MatDialogRef<UpdateUserComponent>,
    @Inject(MAT_DIALOG_DATA) {
      emailAddress, givenName, managerId, phoneNumber, surname, id
    }) {
    this.id = id;
    this.form = fb.group({
      givenName: [givenName, Validators.required],
      surname: [surname, Validators.required],
      emailAddress: [emailAddress, Validators.required],
      phoneNumber: [phoneNumber, Validators.required],
      managerId: [managerId, Validators.required]
    })
  }

  close() { console.log("close clicked"); this.dialogRef.close(); }
  save() {
    // console.log("save clicked");
    this.form.value.id = this.id;
    this.service.updateUser(this.id, this.form.value).subscribe((data) => { console.log('Data -' + data) })
  }

  ngOnInit() {
    this.service.getAll().subscribe((data) => {
      console.log('Result - ', data);
      var userElements = data as UserElement[];
      var datalength = userElements.length - 1;
      while (datalength > 0) {
        console.log((userElements[datalength] as UserElement).id);
        this.types.push(new Type(userElements[datalength].id, userElements[datalength].givenName + " " + userElements[datalength].surname))
        datalength--;
      }
    })
  }

}
