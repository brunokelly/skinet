import { IProduct } from '../models/product/product';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent implements OnInit {
  @Input () item: IProduct;
  constructor() { }

  ngOnInit(): void {
  }

}
