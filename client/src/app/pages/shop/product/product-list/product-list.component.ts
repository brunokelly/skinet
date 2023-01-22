import { ProductParams } from '../models/product/product-params';
import { IProduct } from '../models/product/product';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss'],
})
export class ProductListComponent implements OnInit {
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
