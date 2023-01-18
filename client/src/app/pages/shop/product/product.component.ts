import { IBrandItem } from './models/productBrands/brands-item';
import { IProductTypeItem } from './models/productTypes/product-type-item';

import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IProduct } from './models/product/product';
import { ProductService } from './services/product.service';
import { ProductParams } from './models/product/product-params';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  @ViewChild('search', {static: true}) searchTerm: ElementRef;

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

  public onSearch()
  {
    this.productParams.search = this.searchTerm.nativeElement.value;
    this.getProducts();
  }

  public onReset()
  {
    this.searchTerm.nativeElement.value = '';
    this.productParams = new ProductParams();
    this.getProducts();
  }
}
