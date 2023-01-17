import { IProduct } from './../models/product/product';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-products-card',
  templateUrl: './products-card.component.html',
  styleUrls: ['./products-card.component.scss']
})
export class ProductsCardComponent implements OnInit {
  @Input () item: IProduct;
  constructor() { }

  ngOnInit(): void {
  }

}
