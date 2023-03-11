import { CheckoutComponent } from './pages/checkout.component';
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

const routes: Routes = [
  {
    path: '',
    data: {title: 'Checkout' },
    component: CheckoutComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CheckoutRoutingModule {}
