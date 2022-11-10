import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Detail } from '../Classes/detail';
import { Buy } from '../Classes/buy';
import { Buydetail } from '../Classes/buydetail';
import {Shoppingbag} from '../Classes/shoppingbag';

@Injectable({
  providedIn: 'root'
})
export class ShoppingbagService {
  URL = 'https://localhost:44313/api/buying/';
  URL2= 'https://localhost:44313/api/buyingDetails/'
  shoppingbag: Array<Shoppingbag> = [];
  num:number=-1
  counts:number
  sums:number
  constructor(private myHttp: HttpClient) { }

  //בהוספה לסל הקניות
  addbag(prod:Detail){
    //שמירת המקום במערך של משחק מסוים
        for (let i = 0; i <this.shoppingbag.length; i++) {
          if(this.shoppingbag[i].toy.codetoy==prod.codetoy){
              this.num=i;
          }
        }
        //אם המשחק לא קיים
        //תכניס אותו למערך
        if(this.num==-1)
        {
          this.counts=1
          this.sums=prod.price
          console.log(this.shoppingbag);          
          this.shoppingbag.push({ toy: prod ,count:this.counts , sum:this.sums })
          console.log(this.shoppingbag);         
        
        }      
        //אם המשחק קיים כבר 
        //תוסיף לכמות ולא רשומה חדשה
        else
        {
          this.shoppingbag[this.num].count++
          this.shoppingbag[this.num].sum=this.shoppingbag[this.num].toy.price*this.shoppingbag[this.num].count
          this.num=-1
        }
    
  }

   //פונקציות כדי לקבל פרטים מהשרת
  //תוסיף קניה טבלת הקניה
  addBuy(newbuying: Buy): Observable<Array<Buy>> {
    return this.myHttp.post<Array<Buy>>(this.URL + "Addnewbuy", newbuying);
  }
  //תביא את טבלת קניה
    GetAllbuy(): Observable<Array<Buy>> {
    return this.myHttp.get<Array<Buy>>(this.URL + "GetAllbuy");
  }

  //תוסיף פרטי קניה לטבלת פרטי הקניה
  addBuydeyails(newbuyingdetails: Buydetail): Observable<Array<Buydetail>> {
    return this.myHttp.post<Array<Buydetail>>(this.URL2 + "Addnewbuydet", newbuyingdetails);
  }
}