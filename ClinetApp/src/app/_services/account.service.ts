import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../_models/User';


@Injectable({
  providedIn: 'root'
})
export class AccountService implements OnInit {

  userSource = new BehaviorSubject<User | null>(null);
  userSouece$$ = this.userSource. asObservable();


  baseUrl = `https://localhost:7125/api/Accounts/`;

  constructor( private _HttpClient : HttpClient) { }

  ngOnInit(): void {

  }


  register(model: any){
    return this._HttpClient.post<User>(this.baseUrl+"register" , model).pipe(
      map((user: User) => {
        localStorage.setItem("userToken" , JSON.stringify(user));
        this.userSource.next(user);
      })
    )
  }

  login(model : any){
      return this._HttpClient.post<User>(this.baseUrl+'login' , model).pipe(
        map((user : User) => {
          localStorage.setItem("userToken" , JSON.stringify(user));
          this.userSource.next(user);

        })
      )
    }


    setCurrentUser(user : User){
      this.userSource.next(user)
      }


    logOut(){
      localStorage.removeItem("userToken");
      this.userSource.next(null);
    }



}


