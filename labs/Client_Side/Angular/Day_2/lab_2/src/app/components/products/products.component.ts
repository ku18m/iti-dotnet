import { Component } from '@angular/core';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {
  products: Product[] = [
    new Product('Laptop', 1000, 10),
    new Product('Mouse', 20, 50),
    new Product('Keyboard', 50, 30),
    new Product('Monitor', 200, 0),
    new Product('Rashid', 200, 1),
  ];
}


class Product {
  constructor(public name: string, public price: number, public quantity: number, public img: string = 'https://via.placeholder.com/150') {
  }
}