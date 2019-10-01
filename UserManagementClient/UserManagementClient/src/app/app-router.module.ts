import { RouterModule, Routes, Router } from '@angular/router';

//component
import { UsersComponent } from './users/users.component';
import { NgModule } from '@angular/core';
import {NewUserComponent} from './new-user/new-user.component';
import{DeleteUserComponent} from './delete-user/delete-user.component';

//route
const routes: Routes = [
    { path: '', component: UsersComponent },
    { path: 'users', component: UsersComponent },
    { path: 'new-user', component: NewUserComponent },
    { path: 'delete-user/:id', component: DeleteUserComponent }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRouterModule{}