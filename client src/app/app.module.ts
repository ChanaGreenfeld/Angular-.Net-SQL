import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { myRoutingModule } from './myRouting.module'
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HomePageComponent } from './Component/HomePage/home-page/home-page.component';
import { LoginComponent } from './Component/Login/login/login.component';
import { MenuComponent } from './Component/Menu/menu/menu.component';
import { EnterComponent } from './Component/Enter/enter/enter.component';
import { ViewProductComponent } from './Component/ViewProduct/view-product/view-product.component';
import { ProductDetailsComponent } from './Component/ProductDetails/product-details/product-details.component';
import { AddCategoryComponent } from './Component/AddCategory/add-category/add-category.component';
import { AddProductComponent } from './Component/AddProduct/add-product/add-product.component';
import { FinishComponent } from './Component/Finish/finish/finish.component';
import { ShoppingBagComponent } from './Component/ShoppingBag/shopping-bag/shopping-bag.component';
import { RouterModule } from '@angular/router';
import { ManagerComponent } from './Component/Manager/manager/manager.component';
import { ProdComponent } from '../app/Component/prod/prod.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    LoginComponent,
    MenuComponent,
    EnterComponent,
    ViewProductComponent,
    ProductDetailsComponent,
    AddCategoryComponent,
    AddProductComponent,
    FinishComponent,
    ShoppingBagComponent,
    ManagerComponent,
    ProdComponent,
    
  ],
  imports: [
    BrowserModule,RouterModule, myRoutingModule,HttpClientModule,FormsModule
  ],
  providers: [],
  entryComponents:[
    ProductDetailsComponent,
    LoginComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
