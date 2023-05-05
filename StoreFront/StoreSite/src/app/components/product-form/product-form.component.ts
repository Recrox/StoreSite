import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import Product from 'src/app/models/Product';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.scss']
})
export class ProductFormComponent {
  constructor(private productService: ProductsService) {}

  onSubmit(form: NgForm) {
    console.log(form);
    console.log('yo la form?');
    this.addProduct();
  }

  newProduct: Product = {
    id: 0,
    name: 'newProductName',
    description: 'newDescriptionName',
  };

  addProduct() {
    this.productService.addProduct(this.newProduct);
  }
}
