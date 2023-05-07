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

  addProduct(product: Product){
    this.http.post<Product>(`${this.apiProductUrl}/Add`, product).subscribe(
      value=>{
        console.log(value);
      },
      err =>{
        console.log(err);
      }
    );
  }

  removeProduct(productId: number): void{
    this.http.delete<void>(`${this.apiProductUrl}/Remove?id=${productId}`).subscribe();
  }

  updateProduct(product: Product){
    this.http.put<void>(`${this.apiProductUrl}/Update`, product);
  }
}


