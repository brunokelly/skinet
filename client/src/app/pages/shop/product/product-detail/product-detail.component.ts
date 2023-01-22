import { IProduct } from './../models/product/product';
import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from 'src/app/pages/basket/services/basket.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss'],
})
export class ProductDetailComponent implements OnInit {
  product: IProduct;
  quantity = 1;
  constructor(
    private productService: ProductService,
    private activatedRoute: ActivatedRoute,
    private breadcrumbService: BreadcrumbService,
    private basketService: BasketService
  ) {}

  ngOnInit(): void {
    this.getProduct();
  }

  getProduct() {
    this.productService
      .getProduct(+this.activatedRoute.snapshot.paramMap.get('id'))
      .subscribe({
        next: (response) => this.loadProduct(response),
      });
  }

  private loadProduct(product: IProduct)
  {
    if (!product) return;

    this.product = product;
    this.breadcrumbService.set('@productDetails', product.name)
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.product, this.quantity);
  }

  incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }
}
