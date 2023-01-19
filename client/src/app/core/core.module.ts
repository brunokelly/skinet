import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotFoundComponent } from './pages/erros/not-found/not-found.component';
import { ServeErrorComponent } from './pages/erros/serve-error/serve-error.component';
import { CoreRoutingModule } from './core-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';



@NgModule({
  declarations: [
    NotFoundComponent,
    ServeErrorComponent
  ],
  imports: [
    CommonModule,
    CoreRoutingModule,
    NgxSpinnerModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      closeButton: true,
      timeOut: 5000,
      easing: 'ease-in',
      easeTime: 1000
    })
  ]
})
export class CoreModule { }
