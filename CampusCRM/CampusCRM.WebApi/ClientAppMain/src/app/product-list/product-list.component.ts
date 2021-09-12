import { ProductService } from '../shared/product.service';
import { IProduct } from './product';
import { Component, OnInit } from '@angular/core';
import { Cart, CartItem, CartService } from '../shared/cart.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.less']
})
export class ProductListComponent implements OnInit {
  products: IProduct[];
  filteredProducts: IProduct[];
  errorMessage: string;

  constructor(
    public _productService: ProductService, 
    public _cartService: CartService) {
  }

  onNotify(message: string): void {
    console.log(message);
  }

  ngOnInit(): void {
    this._productService.getProducts().subscribe(products => {
      this.products = products,
        this.filteredProducts = this.products;
    },
      error => this.errorMessage = <any>error);
  }

  //#region Cart
  addToCart(product: IProduct) {
    this._cartService.addProduct(product);
  }
  //#endregion
  //#region Search
  _search: string;

  get search(): string {
    return this._search;
  }

  set search(value: string) {
    this._search = value;
    this.filteredProducts = this.search ? this.performSearch(this.search) : this.products;
  }

  performSearch(searchBy: string): IProduct[] {
    searchBy = searchBy.toLocaleLowerCase();
    return this.products.filter((product: IProduct) => product.name.toLocaleLowerCase().indexOf(searchBy) != -1);
  }
  //#endregion
  //#region Sort
  performSort(sortBy: string) {
    if (sortBy == 'Popularity')
      this.filteredProducts = this.filteredProducts.sort(this.sortByPopularity)
    else if (sortBy == 'Price - Low to High')
      this.filteredProducts = this.filteredProducts.sort(this.sortByPriceLow)
    else if (sortBy == 'Price - High to Low')
      this.filteredProducts = this.filteredProducts.sort(this.sortByPriceHigh)
  }

  sortByPopularity(p1: IProduct, p2: IProduct) {
    return p1.stock - p2.stock;
  }

  sortByPriceLow(p1: IProduct, p2: IProduct) {
    return p1.price - p2.price;
  }

  sortByPriceHigh(p1: IProduct, p2: IProduct) {
    return p2.price - p1.price;
  }
  //#endregion  
  //#region Category
  // Mens
  _mens: boolean = false;
  get mens(): boolean {
    return this._mens;
  }

  set mens(value: boolean) {
    this._mens = value;
    this.refine();
  }

  // Womens
  _womens: boolean = false;
  get womens(): boolean {
    return this._womens;
  }

  set womens(value: boolean) {
    this._womens = value;
    this.refine();
  }

  // Jackets
  _jackets: boolean = false;
  get jackets(): boolean {
    return this._jackets;
  }

  set jackets(value: boolean) {
    this._jackets = value;
    this.refine();
  }

  // Jeans
  _jeans: boolean = false;
  get jeans(): boolean {
    return this._jeans;
  }

  set jeans(value: boolean) {
    this._jeans = value;
    this.refine();
  }

  refine(): void {
    this.filteredProducts = [];
    this.products.forEach(product => {
      if (this._mens == true && product.department == "mens") {
        this.filteredProducts.push(product);
      }
      else if (this._womens == true && product.department == "womens") {
        this.filteredProducts.push(product);
      }
      else if (this._jackets == true && product.category == "jackets") {
        this.filteredProducts.push(product);
      }
      else if (this._jeans == true && product.category == "jeans") {
        this.filteredProducts.push(product);
      }
      else if (this._mens == false
        && this._womens == false
        && this._jackets == false
        && this._jeans == false) {
        this.filteredProducts = this.products;
      }
    });
  }
  //#endregion
}