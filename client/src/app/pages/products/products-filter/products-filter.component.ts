import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { IProductTypeItem } from './../models/productTypes/product-type-item';
import { IBrandItem } from './../models/productBrands/brands-item';
import { ProductParams } from '../models/product/product-params';

@Component({
  selector: 'app-products-filter',
  templateUrl: './products-filter.component.html',
  styleUrls: ['./products-filter.component.scss'],
})
export class ProductsFilterComponent implements OnInit {
  @Input() brands: IBrandItem[] = [];
  @Input() productsType: IProductTypeItem[] = [];
  @Output() brandSelected = new EventEmitter<number>();
  @Output() typeSelected = new EventEmitter<number>();
  @Output() sortSelected = new EventEmitter<string>();

  productParams = new ProductParams();
  sortOptions = [
    {
      name: 'Alphabetical',
      value: 'name',
    },
    {
      name: 'Price: Low to High',
      value: 'priceAsc',
    },
    {
      name: 'Price: High to Low',
      value: 'priceDesc',
    },
  ];

  constructor() {}

  ngOnInit(): void {}

  onBrandSelected(brandId: number) {
    this.productParams.brandIdSelected = brandId;
    this.brandSelected.emit(brandId);
  }

  onTypeSelected(typeId: number) {
    this.productParams.typeIdSelected = typeId;
    this.typeSelected.emit(typeId);
  }

  onSortSelected(sort: string) {
    this.productParams.sortSelected = sort;
    this.sortSelected.emit(sort);
  }
}
