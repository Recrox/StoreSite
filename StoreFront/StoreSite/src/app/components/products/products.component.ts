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
  pagesListe: number = 1;
  pagesTable: number = 1;

  constructor(private productService: ProductsService) {}
  newProduct: Product = {
    id: 0,
    name: 'newProductName',
    description: 'newDescriptionName',
  };

  removeProduct(id: number) {
    this.productService.removeProduct(id,this.listProduct);
    this.listProduct = this.listProduct.filter((p) => p.id !== id);
  }

  editProduct(id: number) {}

  detailsProduct(id: number) {}

  async ngOnInit() {
    const response = await GetAll();
    const data = await response.json();
    console.log(data);
    this.listProduct = data;
  }
}

async function GetAll() {
  return await fetch('https://localhost:7007/Product/GetAll');
}
