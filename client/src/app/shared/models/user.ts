export interface User {
  email: string;
  displayName: string;
  token: string;
}

export class Address {
  firstName: string;
  lastName: string;
  street: string;
  city: string;
  state: string;
  zipcode: string;
}
