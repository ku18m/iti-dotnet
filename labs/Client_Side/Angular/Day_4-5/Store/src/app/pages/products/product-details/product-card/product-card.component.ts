import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { IProduct } from '../../../../models/iproduct';


@Component({
  selector: 'app-product-card',
  standalone: true,
  imports: [],
  templateUrl: './product-card.component.html',
  styleUrl: './product-card.component.css',
})
export class ProductCardComponent {
  @Input() product: IProduct = {} as IProduct;

  @Output() removeProductEvent = new EventEmitter<string>();
  @Output() discountOnProductEvent = new EventEmitter<string>();

  oldPrice: number = 0;

  ngOnChanges(changes: SimpleChanges) {
    if(changes['product']) {
      this.oldPrice = changes['product'].previousValue?.price;
    }
  }

  remove() {
    this.removeProductEvent.emit(this.product.id);
  }

  discount() {
    console.log("discountFromCard");
    this.discountOnProductEvent.emit(this.product.id);
  }
}
