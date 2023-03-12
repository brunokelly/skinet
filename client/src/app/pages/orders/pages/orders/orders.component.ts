import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/pages/checkout/pages/services/models/order-to-create';
import { OrdersService } from '../../services/orders.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss'],
})
export class OrdersComponent implements OnInit {
  orders: Order[] = [];
  constructor(private orderService: OrdersService) {}
  ngOnInit(): void {
    this.getOrders();
  }
  getOrders() {
    this.orderService.getOrdersForUser().subscribe({
      next: (x) =>{
        this.orders.push(...x.items)
      },
    });
  }
}
