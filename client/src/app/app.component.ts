import { AccountService } from './pages/account/pages/services/account.service';
import { BasketService } from './pages/basket/services/basket.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  constructor(private basketService: BasketService, private accountService: AccountService) {}

  ngOnInit() {
    this.loadBasket();
    this.loadCurrentUser();
  }


  loadBasket() {
    const basketId = localStorage.getItem('basket_id');
    if (basketId) this.basketService.getBasket(basketId);
  }

  loadCurrentUser() {
    const token = localStorage.getItem('token');
    this.accountService.loadCurrentUser(token).subscribe();
  }
}
