import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import Product from 'src/app/models/Product';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: Product = {
    id: 0,
    name: 'default_name',
    description: null,
    price: 10,
    image: null,
  };

  constructor(private productService: ProductsService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.product.id = params['id'];
      this.initProduct();
    });
  }

  initProduct(): void {
    this.productService.getProduct(this.product.id).subscribe(productToGet => {
      this.product = productToGet;
    });
  }

  getImageUrl(){
    
  }
}

