import { BasketModule } from './../basket/basket.module';
import { StepperComponent } from './../../shared/components/stepper/stepper.component';
import { CheckoutComponent } from './pages/checkout.component';
import { SharedModule } from './../../shared/shared.module';
import { CheckoutRoutingModule } from './checkout-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckoutReviewComponent } from './pages/checkout-review/checkout-review.component';
import { CheckoutDeliveryComponent } from './pages/checkout-delivery/checkout-delivery.component';
import { CheckoutAddressComponent } from './pages/checkout-address/checkout-address.component';
import { CheckoutPaymentComponent } from './pages/checkout-payment/checkout-payment.component';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { CheckoutSuccessComponent } from './pages/checkout-success/checkout-success.component';

@NgModule({
  declarations: [
    CheckoutComponent,
    CheckoutReviewComponent,
    CheckoutDeliveryComponent,
    CheckoutAddressComponent,
    CheckoutPaymentComponent,
    CheckoutSuccessComponent
  ],
  imports: [
    CommonModule,
    CheckoutRoutingModule,
    SharedModule,
    CdkStepperModule,
    BasketModule
  ]
})
export class CheckoutModule { }
