import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ProductComponent } from "./product/product.component";
import { ProductDetailComponent } from "./product/product-detail/product-detail.component";

const routes: Routes = [
  {
    path: '',
    data: {title: 'Product'},
    component: ProductComponent,
    children: [
    ]
  },
  {
    path: ':id',
    data: {title: 'View Product'},
    component: ProductDetailComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ShopRoutingModule {}
