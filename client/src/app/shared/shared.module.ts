import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/navbar/navbar.component';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    NavbarComponent,
    PagingHeaderComponent,
    PaginationComponent
  ],
  imports: [
    CommonModule,
    NgbPaginationModule
  ],
  exports: [
    NavbarComponent,
    PagingHeaderComponent,
    PaginationComponent
  ]
})
export class SharedModule { }
