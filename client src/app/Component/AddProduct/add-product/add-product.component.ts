import { Component, OnInit } from '@angular/core';
import { ToysService } from '../../../Servise/toys.service';
import { Detail } from '../../../Classes/detail';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  addbool: boolean = false
  products: Array<Detail>;
  newtoy: Detail = new Detail(0, "", "", 0, 0, "../../../../assets/menu.jpg")
  editbool: boolean = false
  edittoy: Detail = new Detail(0, "", "", 0, 0, "")
  id: number

  constructor(private toyserv: ToysService) { }


  ngOnInit(): void {
    //בעת טעינת הדף תציג את כל המוצרים
    //שכתובה בסרביס getToy הבאת נתונים לשרת על ידי פונקציה 
    this.toyserv.getToy().subscribe(
      myData => { this.products = myData; },
      error => { alert(error.message); });
  }
  //מחיקת מוצר
  delete(product) {
    //שכתובה בסרביס deleteToy מחיקת נתונים לשרת על ידי פונקציה 
    this.toyserv.deleteToy(product.codetoy).subscribe(
      list => { this.products = list; },
      err => { alert(err.message); })
  }
  //פונקציות עזר לתצוגת אפשרות הוספה/עדכון
  add() {
    this.editbool = false
    this.addbool = true
  }
  //פונקציות עזר לתצוגת אפשרות הוספה/עדכון
  edit() {
    this.addbool = false
    this.editbool = true
  }
  //הוספת מוצר
  onSubmit() {
    //שכתובה בסרביס addToy הוספת נתונים לשרת על ידי פונקציה 
    this.toyserv.addToy(this.newtoy).subscribe(
      myData => {
        this.products = myData;
        alert("ההוספה התבצעה בהצלחה!!!")
      },
      error => { alert(error.message); });
    this.addbool = false
  }
  //עריכת מוצר
  onSubmit2() {
    //שכתובה בסרביס updateToy הבאת נתונים מהשרת על ידי פונקציה 
    this.toyserv.updateToy(this.id, this.newtoy).subscribe(
      myData => {
        this.products = myData;
        alert("העידכון התבצעה בהצלחה!!!")
      },
      error => { alert(error.message); });
    this.editbool = false
  }



}
