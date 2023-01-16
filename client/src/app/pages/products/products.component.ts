import { IBrandItem } from './models/productBrands/brands-item';
import { IProductTypeItem } from './models/productTypes/product-type-item';

import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/pagination';
import { IProduct } from './models/product';
import { ProductService } from './services/product.service';
import { IPaginationData } from 'src/app/shared/models/pagination-data';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  public items: IProduct[] = [];
  public brands: IBrandItem[] = [];
  public productsType: IProductTypeItem[] = [];

  public brandSelected: number;
  public typeSelected: number;
  public sortTypeSelected: string;
  public paginationData: IPaginationData;


  constructor(private productSerivce: ProductService) { }

  ngOnInit(): void {
    this.getProducts()
    this.getProductsType()
    this.getBrands();
  }

  public getProducts()
  {
    this.productSerivce.getProducts(this.brandSelected, this.typeSelected, this.sortTypeSelected)
    .subscribe({
      next: response => {
        this.paginationData = {
            page: response.pageIndex,
            pageSize: response.pageSize,
            collectioSize: response.count
        }
        this.items = response.data
      },
      error: x => console.log(x),
    }
    );
  }

  public getBrands()
  {
    this.productSerivce.getBrands()
    .subscribe({
      next: response => this.brands = [{id: 0, name: 'All'}, ...response.items],
      error: x => console.log(x)
    }
    );
  }

  public getProductsType()
  {
    this.productSerivce.getProductType()
    .subscribe({
      next: response => this.productsType = [{id: 0, name: 'All'}, ...response.items],
      error: x => console.log(x)
    }
    );
  }

  public productTypeFilter(typeId: number)
  {
    this.typeSelected = typeId;
    this.getProducts();
  }

  public brandFilter(brandId: number)
  {
    this.brandSelected = brandId;
    this.getProducts();
  }

  public sortFilter(sort: string)
  {
    this.sortTypeSelected = sort;
    this.getProducts();
  }
}
