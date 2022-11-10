import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomePageComponent} from './Component/HomePage/home-page/home-page.component';
import{LoginComponent} from './Component/Login/login/login.component';
import{EnterComponent} from './Component/Enter/enter/enter.component';
import{ViewProductComponent} from './Component/ViewProduct/view-product/view-product.component';
import{ShoppingBagComponent} from './Component/ShoppingBag/shopping-bag/shopping-bag.component';
import{AddProductComponent} from './Component/AddProduct/add-product/add-product.component';
import{AddCategoryComponent} from './Component/AddCategory/add-category/add-category.component';
import{ProductDetailsComponent} from './Component/ProductDetails/product-details/product-details.component';
import { CommonModule } from '@angular/common';
import{FinishComponent} from './Component/Finish/finish/finish.component';
import {ManagerComponent} from './Component/Manager/manager/manager.component';

//טבלת ניתוב בין קומפוננטות
const  appRoutes:Routes = [
    {path:"",component:HomePageComponent},
    {path:"login",component:LoginComponent},
    {path:"productdetails",component:ProductDetailsComponent},
    {path:"enter",component:EnterComponent}, 
    {path:"viewproduct",component:ViewProductComponent},
    {path:"finish",component:FinishComponent}, 
    {path:"manager",component:ManagerComponent,
     children:[      
        {path:"addproduct",component:AddProductComponent},      
        {path:"addcategory",component:AddCategoryComponent},
        ]
    },
    {path:"shoppingbag",component:ShoppingBagComponent  },
];

@NgModule({
    imports:[RouterModule.forRoot(appRoutes), CommonModule],
    declarations:[]
})
export class myRoutingModule {}