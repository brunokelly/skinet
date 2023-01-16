import { IBrandItem } from './models/productBrands/brands-item';
import { IProductTypeItem } from './models/productTypes/product-type-item';

import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/product/pagination';
import { IProduct } from './models/product/product';
import { ProductService } from './services/product.service';
import { IPaginationData } from 'src/app/shared/models/pagination-data';
import { ProductParams } from './models/product/product-params';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  public items: IProduct[] = [];
  public brands: IBrandItem[] = [];
  public productsType: IProductTypeItem[] = [];

  public productParams = new ProductParams();
  public totalCount: number;


  constructor(private productSerivce: ProductService) { }

  ngOnInit(): void {
    this.getProducts()
    this.getProductsType()
    this.getBrands();
  }

  public getProducts()
  {
    this.productSerivce.getProducts(this.productParams)
    .subscribe({
      next: response => {
        this.items = response.data;
        this.productParams.pageNumber = response.pageIndex;
        this.productParams.pageSize = response.pageSize;
        this.productParams.totalCount = response.count;
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
    this.productParams.typeIdSelected = typeId;
    this.getProducts();
  }

  public brandFilter(brandId: number)
  {
    this.productParams.brandIdSelected = brandId;
    this.getProducts();
  }

  public sortFilter(sort: string)
  {
    this.productParams.sortSelected = sort;
    this.getProducts();
  }

  public pageChange(page: number)
  {
    this.productParams.pageNumber =  page ?? 1;
    this.getProducts();
  }
}
