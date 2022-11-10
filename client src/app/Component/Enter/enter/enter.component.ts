import { NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Customer } from '../../../Classes/customer';
import { UsersService } from '../../../Servise/users.service';
import { ManagerService } from '../../../Servise/manager.service';



@Component({
  selector: 'app-enter',
  templateUrl: './enter.component.html',
  styleUrls: ['./enter.component.css']
})
export class EnterComponent implements OnInit {
  enterUser: Customer = new Customer(0, "", "", "", "");
  customers: Array<Customer> = [];
  yes: boolean = false
  login: boolean = false
  edit: boolean = false
  num: number
  yes2:boolean=false

  constructor(private userservise: UsersService, private mangerservise: ManagerService, private router: Router) { }

  ngOnInit(): void {
  }

  //בכניסה לאתר
  onEnter() {
    //אם הוא מנהל (שהוגדר בסרביס)
    //שימצא מי המנהל יודיע הודעה מתאימה ויעביר לפעולות הניתנות למנהל
    if (this.mangerservise.managers.find(x => x.passwordmanager == this.enterUser.passworduser)) {    
      this.userservise.user = this.mangerservise.managers.find(x => x.passwordmanager == this.enterUser.passworduser) as any;
      console.log(this.userservise.user);     
      //alert("שלום מנהל");     
      this.viewmanager();
      return;
    }
    //בדיקה האם הוא משתמש בטבלת המשתמשים
    //מדפיס הודעה מתאימה
    this.userservise.getUserByPass(this.enterUser.passworduser).subscribe(
      data => {
        if (data != null) {         
          console.log(data);
          this.userservise.user = data;
          this.login = true
          this.yes2=true
          this.yes = false
         // alert("  ברוכים הבאים ללקוח מספר :" + this.userservise.user.codeuser)
          console.log(this.userservise.user);
        }
        else {         
          this.yes = true
          console.log(this.yes);
        }
      },
      error => { error.message }
    );
  }
//בעת עריכת הפרטים
  onEntertwo() {        
    console.log(this.enterUser);
    //תשמור את קוד המשתמש הנוכחי
    this.num = this.userservise.user.codeuser
    console.log(this.num);
    //שכתובה בסרביס updateUser עריכת נתונים בשרת על ידי פונקציה 
    this.userservise.updateUser(this.num, this.enterUser).subscribe(
      myData => {
        this.customers = myData;
        console.log(this.customers);       
      },
      error => { alert(error.message); });
    //alert("העדכון בוצע בהצלחה בהנאה")
    //שולח לפונקציה שתפתח את תצוגת המוצרים
    this.viewProducts();
  }

  //פותח את תצוגת המוצרים
  viewProducts() {
    this.router.navigate(["/viewproduct"]);
  }
  //פותח את אפשרויות המנהל
  viewmanager() {
    this.router.navigate(["/manager"]);
  }
  //פונקצית עזר לתצוגה
  update() {
    this.edit = true   
    console.log(this.userservise.user);
  }
  //תחזור לחלון האחרון שהיית
  closeForm(){
    window.history.back();    
  }
}