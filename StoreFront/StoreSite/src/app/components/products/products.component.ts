import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
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

  constructor(private productService: ProductsService,private router: Router) {}

  ngOnInit() {
    this.getProduct();
  }
  
  removeProduct(productId: number) {
    this.productService.removeProduct(productId);
    this.listProduct = this.listProduct.filter((p) => p.id !== productId);
  }

  editProduct(productId: number) {}

  detailsProduct(productId: number) {
    this.router.navigate(['/app-product-details'], { queryParams: { id: productId } });
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