import { BaseResponse } from "src/app/shared/models/base-response";
import { IBasket } from "./ibasket";

export interface IBasketResponse extends BaseResponse {
  items: IBasket;
}
