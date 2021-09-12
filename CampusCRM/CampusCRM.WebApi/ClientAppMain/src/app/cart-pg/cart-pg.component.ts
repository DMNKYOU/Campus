// import { CartPgComponent } from '../cart-pg/cart-pg.component';
import { CartPgComponent } from '../cart/cart.component';
import { IProduct } from '../product-list/product';
import { Component, OnInit, Input } from '@angular/core';
import { Cart, CartService } from '../shared/cart.service';
import { RouterModule, Routes, Router } from '@angular/router';
import { CheckoutComponent } from '../checkout/checkout.component';

@Component({
  selector: 'app-cart-pg',
  templateUrl: './cart-pg.component.html',
  styleUrls: ['./cart-pg.component.css']
})

export class CartComponent implements OnInit {
  cart: Cart = new Cart();


  constructor(
    public _cartService: CartService,
    public router: Router) {
    this.cart = this._cartService.cart;
  }

  ngOnInit() {
  }

  removeItem(product: IProduct) {
    this._cartService.removeItem(product);
  }
}