import { Component } from '@angular/core';
import { HeaderCarrouselComponent } from "./header-carrousel/header-carrousel.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [HeaderCarrouselComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
