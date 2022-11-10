import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Detail} from '../Classes/detail';

@Injectable({
  providedIn: 'root'
})
export class DetailsService {
 URL = "https://localhost:44313/api/toys/";
  constructor(private myHttp:HttpClient) { }


   //פונקציות כדי לקבל פרטים מהשרת
   //תביא את כל רשימת המוצרים
  GetAlltoy():Observable<Array<Detail>>
  {
      return this.myHttp.get<Array<Detail>>(this.URL + "GetAlltoy");
  }

}

