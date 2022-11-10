import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {ToysService} from '../../../Servise/toys.service';
import {Detail} from '../../../Classes/detail';
import {Customer} from '../../../Classes/customer';
import {UsersService} from '../../../Servise/users.service'
import {Shoppingbag} from '../../../Classes/shoppingbag';
import{Category} from '../../../Classes/category';
import {CategoryService} from '../../../Servise/category.service'

@Component({
  selector: 'app-view-product',
  templateUrl:'./view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {
  products:Array<Detail>;
  currentUser:Customer;
  categorys:Array<Category>;
  cat: number;
  products2:Array<Shoppingbag>

  constructor(private toyservise:ToysService,private router:Router,private userServ:UsersService,private catser:CategoryService ) { }
 
  
      ngOnInit(): void {
        //בעת טעינת הדף תציג את כל המוצרים
        this.toyservise.getToy().subscribe(
        myData => { 
          this.products = myData;     
        }, 
        error=> { alert(error.message);});
        //תביא את כל הקטגוריות
        this.catser.getCategory().subscribe(
        myData => { this.categorys = myData; }, 
        error=> { alert(error.message);});

        this.currentUser=this.userServ.user
      
    }
 
    //הצבת המשחקים שהגיעו במערך המוצרים
    all(){
       this.toyservise.getToy().subscribe(
        myData => { this.products = myData; 
          // for (let i = 0; i < this.products.length; i++) {         
          //   this.products2[i].toy=this.products[i];
          //   this.products2[i].count=0;
          //   this.products2[i].sum=0;
          // }     
        }, 
        error=> { alert(error.message);});   
    }

    //תביא מהשרת קטגוריה על ידי קוד
    getbycat(cat){
      //שכתובה בסרביס getToyByCat הבאת נתונים מהשרת על ידי פונקציה 
    this.toyservise.getToyByCat(cat).subscribe(
      myData => { this.products = myData; }, 
      error=> { alert(error.message);});
      
    }
   
 }
  























// <div *ngFor="let item of products"  class="css">
// <img [src]="item.picture" width="245px" height="240px" (click)="viewdetails(item)"/> 
// <p>{{item.nametoy}}</p>
// <input type="button" value="הוספה לסל" class="addtobag" (click)="addtobag(item)" *ngIf="currentUser!=undefined" > 
// </div>
    
// <br><br><br><br>
//  <a routerLink="/shoppingbag" class="s">🛒לצפיה בסל הקניות</a>
// <router-outlet></router-outlet> 