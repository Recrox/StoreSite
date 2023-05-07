import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ProductsComponent} from './components/products/products.component'
import { ProductFormComponent } from './components/product-form/product-form.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';

const routes: Routes = [
  { path: '', component:ProductsComponent},
  { path: 'products-component', component: ProductsComponent },
  { path: 'product-form-component', component: ProductFormComponent },
  { path: 'app-product-details', component: ProductDetailsComponent }, 
  { path: '**', component: PageNotFoundComponent }, 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
