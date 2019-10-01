import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl: string = 'http://localhost:5000/api/v1/users'
  constructor(private http:HttpClient) { }

  getAll(){
    return this.http.get(this.baseUrl);
  }
  getUser(id){
    return this.http.get(this.baseUrl+'/'+id);
  }
  createUser(user){
    return this.http.post(this.baseUrl, user);
  }
  updateUser(id,user){
    return this.http.patch(this.baseUrl +'/'+ id , user);
  }
  deleteUser(id){
    return this.http.delete(this.baseUrl+'/'+ id);
  }
}
