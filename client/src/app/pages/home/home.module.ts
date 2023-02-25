import { SharedModule } from './../../shared/shared.module';
import { HomeRouting } from './home.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { BreadcrumbModule } from 'xng-breadcrumb';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    HomeRouting,
    BreadcrumbModule,
    SharedModule
  ],
  exports: []
})
export class HomeModule { }
