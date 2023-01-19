import { HttpErrorResponse } from "@angular/common/http";

export interface IErrorModel extends HttpErrorResponse
{
  error: {
    error:
    {
      message: string;
    }
  }
}
