import { BasketRoutingModule } from './basket-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketComponent } from './pages/basket.component';



@NgModule({
  declarations: [
    BasketComponent
  ],
  imports: [
    CommonModule,
    BasketRoutingModule
  ]
})
export class BasketModule { }
