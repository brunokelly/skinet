import { IProductTypeItem } from './product-type-item';
export interface IProductType
{
  items: IProductTypeItem[];
  sucess: boolean;
  error: string;
}
