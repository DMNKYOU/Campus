import { Component, OnInit } from '@angular/core';
import { Cart, CartService } from '../shared/cart.service';
import { Router } from '@angular/router';
import { ProductService } from '../shared/product.service';
import { IProduct } from '../product-list/product';

@Component({
  moduleId: module.id,
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})

export class CartPgComponent implements OnInit {
  cart: Cart = new Cart();

  name: String;
  address: String;
  cardName: String;
  cardNumber: String;
  expirationMonth: String;
  expirationYear: String;
  cvc: String;

  constructor(
    public _cartService: CartService,
    public router: Router) {
    this.cart = this._cartService.cart;
  }

  ngOnInit() {
  }

  removeProduct(product: IProduct) {
    this._cartService.removeProduct(product);
  }

  addProduct(product: IProduct) {
    this._cartService.addProduct(product);
  }

  clearCart() {
    this._cartService.clearCart();
  }

  openCheckout() {
    var handler = (<any>window).StripeCheckout.configure({
      key: 'pk_test_9Yl0FpMFIPla5WE4mAGlvkZM',
      locale: 'auto',
      token: function (token: any) {
        // You can access the token ID with `token.id`.
        // Get the token ID to your server-side code for use.
      }
    });

    handler.open({
      name: 'Payment',
      description: 'Please Enter Your Details',
      currency: 'eur',
      amount: this.cart.totalCost * 100 // make it into euro instead of cents
    });
  }

}