import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import Product from 'src/app/models/Product';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
})
export class ProductsComponent {
  listProduct: Product[] = [];
  pagesListe: number = 0;
  pagesTable: number = 0;

  constructor(private productService: ProductsService) {}

  removeProduct(id: number) {
    this.productService.removeProduct(id,this.listProduct);
    this.listProduct = this.listProduct.filter((p) => p.id !== id);
  }

  editProduct(id: number) {}

  detailsProduct(id: number) {}

  ngOnInit() {
    this.getProduct();
  }

  private getProduct() {
    this.productService.getProducts().subscribe(
      products => {
        this.listProduct = products;
      },
      error => {
        console.log(error);
      }
    );
  }
}

async function GetAll() {
  return await fetch('https://localhost:7007/Product/GetAll');
}
