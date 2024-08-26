import { Component, OnDestroy, OnInit } from '@angular/core';
import { ProductService } from '../../services/productservices.service';
import { IProduct } from '../../models/iproduct';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit, OnDestroy {
  subscriptions: any[] = [];
  products?: IProduct[];
  constructor(private productServices: ProductService) {
    this.productServices = productServices;
  }
  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => {
      subscription.unsubscribe();
    });
  }

  ngOnInit(): void {
    this.productServices.getProducts().subscribe(
      {
        next: (products) => {
          this.products = products;
        },
        error: (err) => {
          console.error(err);
        }
      }
    );
  }

  removeProduct(id: string) {
    let subscription = this.productServices.removeProduct(id).subscribe(
      {
        next: () => {
          this.products = this.products?.filter(product => product.id !== id);
        },
        error: (err) => {
          console.error(err);
        }
      }
    );

    this.subscriptions.push(subscription);
  }
}
