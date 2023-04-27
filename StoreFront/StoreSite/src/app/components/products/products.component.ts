import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
})
export class ProductsComponent {
  listProduct: any;

  newProduct: Product = {
    id: 0,
    name: 'newProductName',
    description: 'newDescriptionName',
  };

  addProductParent() {
    this.addProduct(this.newProduct);
  }

  private apiProductUrl = 'https://localhost:7007/Product';

  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiProductUrl);
  }

  addProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(this.apiProductUrl, product);
  }

  removeProduct(productId: number): Observable<any> {
    return this.http.delete(`${this.apiProductUrl}/Remove?id=${productId}`);
  }

  async ngOnInit() {
    const response = await GetAll();
    const data = await response.json();
    console.log(data);
    this.listProduct = data;
  }

  // remove(productId: number) {
  //   fetch(`https://localhost:7007/Product/Remove?id=${productId}`, {
  //     method: 'DELETE',
  //   })
  //     .then((res) => console.log(res))
  //     .catch((err) => console.error(err));
  // }

  onSubmit(form: NgForm) {
    console.log(form);
    console.log('yo');
  }
}

async function GetAll() {
  return await fetch('https://localhost:7007/Product/GetAll');
}

export interface Product {
  id: number;
  name: string;
  description: string;
}

export class ProductService {}
