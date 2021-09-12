import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { IProduct } from '../product-list/product';

export interface CartItem { // Item in Cart
    product: IProduct;
    count: number;
    totalCost: number;
}

export class Cart { // Cart
    count: number = 0;
    totalCost: number = 0;
    items: CartItem[] = [];
}

@Injectable()
export class CartService {
    cart: Cart = new Cart();
    // This methid adds the new product
    // or increases the number of same products in the cart.
    // Also updates the totalCost and count of items in the cart.
    public addProduct(product: IProduct): CartItem {
        // Find CartItem in items
        let item: CartItem = this.findItem(product);
        product.stock--;
        //Check if it was found
        if (item) {
            // Item was found
            // Increase count of that item
            item.count++;
            // Increase total cost of those items
            item.totalCost += product.price;
        } else {
            // Item was not found
            // Create the cart item
            this.cart.items.push({
                product: product,
                count: 1,
                totalCost: product.price
            });
        }
        // Add item to items
        this.cart.count++;
        // Increase amount in the cart
        this.cart.totalCost += product.price;
        return item;
    }

    // Decreases the number of the same products in the cart
    // Or removes the last product.
    // Updates the total cost & count of items in the cart.
    removeProduct(product: IProduct): CartItem {
        // Find CartItem in items
        let item: CartItem = this.findItem(product);
        // Check if item found
        if (item) {
            // Decrease the Count
            item.count--;
            // Subtract the Price
            item.totalCost -= product.price;
            // Check if last product
            if (!item.count) {
                // It was last product
                // Delete item from items
                this.remove(item);
                item = null;
            }
            // Decrease count in cart
            this.cart.count--;
            // Decrease amount in cart
            this.cart.totalCost -= product.price;
        }
        return item;
    }

    removeItem(product: IProduct) {
        let item: CartItem = this.findItem(product);
        // Delete item from items
        this.remove(item);
        // Decrease count in cart
        this.cart.count -= item.count;
        // Decrease totalCost in cart
        this.cart.totalCost -= item.totalCost;
    }

    // Returns cart item by product _id
    findItem(product: IProduct): CartItem {
        for (let i = 0; i < this.cart.items.length; i++) {
            if (this.cart.items[i].product._id === product._id) {
                return this.cart.items[i];
            }
        }
        return null;
    }

    // Empty Cart & Reset all stats
    clearCart() {
        this.cart.items = [];
        this.cart.totalCost = 0;
        this.cart.count = 0;
    }

    // Remove Existing Cart Item
    private remove(item: CartItem) {
        // Find index of cart item
        let index: number = this.cart.items.indexOf(item);
        // Check if item found
        if (index !== -1) {
            // Remove from array
            this.cart.items.splice(index, 1);
        }
    }
}