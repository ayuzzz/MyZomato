export interface IOrder{
    id:number,
    transactionId:string,
    status:string,
    //createdDate:Date,
    //modifiedDate:Date
    restaurantId:number
    restaurant:string
    amount:number
    orderProducts:IOrderProduct[]
}

export interface IOrderProduct{
    productId:number,
    quantity:number
    price:number
}