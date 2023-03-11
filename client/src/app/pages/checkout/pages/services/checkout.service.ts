import { map, Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { DeliveryMethod } from '../models/delivery-method';
import { Order, OrderToCreate } from './models/order-to-create';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {

  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  createOrder(order: OrderToCreate) {
    return this.http.post<Order>(this.baseUrl + 'orders', order);
  }

  getDeliveryMethods() {
    return this.http.get<DeliveryMethod>(this.baseUrl + 'orders/deliveryMethods').pipe(
      map(dm => {
        console.log(dm)
        return dm.items.sort((a, b) => b.price - a.price)
      })
    )
  }
}
