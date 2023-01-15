import { IProductType } from './../models/productTypes/product-type';

import { IPagination } from './../models/pagination';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, throwError } from 'rxjs';
import { IBrand } from '../models/productBrands/brand';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private url = 'https://localhost:7100/api/products'
  constructor(private http: HttpClient) {}

  public getProducts(brandId?: number, typeId?: number, sort?: string) {

    let params = new HttpParams();

    if (brandId) params = params.append('brandId', brandId.toString());
    if (typeId) params = params.append('typeId', typeId.toString());
    if (sort) params = params.append('sort', sort);

    let url  = this.url;
    return this.http.get<IPagination>(url + '?pageSize=50', {observe: 'response', params})
    .pipe(
      map(response => {
        return response.body
      })
      ,catchError((err) => throwError(() => err)));
  }

  public getBrands()
  {
    let url = `${this.url}/brands`;
    return this.http.get<IBrand>(url).pipe(catchError((err) => throwError(() => err)));
  }

  public getProductType()
  {
    let url = `${this.url}/types`;

    return this.http.get<IProductType>(url).pipe(catchError((err) => throwError(() => err)));
  }
}
