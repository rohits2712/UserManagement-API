import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { UsersComponent } from './users/users.component';
import { AppRouterModule } from './app-router.module';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HttpClientModule } from '@angular/common/http';
import { NewUserComponent } from './new-user/new-user.component';
import { UpdateUserComponent } from './update-user/update-user.component';


//services
import { UserService } from './user.service';


//animations
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule, MatButtonModule, MatInputModule, MatCardModule, MatSelectModule, 
  MatToolbarModule, MatDialogModule, MatListModule } from '@angular/material';
//forms
import { ReactiveFormsModule } from '@angular/forms';
import { DeleteUserComponent } from './delete-user/delete-user.component';

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    HeaderComponent,
    FooterComponent,
    NewUserComponent,
    UpdateUserComponent,
    DeleteUserComponent,
  ],
  imports: [
    BrowserModule,
    AppRouterModule,
    HttpClientModule,
    //material design
    BrowserAnimationsModule,
    MatTableModule, MatButtonModule, MatInputModule, MatCardModule, MatSelectModule, MatToolbarModule, MatDialogModule,MatListModule,
    //Forms
    ReactiveFormsModule
  ],
  entryComponents:[UpdateUserComponent],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
