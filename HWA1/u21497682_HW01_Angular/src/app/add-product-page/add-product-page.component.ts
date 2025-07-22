import { Component } from '@angular/core';
import { ProductService } from '../services/product.service';
import { product } from '../models/productModel';
import { RouterModule, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-product-page',
  imports: [FormsModule],
  templateUrl: './add-product-page.component.html',
  styleUrl: './add-product-page.component.css',
  standalone: true
})
export class AddProductPageComponent {
  newProduct: product = {
    product_ID: 0, // ID will be assigned by the backend
    product_Name: '',
    product_Description: '',
    product_Price: 0
  };

  constructor(private productService: ProductService, private router: Router) { }

  onSubmit() {
    this.productService.addProduct(this.newProduct).subscribe({
      next: (response) => {
        console.log('Product added successfully:', response);
        this.router.navigate(['/products']); // Redirect to product list
      },
      error: (error) => {
        console.error('Error adding product:', error);
      }
    });
  }

  cancel() {
    this.router.navigate(['/products']); // Navigate back on cancel
  }
}
