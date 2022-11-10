import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Detail } from '../Classes/detail';
import {Shoppingbag} from '../Classes/shoppingbag';


@Injectable({
  providedIn: 'root'
})
export class ToysService {
  URL = 'https://localhost:44313/api/toys/';

  private currentToy: Detail = new Detail(0, "", "", 0, 0, "");
 

  setcurrentToy(c) {
    this.currentToy = c;
  }
  getcurrentToy() {
    return this.currentToy;
  }


  constructor(private myHttp: HttpClient) { }

   //פונקציות כדי לקבל פרטים מהשרת
   
   //תביא את כל רשימת המשחקים
  getToy(): Observable<Array<Detail>> {
    return this.myHttp.get<Array<Detail>>(this.URL + "GetAlltoy");
  }

  //תשלוף משחק על פי קוד מסוים
  getToyById(id: number): Observable<Array<Detail>> {
    return this.myHttp.get<Array<Detail>>(this.URL + "Gettoyid/" + id);
  }
  //קבלת רשימת מוצרים על פי קטגוריה מסוימת
  getToyByCat(code: number): Observable<Array<Detail>> {
    return this.myHttp.get<Array<Detail>>(this.URL + "Gettoycat/" + code);
  }
  //תוסיף משחק
  addToy(newcategory: Detail): Observable<Array<Detail>> {
    return this.myHttp.post<Array<Detail>>(this.URL + "Addnewtoy", newcategory);
  }
  //תערוך פרטי משחק
  updateToy(id: number, newToy: Detail): Observable<Array<Detail>> {
    return this.myHttp.put<Array<Detail>>(this.URL + "UpDateatoy/" + id, newToy);
  }
  //תמחק משחק מהשרת
  deleteToy(id: number): Observable<Array<Detail>> {
    return this.myHttp.delete<Array<Detail>>(this.URL + "Deletetoy/" + id);
  }


}