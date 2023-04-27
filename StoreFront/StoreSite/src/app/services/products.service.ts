import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  private apiProductUrl = 'https://localhost:7007/Product';

  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.apiProductUrl}/GetAll`);
  }

  getPrloducts(): Observable<Product[]> {
    return this.http.get<Product[]>('');
  }

  addProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(this.apiProductUrl, product);
  }

  removeProduct(productId: number) {
    return this.http
      .delete(`${this.apiProductUrl}/Remove?id=${productId}`)
      .subscribe(
        (response) => console.log(response),
        (error) => console.log(error)
      );
  }
}

export interface Product {
  id: number;
  name: string;
  description: string;
}
