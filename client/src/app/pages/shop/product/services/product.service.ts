import { environment } from './../../../../../environments/environment';
import { IProduct } from './../models/product/product';
import { ProductParams } from '../models/product/product-params';
import { IProductType } from '../models/productTypes/product-type';

import { IPagination } from '../models/product/pagination';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, throwError } from 'rxjs';
import { IBrand } from '../models/productBrands/brand';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private url = environment.baseUrl + 'products'

  constructor(private http: HttpClient) { }

  public getProducts(productParams?: ProductParams) {

    let params = this.formatFilter(productParams);

    let url = this.url;
    return this.http.get<IPagination>(url, { observe: 'response', params })
      .pipe(
        map(response => {
          return response.body
        })
        , catchError((err) => throwError(() => err)));
  }

  public getBrands() {
    let url = `${this.url}/brands`;
    return this.http.get<IBrand>(url).pipe(catchError((err) => throwError(() => err)));
  }

  public getProductType() {
    let url = `${this.url}/types`;
    return this.http.get<IProductType>(url).pipe(catchError((err) => throwError(() => err)));
  }

  public getProduct(id: number)
  {
    return this.http.get<IProduct>(this.url + `/${id}`);
  }

  private formatFilter(productParams: ProductParams): HttpParams
  {
    let params = new HttpParams();

    if (!productParams) return params;

    if (productParams.brandIdSelected !== 0) params = params.append('brandId', productParams.brandIdSelected.toString());
    if (productParams.typeIdSelected !== 0) params = params.append('typeId', productParams.typeIdSelected.toString());
    if (productParams.search) params = params.append('search', productParams.search);
    params = params.append('sort', productParams.sortSelected);
    params = params.append('pageIndex', productParams.pageNumber.toString());
    params = params.append('pageSize', productParams.pageSize.toString());

    return params;
  }
}
