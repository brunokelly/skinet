import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { IBasket } from '../models/interfaces/ibasket';
import { BasketService } from '../services/basket.service';
import { IBasketItem } from '../models/interfaces/ibasket-item';
import { IBasketTotals } from '../models/interfaces/ibasket-totals';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {
  basket$: Observable<IBasket>;
  basketTotals$: Observable<IBasketTotals>;

  constructor(private basketService: BasketService) { }

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
    this.basketTotals$ = this.basketService.basketTotal$;
  }

  removeBasketItem(item: IBasketItem) {
    this.basketService.removeItemFromBasket(item.id, 1);
  }

   incrementItemQuantity(item: IBasketItem) {
    //this.basketService.incrementItemQuantity(item);
   }

  decrementItemQuantity(item: IBasketItem) {
    //this.basketService.decrementItemQuantity(item);
   }
}
