import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { ProductListingPageComponent } from './product-listing-page/product-listing-page.component';
import { ProductService } from './services/product.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavbarComponent, ProductListingPageComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [ProductService]
})
export class AppComponent {
  title = 'u21497682_HW01_Angular';

  constructor(private productService: ProductService) {
    
  }
}
