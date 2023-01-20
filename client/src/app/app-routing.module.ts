import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full',
    data: {
      breadcrumb: 'Home'
    }
  },
  {
    path: 'home',
    data: { title: 'Home', breadcrumb: { skip: true} },
    loadChildren: () =>
      import('./pages/home/home.module').then((x) => x.HomeModule),
  },
  {
    path: 'shop',
    data: { breadcrumb: 'Shop' },
    loadChildren: () =>
      import('./pages/shop/shop.module').then((x) => x.ShopModule),
  },
  {
   path: 'basket',
   data: { title: 'basket', breadcrumb: 'Basket' },
   loadChildren: () => import('./pages/basket/basket.module').then((x) => x.BasketModule)

  },
  {
    path: 'error',
    data: { title: 'Error', breadcrumb: 'Error'},
    loadChildren: () => import('./core/core.module').then((x) => x.CoreModule),
  },
  {
    path: '**',
    redirectTo: '/home',
    pathMatch: 'full',
  },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
