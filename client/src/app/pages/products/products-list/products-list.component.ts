import { ProductParams } from './../models/product/product-params';
import { IProduct } from './../models/product/product';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss'],
})
export class ProductsListComponent implements OnInit {
  @Input () items: IProduct[];
  @Input() productParams = new ProductParams();
  @Output() pageChanged = new EventEmitter<number>();


  constructor() {}

  ngOnInit(): void {
  }

  onPageChanged(page: number)
  {
    this.productParams.pageNumber = page
    this.pageChanged.emit(page);
  }
}
