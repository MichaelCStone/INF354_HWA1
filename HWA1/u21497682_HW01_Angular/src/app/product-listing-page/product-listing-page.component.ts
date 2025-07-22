import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { Router } from '@angular/router';
import { product } from '../models/productModel';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-product-listing-page',
  imports: [CommonModule, HttpClientModule],
  templateUrl: './product-listing-page.component.html',
  styleUrl: './product-listing-page.component.css'
})

export class ProductListingPageComponent {
  products: product[] = [];

  constructor(private productService: ProductService, private router: Router) {}

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts()
  {
    this.productService.getAllProducts().subscribe({
      next: (data) => {
        this.products = data;
      },
      error: (err) => {
        console.error("Error fetching products:", err);
      }
    });
  }

  deleteProduct(productId: number): void {
    if (confirm('Are you sure you want to delete this product?')) {
      this.productService.deleteProduct(productId).subscribe(() => {
        // this.products = this.products.filter(p => p.product_ID !== productId); // Remove from UI
        this.loadProducts();
      });
    }
  }

  editProduct(productId: number): void {
    this.router.navigate(['/edit-product', productId]); // Navigate with productId
  }
}
