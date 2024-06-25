import { MessagesComponent } from './messages/messages.component';
import { Injectable, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailsComponent } from './members/member-details/member-details.component';
import { ListsComponent } from './lists/lists.component';
import { RegisterComponent } from './register/register.component';
import {  AuthGuard, authGuard } from './gardes/auth.guard';

const routes: Routes = [
  {path : '' , component : HomeComponent},

    {path: '' ,

      runGuardsAndResolvers : 'always',
      canActivate : [authGuard],
      children: [
        {path : 'member-list' , component : MemberListComponent},
        {path : 'member-list/:id' , component :MemberDetailsComponent },
        {path : 'lists' , component :ListsComponent  } ,
        {path : "messages" , component :MessagesComponent},
      ]
    },
  {path : "**" ,  redirectTo : ''  , pathMatch :  'full'},
  {path : 'register' , component : RegisterComponent}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
