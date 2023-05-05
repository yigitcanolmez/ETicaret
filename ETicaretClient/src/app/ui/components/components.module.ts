import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsModule as UiProduct } from './products/products.module';
import { HomeModule } from './home/home.module';
import { BasketModule } from './basket/basket.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    UiProduct,
    HomeModule,
    BasketModule
  ]
})
export class ComponentsModule { }
