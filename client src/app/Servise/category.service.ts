import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../Classes/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  URL = "https://localhost:44313/api/Category/";

  constructor(private myHttp: HttpClient) { }

  //פונקציות כדי לקבל פרטים מהשרת
  
  //מקבלת את רשימת הקטגוריות מהשרת
  getCategory(): Observable<Array<Category>> {
    return this.myHttp.get<Array<Category>>(this.URL + "GetAll");
  }
  //מקבלת קטגוריה על פי קוד שנשלח אליה
  getCategoryById(id: number): Observable<Array<Category>> {
    return this.myHttp.get<Array<Category>>(this.URL + "GetById/" + id);
  }
  //תוסיף לשרת קטגוריה
  addCategory(newcategory: Category): Observable<Array<Category>> {
    return this.myHttp.post<Array<Category>>(this.URL + "AddnewCategory", { nameCategory: newcategory });
  }
  //תעדכן קטגוריה
  updateCategory(id: number, newcategory: Category): Observable<Array<Category>> {
    return this.myHttp.put<Array<Category>>(this.URL + "UpDateaCategory/" + id, {nameCategory:newcategory});
  }
}




