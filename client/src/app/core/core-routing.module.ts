import { NotFoundComponent } from './pages/erros/not-found/not-found.component';
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ServeErrorComponent } from "./pages/erros/serve-error/serve-error.component";

const routes: Routes = [
  {
    path: 'servererror',
    data: {title: 'Error'},
    component: ServeErrorComponent,
  },
  {
    path: 'notfound',
    data: {title: 'Error'},
    component: NotFoundComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CoreRoutingModule {}
