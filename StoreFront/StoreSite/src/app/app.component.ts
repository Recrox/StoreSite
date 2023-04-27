import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  listProduct: any;
  title = 'StoreSite';

  async ngOnInit() {
    const response = await GetAll();
    const data = await response.json();
    console.log(data);

    this.listProduct = data;
  }
}

async function GetAll() {
  return await fetch("https://localhost:7007/Product/GetAll");
}

async function Add(product: unknown) {
  await fetch("https://localhost:7007/Product/Add");
}