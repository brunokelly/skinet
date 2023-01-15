import { IProduct } from "./product";

export interface IPagination{
  succes: boolean;
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IProduct[];

}
