export interface IOrder{
    id:number,
    transactionId:string,
    status:string,
    //createdDate:Date,
    //modifiedDate:Date
    restaurantId:number,
    restaurant:string,
    amount:number,
    orderProducts:IOrderProduct[],
    isExpanded:boolean
}

export interface IOrderProduct{
    productName:string,
    productId:number,
    quantity:number
    price:number
}