import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ImageComponent } from './components/image/image.component';
import { ProductsComponent } from './components/products/products.component';

import { FormsModule } from '@angular/forms'; // Ajout de cette ligne
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [AppComponent, ImageComponent, ProductsComponent],
  imports: [BrowserModule, AppRoutingModule, FormsModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
