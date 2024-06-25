import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from '@angular/router';
import { Observable, map } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { Injectable, inject } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})


export class AuthGuard{
  constructor(private _AccountService: AccountService , private _Router: Router , private _ToastrService: ToastrService ){}

  CanActivateFn() : Observable<boolean> {
    return this._AccountService.userSouece$$.pipe(
      map(user => {
        if(user) {
          return true
        }else{
          //this._Router.navigateByUrl('/')
          this._ToastrService.error("You should login first")
          return false;
        }
      })
    )
  }

}



export const authGuard: CanActivateFn = (route, state) => {
  return inject(AuthGuard).CanActivateFn();
};

