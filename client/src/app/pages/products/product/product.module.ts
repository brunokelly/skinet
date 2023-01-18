import { SharedModule } from './../../../shared/shared.module';


import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductComponent } from './product.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { ProductsCardComponent } from './products-card/products-card.component';
import { ProductsFilterComponent } from './products-filter/products-filter.component';
import { ProductsDetailComponent } from './products-detail/products-detail.component';

import { ProductRouting } from './product.routing';

@NgModule({
  declarations: [
    ProductComponent,
    ProductsListComponent,
    ProductsCardComponent,
    ProductsFilterComponent,
    ProductsDetailComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    ProductRouting,
  ]
})
export class ProductModule { }
