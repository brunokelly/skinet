import { Basket } from './../../../pages/basket/models/basket';
import { AccountService } from './../../../pages/account/pages/services/account.service';
import { Observable } from 'rxjs';
import { BasketService } from './../../../pages/basket/services/basket.service';
import { Component, OnInit } from '@angular/core';
import { IBasket } from 'src/app/pages/basket/models/interfaces/ibasket';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  basket$: Observable<IBasket>;

  constructor(private basketService: BasketService, public accountService: AccountService) { }

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
  }

}
