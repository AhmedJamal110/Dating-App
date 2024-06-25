import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})

export class NavComponent implements OnInit {
  model : any = {} ;

 // loggedIn : boolean = false;
constructor( public _AccountService : AccountService , private _Router :Router , private _ToastrService: ToastrService) {}


ngOnInit(): void {

  }

 login(){

  this._AccountService.login(this.model).subscribe({
    next:(response) =>{
      this._Router.navigateByUrl("member-list")
      console.log(response)
    },
    error:(err) =>{
      console.log(err);
      this._ToastrService.error(err.error)
    },


    complete: () => console.log("Compelet")

  })
}


logOut(){
  this._Router.navigateByUrl("/")
  this._AccountService.logOut();
}

}
