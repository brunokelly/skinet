import { DeliveryMethodItem } from './../models/delivery-method';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BasketService } from 'src/app/pages/basket/services/basket.service';
import { DeliveryMethod } from '../models/delivery-method';
import { CheckoutService } from '../services/checkout.service';

@Component({
  selector: 'app-checkout-delivery',
  templateUrl: './checkout-delivery.component.html',
  styleUrls: ['./checkout-delivery.component.scss']
})
export class CheckoutDeliveryComponent implements OnInit {

  @Input() checkoutForm?: FormGroup;
  deliveryMethods: DeliveryMethod = new DeliveryMethod();

  constructor(private checkoutService: CheckoutService, private basketService: BasketService) {}

  ngOnInit(): void {
    this.checkoutService.getDeliveryMethods().subscribe({
      next: dm => this.deliveryMethods.items.push(...dm)
    })
  }

  setShippingPrice(deliveryMethod: DeliveryMethodItem) {
    this.basketService.setShippingPrice(deliveryMethod);
  }
}
