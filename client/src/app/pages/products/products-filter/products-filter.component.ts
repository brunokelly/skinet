import { NavbarComponent } from './../../../shared/components/navbar/navbar.component';
import { IProductTypeItem } from './../models/productTypes/product-type-item';
import { IBrandItem } from './../models/productBrands/brands-item';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IBrand } from '../models/productBrands/brand';

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

  brandIdSelected = 0;
  typeIdSelected = 0;
  sortTypeSelected: string;
  sortOptions = [
    {
      name: 'Alphabetical',
      value: 'name',
    },
    {
      name: 'Price: Low to High',
      value: 'priceAsc'
    },
    {
      name: 'Price: High to Low',
      value: 'priceDesc'
    }
  ];

  constructor() {}

  ngOnInit(): void {}

  onBrandSelected(brandId: number) {
    this.brandIdSelected = brandId;
    this.brandSelected.emit(brandId);
  }

  onTypeSelected(typeId: number) {
    this.typeIdSelected = typeId;
    this.typeSelected.emit(typeId);
  }

  onSortSelected(sort: string) {
    this.sortTypeSelected = sort;
    this.sortSelected.emit(sort);
  }
}
