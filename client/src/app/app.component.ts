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
  constructor(private basketService: BasketService) {}

  ngOnInit() {
    const basketId= localStorage.getItem('basket_id');

    if(basketId)
    {
      this.basketService.getBasket(basketId).subscribe();
    }
  }

}
