export class DeliveryMethod {
  items: DeliveryMethodItem[] = []
}

export interface DeliveryMethodItem {
  shortName: string;
  deliveryTime: string;
  description: string;
  price: number;
  id: number;
}

