import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  //@Input() Users : any;
//@Output() CancelRegist = new EventEmitter();

model:any;

constructor(private _AccountService: AccountService){}

register(){
this._AccountService.register(this.model).subscribe({
  next : (user) => {
    console.log(user);
  },
  error: (err) => console.log(err),
complete : () => console.log("compelete"),

})
}


}
