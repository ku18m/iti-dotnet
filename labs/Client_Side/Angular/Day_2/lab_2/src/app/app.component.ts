import { Component } from '@angular/core';
import { StudentFormComponent } from './components/student-form/student-form.component';
import { ProductsComponent } from './components/products/products.component';
import { ItiTracksComponent } from './components/iti-tracks/iti-tracks.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [StudentFormComponent, ProductsComponent, ItiTracksComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'lab_2';
}
