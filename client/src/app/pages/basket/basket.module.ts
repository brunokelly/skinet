import { SharedModule } from './../../shared/shared.module';
import { BasketRoutingModule } from './basket-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketComponent } from './pages/basket.component';
import { BasketSummaryComponent } from './pages/basket-summary/basket-summary.component';



@NgModule({
  declarations: [
    BasketComponent,
    BasketSummaryComponent
  ],
  imports: [
    CommonModule,
    BasketRoutingModule,
    SharedModule
  ]
})
export class BasketModule { }
