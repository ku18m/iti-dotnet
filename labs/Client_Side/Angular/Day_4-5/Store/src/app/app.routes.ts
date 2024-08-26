import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ProductsComponent } from './pages/products/products.component';
import { EditproductComponent } from './pages/products/editproduct/editproduct.component';
import { ProductDetailsComponent } from './pages/products/product-details/product-details.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'products',
    component: ProductsComponent,
  },
  {
    path: 'products/:id/edit',
    component: EditproductComponent,
  },
  {
    path: 'products/:id',
    component: ProductDetailsComponent
  }
];
