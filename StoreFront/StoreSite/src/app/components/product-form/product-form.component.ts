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

  newProduct: Product = {
    id: 0,
    name: 'newProductName',
    description: 'newDescriptionName',
    price:10,
  };

  addProduct() {
    this.productService.addProduct(this.newProduct).subscribe(
      newProduct => {
        console.log(`Product ${newProduct.id} added successfully.`);
        // Gérer la réponse ici
      },
      error => {
        console.log(`Error adding product: ${error}`);
        // Gérer l'erreur ici
      }
    );
  }

  onFileSelected(event: any) {
    // Sélectionner le fichier
  }
}
