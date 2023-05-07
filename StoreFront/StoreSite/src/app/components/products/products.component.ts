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

  constructor(private productService: ProductsService) {}

  removeProduct(productId: number) {
    this.productService.removeProduct(productId);
    this.listProduct = this.listProduct.filter((p) => p.id !== productId);
  }

  editProduct(productId: number) {}

  detailsProduct(productId: number) {
    this.productService.getProduct(productId);
  }

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
    );;
  }
}