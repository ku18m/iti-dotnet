import { Component } from '@angular/core';
import { IProduct } from '../Models/iproduct';
import { ProductsList } from '../Models/productsList';
import { ProductCardComponent } from './product-card/product-card.component';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [ProductCardComponent],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css',
})
export class ProductsComponent {
  products: IProduct[] = ProductsList;

  removeProduct(id: number) {
    this.products = this.products.filter(p => p.id !== id);
  }

  discountProduct(id: number) {
    for(let i = 0; i < this.products.length; i++) {
      if(this.products[i].id === id) {
        this.products[i] = {...this.products[i], price: this.products[i].price * .8};
      }
    }
  }
}
