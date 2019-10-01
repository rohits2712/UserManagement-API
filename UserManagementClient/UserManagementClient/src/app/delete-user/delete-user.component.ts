import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-delete-user',
  templateUrl: './delete-user.component.html',
  styleUrls: ['./delete-user.component.css']
})
export class DeleteUserComponent implements OnInit {

  user={
    givenName: '',
    surname: '',
    emailAddress: '',
    phoneNumber: 0,
    managerId: '',
  }
  id;
  constructor(private route:ActivatedRoute, private service:UserService, private router:Router) { 

  }
  confirm(){
    // this.route.queryParams
    // this.service.updateUser(this.id, this.form.value).subscribe((data) => { console.log('Data -' + data) })
   console.log("deleting id -", this.id)
    this.service.deleteUser(this.id).subscribe((data)=> console.log(data));
  }
  cancel(){
    this.router.navigate(['/']);
  }

  ngOnInit() {
    this.id =this.route.snapshot.paramMap.get('id');

  }

}
