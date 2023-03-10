import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbDropdownModule, NgbPaginationModule, NgbCarouselModule } from '@ng-bootstrap/ng-bootstrap';
import { BreadcrumbModule } from 'xng-breadcrumb';
import { ReactiveFormsModule } from '@angular/forms';
import {CdkStepperModule} from '@angular/cdk/stepper'
import { NavbarComponent } from './components/navbar/navbar.component';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { SectionHeaderComponent } from './components/section-header/section-header.component';
import { OrderTotalsComponent } from './components/order-totals/order-totals.component'
import { TextInputComponent } from './components/text-input/text-input.component';
import { StepperComponent } from './components/stepper/stepper.component';

@NgModule({
  declarations: [
    NavbarComponent,
    PagingHeaderComponent,
    PaginationComponent,
    SectionHeaderComponent,
    OrderTotalsComponent,
    TextInputComponent,
    StepperComponent
  ],
  imports: [
    CommonModule,
    NgbPaginationModule,
    RouterModule,
    BreadcrumbModule,
     ReactiveFormsModule,
     NgbDropdownModule,
     NgbCarouselModule,
     CdkStepperModule
  ],
  exports: [
    NavbarComponent,
    PagingHeaderComponent,
    PaginationComponent,
    SectionHeaderComponent,
    OrderTotalsComponent,
    ReactiveFormsModule,
    TextInputComponent,
    NgbDropdownModule,
    NgbCarouselModule,
    StepperComponent,
  ]
})
export class SharedModule { }
