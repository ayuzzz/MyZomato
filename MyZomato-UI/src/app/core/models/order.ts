export interface IOrder{
    id:number,
    transactionId:string,
    status:number,
    createdDate:Date,
    modifiedDate:Date
    restaurantId:number
    orderProducts:IOrderProduct[]
}

export interface IOrderProduct{
    productId:number,
    quantity:number
    price:number
}