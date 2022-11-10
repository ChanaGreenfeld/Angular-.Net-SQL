import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {Customer} from '../../../Classes/customer';
import {UsersService} from '../../../Servise/users.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  enterUser: Customer = new Customer(0, "", "", "", "");
yes:boolean=true
  constructor(private router:Router ,private userservise:UsersService) { }

  ngOnInit(): void {
    this.enterUser=this.userservise.user
    if(this.enterUser!=undefined)
    {
        this.yes=false
    }
  }
 

}
