import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Buy } from 'src/app/Classes/buy';
import { Buydetail } from 'src/app/Classes/buydetail';
import {Shoppingbag} from '../../../Classes/shoppingbag';
import {ShoppingbagService} from '../../../Servise/shoppingbag.service';
import {UsersService} from '../../../Servise/users.service';


@Component({
  selector:'app-shopping-bag',
  templateUrl:'./shopping-bag.component.html',
  styleUrls: ['./shopping-bag.component.css']
})
export class ShoppingBagComponent implements OnInit {

  constructor(private router:Router , private shbServise:ShoppingbagService, private useservise:UsersService) { }
  shoppingbag2:Array<Shoppingbag>=[]
  num:number
  currentuser:number
  mone:number
  totalsum:number=0
  b:Array<Buy>
  d:Array<Buy>=[]
  a:number
  c:Array<Buydetail>
  codebuy:number=0
 
  //בעת טעינת הדף 
  //מביא את סל הקניות מהסרביס וכן את המשתמש הנוכחי
  ngOnInit(): void {   
    //תשמור את מערך הקניות מהסרביס
  this.shoppingbag2=this.shbServise.shoppingbag; 
  console.log(this.shoppingbag2);  
  //קוד המשתמש הנוכחי
  this.currentuser=this.useservise.user.codeuser 
  //עובר על מערך הקניות
  for (let i = 0; i < this.shoppingbag2.length; i++) {
    //מחשב מחיר כפול כמות עבור כל מוצר
    this.totalsum=this.totalsum+(this.shoppingbag2[i].toy.price*this.shoppingbag2[i].count)
     }
  }
   
  //מחשב את הסכום הסופי
  tosum(mone:number ,num:number){
    this.totalsum=this.totalsum+(this.shoppingbag2[mone].toy.price)*num
  }
 
  //מוחק את הפריט הרצוי מסל הקניות
  delete(x)
  {
    // מחפש את מיקום המשחק הנוכחי
    this.num=this.shbServise.shoppingbag.findIndex(y=>y.toy.codetoy==x)
    this.tosum(this.num,-1)
    //מוחק את הקוד שנמצא
    this.shoppingbag2.splice(this.num,1)
  }
    

  //ניתן להוריד מהכמות שהוספה לסל אך לא נותן לבטל
    //מחשב את הסה"כ של המוצר
  minusf(shbag){ 
    //מחפש את מיקום משחק מסוים במערך
    this.mone=this.shbServise.shoppingbag.findIndex(y=>y.toy.codetoy==shbag.toy.codetoy)
    //אם הכמות שהוזמנה גדולה מאחד
    if( this.shbServise.shoppingbag[this.mone].count>1) {
      //תוריד אחד מהכמות שהוזמנה
      this.shbServise.shoppingbag[this.mone].count--
      //תחשב את הסכום מחדש
      this.shbServise.shoppingbag[this.mone].sum= (this.shbServise.shoppingbag[this.mone].count* this.shbServise.shoppingbag[this.mone].toy.price) 
      //שולח לפונקציה שמחשבת את הסכום הכללי של הקניה
      //שולח אחד או מינוס אחד כי שם בפונקציה הוא מכפיל כל פעם במה שמתקבל
      this.tosum(this.mone,-1)
     }
  }

  //מוסיף כמות לכמות שהוזמנה 
  //מחשב את הסה"כ של המוצר
  plusf(shbag){
    //מחפש את מיקום משחק מסוים במערך
    this.mone=this.shbServise.shoppingbag.findIndex(y=>y.toy.codetoy==shbag.toy.codetoy)
    //מוסיף אחד לכמות שהוזמנה
    this.shbServise.shoppingbag[this.mone].count++
    //מחשב את הסכום החדש
    this.shbServise.shoppingbag[this.mone].sum= (this.shbServise.shoppingbag[this.mone].count* this.shbServise.shoppingbag[this.mone].toy.price)
    //שולח לפונקציה שמחשבת את הסכום הכללי של הקניה
      //שולח אחד או מינוס אחד כי שם בפונקציה הוא מכפיל כל פעם במה שמתקבל
    this.tosum(this.mone,1)
  }

  //בעת סיום הקניה
  save(){
    //שמירה בטבלת קניה
    let item:Buy=new Buy(0,"today",this.useservise.user.codeuser,this.totalsum)
    console.log(item);
    //שכתובה בסרביס addBuy הוספת נתונים לשרת על ידי פונקציה 
    this.shbServise.addBuy(item).subscribe(  
    list => { this.b = list;   },
    err => { alert(err.message);}) 

    this.shbServise.GetAllbuy().subscribe(       
      myData => { this.d = myData;    },     
      err => { alert(err.message);})   
     this.a=this.d[length].codebuy

    //שמירה בטבלת פרטי קניה

     for (let i = 0; i < this.shoppingbag2.length; i++) {
      let item2:Buydetail=new Buydetail(this.a,this.shoppingbag2[i].toy.codetoy,this.shoppingbag2[i].count)
      this.shbServise.addBuydeyails(item2).subscribe(  
        list => { this.c = list; },       
        err => { alert(err.message);}) 
     } 
       
  }
 
}
