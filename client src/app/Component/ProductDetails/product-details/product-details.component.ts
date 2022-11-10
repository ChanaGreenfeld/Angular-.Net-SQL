import { style } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import {Detail} from '../../../Classes/detail';
//import {DetailsService} from '../../../Servise/details.service';
import {ToysService} from '../../../Servise/toys.service';


@Component({
  selector:'app-product-details',
  templateUrl:'./product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  enternewUser:Detail=new Detail(0,"","",0,0,"");
  det:Detail



  constructor(private details:ToysService) { }

ngOnInit(): void { 
  //תשמור את המשחק הנוכחי
  this.det=this.details.getcurrentToy()
  console.log(this.det);
 
  }

  //תחזור לחלון האחרון בו היית
  back(){
    window.history.back();
  }

}
