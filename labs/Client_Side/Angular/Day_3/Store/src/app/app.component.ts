import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from "./components/navbar/navbar.component";
import { HeaderCarrouselComponent } from "./components/header-carrousel/header-carrousel.component";
import { FooterComponent } from "./components/footer/footer.component";
import { ProductsComponent } from "./components/products/products.component";
import { LoginComponent } from "./components/login/login.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent, HeaderCarrouselComponent, FooterComponent, ProductsComponent, LoginComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Store';
  route :string = 'home';

  changeRoute(route: string) {
    this.route = route;
  }
}
