import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Product, ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
})
export class ProductsComponent {
  listProduct: any;
  pages: number = 1;

  constructor(private productService: ProductsService) {}
  newProduct: Product = {
    id: 0,
    name: 'newProductName',
    description: 'newDescriptionName',
  };

  addProduct() {
    this.productService.addProduct(this.newProduct);
  }

  removeProduct(id: number) {
    this.productService.removeProduct(id);
  }

  async ngOnInit() {
    const response = await GetAll();
    const data = await response.json();
    console.log(data);
    this.listProduct = data;
  }

  onSubmit(form: NgForm) {
    console.log(form);
    console.log('yo');
  }
}

async function GetAll() {
  return await fetch('https://localhost:7007/Product/GetAll');
}
