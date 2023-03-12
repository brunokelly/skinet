import { OrderResponse } from './../../checkout/pages/services/models/order-to-create';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Order } from "../../checkout/pages/services/models/order-to-create";

@Injectable({
  providedIn: 'root'
  })
  export class OrdersService {
  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }
  getOrdersForUser() {

  return this.http.get<OrderResponse>(this.baseUrl + 'orders');
  }
  getOrderDetailed(id: number) {
    return this.http.get<Order>(this.baseUrl + 'orders/' + id);
}
}

