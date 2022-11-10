import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/Servise/users.service';

@Component({
  selector: 'app-finish',
  templateUrl: './finish.component.html',
  styleUrls: ['./finish.component.css']
})
export class FinishComponent implements OnInit {

  constructor(private useservise: UsersService) { }

  ngOnInit(): void {
    //התנתקות מהמשתמש הנוכחי -בעת תשלום התנתקות מהסשן סטורייג
    this.useservise.clearUser();
  }
 
}
