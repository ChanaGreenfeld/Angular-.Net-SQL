import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../Classes/customer';


@Injectable({
  providedIn: 'root'
})
export class UsersService {
  URL = 'https://localhost:44313/api/Users/';
  private currentUser: Customer 

  // setcurrentUser(c) {
  //   this.currentUser = c;
  // }
  // getcurrentUser() {
  //   return this.currentUser
  // }

  //'שמירה בסשן סטורייג
  get user() {
    if (sessionStorage.getItem('currentUser'))
      return JSON.parse(sessionStorage.getItem('currentUser'));
    else return null;
  }
  set user(user: Customer) {
    sessionStorage.setItem('currentUser', JSON.stringify(user));
  }
  //התנתקות
  clearUser() {
    sessionStorage.removeItem('currentUser');
  }

   //פונקציות כדי לקבל פרטים מהשרת
  
  constructor(private myHttp: HttpClient) { }
  //תשלוף את רשימת המשתמשים
  getUser(): Observable<Array<Customer>> {
    return this.myHttp.get<Array<Customer>>(this.URL + "GetAlluser");
  }

  //תביא משתמש על פי קוד1
  getUserById(id: number): Observable<Array<Customer>> {
    return this.myHttp.get<Array<Customer>>(this.URL + "Gettuser/" + id);
  }
  //תביא משתמש על פי קוד
  getUserByPass(password: string): Observable<Customer> {

    return this.myHttp.get<Customer>(this.URL + "Gettuserpass/" + password);
  }
  //הוספץ משתמש
  addUser(newuser: Customer): Observable<Array<Customer>> {
    return this.myHttp.post<Array<Customer>>(this.URL + "Addnewuser", newuser);
  }
  //עריכת פרטי משתמש
  updateUser(id: number, newuser: Customer): Observable<Array<Customer>> {
    return this.myHttp.put<Array<Customer>>(this.URL + "UpDateuser/" + id, newuser);
  }
  //מחיקת משתמש
  deleteUser(id: number): Observable<Array<Customer>> {
    return this.myHttp.delete<Array<Customer>>(this.URL + "Deleteuser/" + id);
  }

}








// .pipe(tap(user=>{
//   if(user){this.currentUser=user}
// }))