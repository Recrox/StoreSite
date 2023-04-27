import { Component } from '@angular/core';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
})
export class ProductsComponent {
  listProduct: any;

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

async function Add(product: unknown) {
  await fetch('https://localhost:7007/Product/Add');
}

async function Remove(productId: number) {
  await fetch(`https://localhost:7007/Product/Remove?id=${productId}`);
}
