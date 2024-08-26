import { Component, OnDestroy, OnInit } from '@angular/core';
import { ProductCardComponent } from "./product-card/product-card.component";
import { ActivatedRoute } from '@angular/router';
import { IProduct } from '../../../models/iproduct';
import { ProductService } from '../../../services/productservices.service';

@Component({
  selector: 'app-product-details',
  standalone: true,
  imports: [ProductCardComponent],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent implements OnInit, OnDestroy {
  subscribtions: any[] = [];
  product: IProduct = {
    id: '0',
    name: '',
    price: 0,
    quantity: 0
  };
  constructor(private activatedRoute: ActivatedRoute, private productServices: ProductService) {
    this.activatedRoute = activatedRoute;
    this.productServices = productServices;
  }
  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get('id') || '0';
    let subscription = this.productServices.getProduct(id).subscribe(
      {
        next: (product) => {
          this.product = product;
        },
        error: (err) => {
          console.error(err);
      }
    });

    this.subscribtions.push(subscription);
  }

  ngOnDestroy(): void {
    this.subscribtions.forEach(subscribtion => {
      subscribtion.unsubscribe();
    });
  }
}
