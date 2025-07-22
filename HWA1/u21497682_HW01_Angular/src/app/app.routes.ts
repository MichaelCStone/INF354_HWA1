import { Routes } from '@angular/router';
import { ProductListingPageComponent } from './product-listing-page/product-listing-page.component';
import { EditProductPageComponent } from './edit-product-page/edit-product-page.component';
import { AddProductPageComponent } from './add-product-page/add-product-page.component';

export const routes: Routes = [
    {path: '', redirectTo: 'product-listing', pathMatch: 'full'}, //default page
    {path: 'product-listing', component: ProductListingPageComponent},
    {path: 'edit-product/:id', component: EditProductPageComponent},
    {path: 'add-product', component: AddProductPageComponent},
    {path: '**', component: ProductListingPageComponent} //defualt page if wrong page is entered
];
