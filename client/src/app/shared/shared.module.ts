import { BusyService } from './services/busy.service';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/navbar/navbar.component';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { SectionHeaderComponent } from './components/section-header/section-header.component';
import { BreadcrumbModule } from 'xng-breadcrumb'

@NgModule({
  declarations: [
    NavbarComponent,
    PagingHeaderComponent,
    PaginationComponent,
    SectionHeaderComponent
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
    SectionHeaderComponent
  ]
})
export class SharedModule { }
