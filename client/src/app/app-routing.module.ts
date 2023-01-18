import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: "",
    redirectTo: '/home',
    pathMatch: 'full'
  },
  {
    path:'home', loadChildren:  () => import('./pages/home/home.module').then(x => x.HomeModule)
  },
  {
    path: 'shop', loadChildren:  () => import('./pages/shop/shop.module').then(x => x.ShopModule)
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
