import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import Product from 'src/app/models/Product';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.scss']
})
export class ProductFormComponent {
  constructor(private productService: ProductsService) {}

  product: Product = {
    id: 0,
    name: 'newProductName',
    description: 'newDescriptionName',
    price:10,
    image:null,
  };

  addProduct() {
    if (this.product.id === 0) {//Create
      this.productService.addProduct(this.product);
    }
    else{//Update
      this.productService.updateProduct(this.product);
    }

  }

  onFileSelected(event: any) {
    // Sélectionner le fichier
    console.log(event);
    
  }
}
