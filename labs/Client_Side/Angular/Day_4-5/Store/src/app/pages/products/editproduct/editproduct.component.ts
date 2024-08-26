import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { IProduct } from '../../../models/iproduct';
import { ProductService } from '../../../services/productservices.service';

@Component({
  selector: 'app-editproduct',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './editproduct.component.html',
  styleUrl: './editproduct.component.css',
})
export class EditproductComponent implements OnDestroy, OnInit {
  subscriptions: any[] = [];
  productForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.minLength(3)]),
    price: new FormControl(0, [Validators.required, Validators.min(1)]),
    quantity: new FormControl(0, [Validators.required, Validators.min(1)]),
  });
  product: IProduct = {
    id: '0',
    name: '',
    price: 0,
    quantity: 0,
  };
  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private router: Router
  ) {
    this.route = route;
    this.productService = productService;
    this.router = router;
  }
  ngOnDestroy(): void {
    this.subscriptions.forEach((subscription) => {
      subscription.unsubscribe();
    });
  }

  ngOnInit() {
    let id = this.route.snapshot.paramMap.get('id') || '0';
    let paramSubscribtion = this.route.params.subscribe({
      next: (params) => {
        this.product.id = params['id'];
        if( this.product.id === '0') {
          this.productForm.setValue({
            name: '',
            price: 0,
            quantity: 0,
          });
        }
      }
    });

    let subscribtion = this.productService.getProduct(id).subscribe({
      next: (product) => {
        this.product.id = product.id;
        this.productForm.setValue({
          name: product.name,
          price: product.price,
          quantity: product.quantity,
        });
      },
      error: (err) => {
        console.log(err);
      },
    });

    this.subscriptions.push(subscribtion);
    this.subscriptions.push(paramSubscribtion);
  }

  onSubmit() {
    if (this.productForm.invalid) {
      return;
    }

    this.product.name = this.productForm.get('name')?.value || '';
    this.product.price = this.productForm.get('price')?.value || 0;
    this.product.quantity = this.productForm.get('quantity')?.value || 0;

    if (this.product.id === '0') {
      this.addProduct();
    } else {
      this.updateProduct();
    }
  }

  updateProduct() {
    this.productService.updateProduct(this.product).subscribe({
      next: () => {
        this.router.navigate(['/products']);
      },
      error: (err) => {
        console.error(err);
      },
    });
    this.router.navigate(['/products']);
  }

  addProduct() {

    let subscribtion = this.productService.addProduct(this.product).subscribe({
      next: () => {
        this.router.navigate(['/products']);
      },
      error: (err) => {
        console.error(err);
      },
    });

    this.productService.subscribtions.push(subscribtion);
  }
}
