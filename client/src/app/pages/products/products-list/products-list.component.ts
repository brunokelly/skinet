import { IPagination } from './../models/pagination';
import { ProductService } from './../services/product.service';
import { IProduct } from './../models/product';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss'],
})
export class ProductsListComponent implements OnInit {
  public items: IProduct[] = [];
  constructor(private productSerivce: ProductService) {}

  ngOnInit(): void {
    this.getProducts()
  }

  public getProducts()
  {
    this.productSerivce.getProducts()
    .subscribe({
      next: x => this.convertToListProduct(x),
    }
    );
  }

  convertToListProduct(pagination: IPagination)
  {
    this.items = pagination.data.data;
  }
}
