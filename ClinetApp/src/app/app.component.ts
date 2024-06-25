import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';
import { User } from './_models/User';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'ClinetApp';
  userData :any;

constructor( private _HttpClient: HttpClient , private _AccountService: AccountService){}

ngOnInit(): void {
  this.getCurrentUser();

}




getCurrentUser(){
   const userjson = localStorage.getItem("userToken");
  if(!userjson)
      return;

  const user : User =  JSON.parse(userjson)

this._AccountService.setCurrentUser(user)

}



}
