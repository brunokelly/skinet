import { BasketComponent } from './pages/basket.component';
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

const routes: Routes = [
  {
    path: '',
    data: {title: 'Basket' },
    component: BasketComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BasketRoutingModule {}
