import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/Classes/category';
import { Customer } from 'src/app/Classes/customer';
import { Detail } from 'src/app/Classes/detail';
import { Shoppingbag } from 'src/app/Classes/shoppingbag';
import { CategoryService } from 'src/app/Servise/category.service';
import { ToysService } from 'src/app/Servise/toys.service';
import { UsersService } from 'src/app/Servise/users.service';
import { ShoppingbagService } from 'src/app/Servise/shoppingbag.service';


@Component({
  selector: 'app-prod',
  templateUrl: './prod.component.html',
  styleUrls: ['./prod.component.css']
})
export class ProdComponent implements OnInit {

  products: Array<Detail>;
  currentUser: Customer;
  categorys: Array<Category>;
  yes:boolean=false
  nowtoy:Shoppingbag
 

  constructor(private toyservise: ToysService, private router: Router, private userServ: UsersService,private shbServise: ShoppingbagService) { }

  ngOnInit(): void {
    this.currentUser = this.userServ.user
  }
  @Input("my-prod") myProd: Detail;

    //הצגת המוצר ופרטיו
    viewdetails() {
      //תשמור את המשחק הנוכחי
      this.toyservise.setcurrentToy(this.myProd)
      //תפתח את פרטי המשחק
      this.router.navigate(["/productdetails"]);
    }
//הצגת כל המוצרים
    all() {
      //שכתובה בסרביס getToy הבאת נתונים מהשרת על ידי פונקציה 
      this.toyservise.getToy().subscribe(
        myData => {this.products = myData;},
        error => { alert(error.message); });
    }
//הוספה לסל הקניות שנמצא בסרביס
    addtobag() {
      this.yes=true
      console.log(this.myProd.codetoy);      
      this.shbServise.addbag(this.myProd)    
    // alert("!!!הפריט התווסף בהצלחה")
    }

}
