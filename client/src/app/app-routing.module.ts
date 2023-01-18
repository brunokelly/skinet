import { ProductComponent } from './pages/products/product/product.component';
import { HomeComponent } from './pages/home/home/home.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: "",
    redirectTo: '/home',
    pathMatch: 'full'
  },
  {
    path:'home',
    loadChildren:  () => import('./pages/home/home.module').then(x => x.HomeModule)

  },
  {
    path: 'shop',
    loadChildren:  () => import('./pages/products/shop.module').then(x => x.ShopModule)
  },
  {
    path: "**",
    redirectTo: '/home',
    pathMatch: 'full'
  },
];
@NgModule({
  imports: [RouterModule.forRoot(routes,
    {enableTracing: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
