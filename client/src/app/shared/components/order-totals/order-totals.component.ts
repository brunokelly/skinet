import { Component, Input, OnInit } from '@angular/core';
import { BasketService } from 'src/app/pages/basket/services/basket.service';

@Component({
  selector: 'app-order-totals',
  templateUrl: './order-totals.component.html',
  styleUrls: ['./order-totals.component.scss']
})
export class OrderTotalsComponent  {
  constructor(public basketService: BasketService){}

}
