import { Component, OnInit } from '@angular/core';
import { UsersService } from '../../../Servise/users.service';
import { Customer } from '../../../Classes/customer';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  enternewUser: Customer = new Customer(0, "", "", "", "");
  listusers: Array<Customer>
  constructor(private useservise: UsersService, private router: Router) { }

  ngOnInit(): void {
  }
  //בעת הרשמה-משתמש חדש-שומר בשרת
  onEnter() { 
    console.log(this.enternewUser)
    //שכתובה בסרביס addUser הוספת נתונים לשרת על ידי פונקציה 
    this.useservise.addUser(this.enternewUser).subscribe(
      list => { this.listusers = list; },
      err => { alert(err.message); })     
    this.enter()
  }
//פותח את תצוגת המוצרים
  enter() {
    this.router.navigate(["/enter"]);
  }
  //חוזר לעמוד הקודם שהיה
  close(){
    window.history.back();
  }
}

