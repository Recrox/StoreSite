import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import Product from '../models/Product';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  
  private apiProductUrl = 'https://localhost:7007/Product';

  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.apiProductUrl}/GetAll`)
  }

  getProduct(id: number): Observable<Product>{
    return this.http.get<Product>(`${this.apiProductUrl}/Get`);
  }

  addProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(`${this.apiProductUrl}/Add`, product);
  }

  removeProduct(productId: number): void{
    this.http.delete<void>(`${this.apiProductUrl}/Remove?id=${productId}`).subscribe();
  }
}


