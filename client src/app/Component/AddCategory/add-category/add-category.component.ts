import { Component, OnInit } from '@angular/core';
import{Category} from '../../../Classes/category';
import {CategoryService} from '../../../Servise/category.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {

  categorys:Array<Category>;
  private ids:number;

  constructor(private catser:CategoryService) { }

  ngOnInit(): void {
      //בעת טעינת הדף תציג את כל הקטגוריות
       //שכתובה בסרביס getCategory הבאת נתונים מהשרת על ידי פונקציה 
      this.catser.getCategory().subscribe(
      myData => { this.categorys = myData; }, 
      error=> { alert(error.message);});    
  }
  //הוספת קטגוריה
  onAdd(newcat){
    console.log(newcat)
      //שכתובה בסרביס addCategory הבאת נתונים מהשרת על ידי פונקציה 
    this.catser.addCategory(newcat).subscribe(
     list => { this.categorys = list; }, 
     err => { alert(err.message);})
     alert("ההוספה התבצעה בהצלחה!!!")
  }
//עריכת קטגוריה
    onEdit(id:number,newcat){ 
      console.log(id)  
      console.log(newcat)  
      //שכתובה בסרביס updateCategory הבאת נתונים מהשרת על ידי פונקציה 
    this.catser.updateCategory(id,newcat).subscribe(
      list => { this.categorys = list; }, 
      err => { alert(err.message);})
      alert("העידכון התבצע בהצלחה!!!")
  }
}
 
   