import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  private apiProductUrl = 'https://localhost:7007/Product';

  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.apiProductUrl}/GetAll`);
  }

  addProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(this.apiProductUrl, product);
  }

  removeProduct(productId: number, listProduct: Product[]) {
    this.http.delete(`${this.apiProductUrl}/Remove?id=${productId}`).pipe(
      tap(() => {
        // Mettre à jour la liste des produits après la suppression
        // listProduct = listProduct.filter(product=>product.id !== productId)
      })
    );
  }
}

export interface Product {
  id: number;
  name: string;
  description: string;
}
