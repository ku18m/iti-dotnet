import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HeaderCarrouselComponent } from './components/header-carrousel/header-carrousel.component';
import { GetStartedComponent } from "./components/get-started/get-started.component";
import { RetailShopComponent } from './components/retail-shop/retail-shop.component';
import { FeaturedProductsComponent } from './components/featured-products/featured-products.component';
import { FooterComponent } from './components/footer/footer.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [NavbarComponent, HeaderCarrouselComponent, GetStartedComponent, RetailShopComponent, FeaturedProductsComponent ,FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'little_fashion';
}
