import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule} from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';
import { FlashMessagesModule } from 'angular2-flash-messages';

//services
import { ProductService } from './shared/product.service';
import { AuthService } from './shared/auth.service';
import { ValidateService } from './shared/validate.service';
import { AuthGuardService } from './guards/auth-guard.service';
import { CartService } from './shared/cart.service';

//components 
import { AppComponent } from './app.component';
import { ProductListComponent } from './product-list/product-list.component';
import { CartPgComponent } from './cart/cart.component';
import { RegisterComponent } from './register/register.component';
import { ProfileComponent } from './profile/profile.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { NavigationComponent } from './navigation/navigation.component';
import { CartComponent } from './cart-pg/cart-pg.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { FooterComponent } from './footer/footer.component';

// adding routes
const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'profile', component: ProfileComponent, canActivate:[AuthGuardService] }, //just people loggedIn can have acces to this
  { path: 'products', component: ProductListComponent },
  { path: 'cart', component: CartPgComponent },
  { path: 'cart-pg', component: CartPgComponent },
  { path: 'checkout', component: CheckoutComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    CartComponent,
    RegisterComponent,
    ProfileComponent,
    LoginComponent,
    HomeComponent,
    NavigationComponent,
    CartPgComponent,
    CheckoutComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
    FlashMessagesModule
  ],
  providers: [
    CartService,
    ProductService,
    AuthService,
    ValidateService,
    AuthGuardService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
