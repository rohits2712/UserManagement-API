import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { MatTableDataSource } from '@angular/material/table';
import { UserElement } from '../interfaces/UserElement';
import { MatDialog } from '@angular/material';
import { UpdateUserComponent } from '../update-user/update-user.component';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  displayedColumns: string[] = ['emailAddress', 'givenName', 'surname', 'phoneNumber', 'actions']
  dataSource;

  constructor(private service: UserService,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    this.service.getAll().subscribe((data) => {
      console.log('Result - ', data);
      this.dataSource = new MatTableDataSource<UserElement>(data as UserElement[]);
    })
  }
  updateUser(user) {
    console.log(user);
    this.dialog.open(UpdateUserComponent, {
      data: {
        id:user.id,
        emailAddress: user.emailAddress,
        givenName: user.givenName,
        managerId: user.managerId,
        phoneNumber: user.phoneNumber,
        surname: user.surname
      }
    })
  }

}
