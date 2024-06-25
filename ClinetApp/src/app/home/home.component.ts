import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  userData : any;
  registerMode : boolean = false;
constructor(private _HttpClient: HttpClient){}


ngOnInit(): void {

  this.getAllUsers()
  }


  getAllUsers(){
    this._HttpClient.get(`https://localhost:7125/api/Users`).subscribe({
      next:(respone) =>{console.log(respone);
          this.userData = respone
      },
      error:(err) => console.log(err),

    })
}


CancelRegister(event : boolean){
  this.registerMode = event;
}

}
