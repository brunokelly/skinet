import { IProduct } from "./product";

export interface IPagination{
  succes: boolean;
  data: {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IProduct[];
  }
}
