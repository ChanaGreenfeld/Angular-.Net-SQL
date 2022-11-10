import { Injectable } from '@angular/core';
import {Manager} from '../Classes/manager';

@Injectable({
  providedIn: 'root'
})
export class ManagerService {
//הגדרת רשימת מנהלים
 managers=[
  new Manager(1,"gadi","1234","0545662532","ayalon","gadi@gmail.com","jerusalem"),
  new Manager(2,"dani","5678","0543243567","shamgar","dani@gmail.com","rechovot"),
  new Manager(3,"nati","0000","0545464532","gilad","nati@gmail.com","naharia")
]

  constructor() { }
}
