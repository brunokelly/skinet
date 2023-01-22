import { IBasket } from './interfaces/ibasket';
import { IBasketItem } from './interfaces/ibasket-item';

export class Basket implements IBasket {
  id = self.crypto.randomUUID()
  items: IBasketItem[] = [];
}
