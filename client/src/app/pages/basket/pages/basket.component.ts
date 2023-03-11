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
export class BasketComponent {
  basket$: Observable<IBasket>;
  basketTotals$: Observable<IBasketTotals>;

  constructor(public basketService: BasketService) {}

  incrementQuantity(item: IBasketItem) {
    this.basketService.addItemToBasket(item);
  }

  removeItem(event: {id: number, quantity: number}) {
    this.basketService.removeItemFromBasket(event.id, event.quantity);
  }
}
