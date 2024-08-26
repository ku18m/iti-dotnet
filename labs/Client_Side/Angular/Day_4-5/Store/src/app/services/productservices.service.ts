import { Injectable, OnDestroy, OnInit } from '@angular/core';
import { IProduct } from '../models/iproduct';
import { PRODUCTS } from '../models/productsList';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService implements OnInit, OnDestroy{
  apiURL = 'http://localhost:3000/products';
  subscribtions: any[] = [];
  products : IProduct[];
  constructor(private http: HttpClient) {
    this.products = PRODUCTS;
  }
  ngOnInit(): void {
    let subscribtion = this.getProducts().subscribe({
      next: (products) => {
        this.products = products;
      },
      error: (err) => {
        console.error(err);
      }
    });

    this.subscribtions.push(subscribtion);
  }
  ngOnDestroy(): void {
    this.subscribtions.forEach(subscribtion => {
      subscribtion.unsubscribe();
    });
  }

  getProducts() {
    return this.http.get<IProduct[]>(this.apiURL);
  }

  getProduct(id: string) {
    return this.http.get<IProduct>(`${this.apiURL}/${id}`);
  }

  addProduct(product: IProduct) {
    let productDTO = {
      name: product.name,
      price: product.price,
      quantity: product.quantity
    }

    let response = this.http.post(this.apiURL, productDTO);

    // this.ngOnInit();

    return response;
  }

  updateProduct(product: IProduct) {
    return this.http.put(`${this.apiURL}/${product.id}`, product);
  }

  removeProduct(id: string) {
    return this.http.delete(`${this.apiURL}/${id}`);
  }
}
