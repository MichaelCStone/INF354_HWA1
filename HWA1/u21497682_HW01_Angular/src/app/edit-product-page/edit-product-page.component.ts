import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../services/product.service';
import { product } from '../models/productModel';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-edit-product-page',
  imports: [FormsModule],
  templateUrl: './edit-product-page.component.html',
  styleUrl: './edit-product-page.component.css'
})
export class EditProductPageComponent {
  product: product = {
    product_ID: 0,
    product_Name: '',
    product_Description: '',
    product_Price: 0,
  };

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id')!; // Get product ID from route
    this.loadProduct(id);
  }

  // Load product by ID
  loadProduct(id: number): void {
    this.productService.getProductById(id).subscribe((data) => {
      this.product = data;
    });
  }

  // Update product and redirect to the product listing page
  onSubmit(): void {
    this.productService.updateProduct(this.product.product_ID, this.product).subscribe(() => {
      this.router.navigate(['/products']); // Redirect after successful update
    });
  }

  // Cancel and navigate back to the product listing page
  cancel(): void {
    this.router.navigate(['/products']);
  }
}
