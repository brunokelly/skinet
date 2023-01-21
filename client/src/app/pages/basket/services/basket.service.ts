import { IProduct } from './../../shop/product/models/product/product';
import { IBasketResponse } from './../models/interfaces/ibasket-response';
import { IBasket } from './../models/interfaces/ibasket';
import { environment } from './../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { IBasketItem } from '../models/interfaces/ibasket-item';
import { Basket } from '../models/basket';
@Injectable({
  providedIn: 'root'
})
export class BasketService {
  private baseUrl = environment.baseUrl + "basket";
  private basketSource = new BehaviorSubject<IBasket>(null)
  public basket$ = this.basketSource.asObservable();

  constructor(private http: HttpClient) { }

  public getBasket(id: string)
  {
    return this.http.get(this.baseUrl + `?id=${id}`)
    .pipe
    (
      map((basket: IBasketResponse) => {
        this.basketSource.next(basket.items)
      })
    )
  }

  public addItemToBasket(item: IProduct, quantity = 1)
  {
    const itemToAdd: IBasketItem = this.mapProductItemToBasketItem(item, quantity);
    const basket = this.getCurrentBasketValue() ?? this.createBasket();
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity)
    this.setBasket(basket)
  }

  private getCurrentBasketValue()
  {
    return this.basketSource.value;
  }

  private setBasket(basket: IBasket)
  {
    return this.http.post(this.baseUrl + '', basket).subscribe
    ({
      next: (response: IBasketResponse) => { this.basketSource.next(response.items) },
      error: x => console.log(x)
    })
  }

  private addOrUpdateItem(items: IBasketItem[], itemToAdd: IBasketItem, quantity: number): IBasketItem[] {
    const index = items.findIndex(i => i.id === itemToAdd.id);

    if(index === -1)
    {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    } else {
      items[index].quantity += quantity;
    }

    return items;
  }

  private createBasket(): Basket {
    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  private mapProductItemToBasketItem(item: IProduct, quantity: number): IBasketItem {
    return {
      id: item.id,
      productName: item.name,
      price: item.price,
      pictureUrl: item.pictureUrl,
      quantity,
      brand: item.productBrand,
    }
  }
}
