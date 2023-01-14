import { IPagination } from './../models/pagination';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private url = 'https://localhost:7100/api/products'
  constructor(private http: HttpClient) {}

  public getProducts() {
    return this.http.get<IPagination>(this.url)
    .pipe(catchError((err) => throwError(() => err)));
  }
}
