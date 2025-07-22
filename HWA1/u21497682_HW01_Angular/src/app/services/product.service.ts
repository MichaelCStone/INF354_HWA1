import { Injectable } from '@angular/core';
import { product } from '../models/productModel';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ProductService {

  private apiUrl = "http://localhost:5111/api/Product";

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }) // Ensure JSON format
  };

  constructor(private http: HttpClient) { }

  //GET all products
  getAllProducts(): Observable<product[]>
  {
    return this.http.get<product[]>(this.apiUrl);
  }

  //GET product by id
  getProductById(id: number): Observable<product>
  {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<product>(url);
  }

  //POST: Add a new product
  addProduct(newProduct: product): Observable<product>
  {
    return this.http.post<product>(this.apiUrl, newProduct, this.httpOptions);
  }

  //PUT: Update an existing product
  updateProduct(id: number, updatedProduct: product): Observable<product>
  {
    const url = `${this.apiUrl}/${id}`;
    return this.http.put<product>(url, updatedProduct, this.httpOptions);
  }

  //DELETE: Remove a product
  deleteProduct(id: number): Observable<void>
  {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<void>(url);
  }
}
