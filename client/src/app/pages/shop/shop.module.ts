import { BreadcrumbModule } from 'xng-breadcrumb';
import { ShopRoutingModule } from './shop-routing.module';
import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './product/product.component';
import { ProductFilterComponent } from './product/product-filter/product-filter.component';
import { ProductListComponent } from './product/product-list/product-list.component';
import { ProductDetailComponent } from './product/product-detail/product-detail.component';
import { ProductCardComponent } from './product/product-card/product-card.component';

@NgModule({
  declarations: [
    ProductComponent,
    ProductListComponent,
    ProductCardComponent,
    ProductFilterComponent,
    ProductDetailComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    ShopRoutingModule,
    BreadcrumbModule
  ]
})
export class ShopModule { }
