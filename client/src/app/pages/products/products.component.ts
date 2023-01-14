import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/pagination';
import { IProduct } from './models/product';
import { ProductService } from './services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  public items: IProduct[] = [];
  constructor(private productSerivce: ProductService) { }

  ngOnInit(): void {
    this.getProducts()
  }

  public getProducts()
  {
    this.productSerivce.getProducts()
    .subscribe({
      next: x => this.convertToListProduct(x),
      error: x => console.log(x)
    }
    );
  }

  convertToListProduct(pagination: IPagination)
  {
    this.items = pagination.data.data;
  }
}
