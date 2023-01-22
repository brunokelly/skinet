import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/navbar/navbar.component';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { SectionHeaderComponent } from './components/section-header/section-header.component';
import { BreadcrumbModule } from 'xng-breadcrumb';
import { OrderTotalsComponent } from './components/order-totals/order-totals.component'

@NgModule({
  declarations: [
    NavbarComponent,
    PagingHeaderComponent,
    PaginationComponent,
    SectionHeaderComponent,
    OrderTotalsComponent
  ],
  imports: [
    CommonModule,
    NgbPaginationModule,
    RouterModule,
    BreadcrumbModule
  ],
  exports: [
    NavbarComponent,
    PagingHeaderComponent,
    PaginationComponent,
    SectionHeaderComponent,
    OrderTotalsComponent
  ]
})
export class SharedModule { }
