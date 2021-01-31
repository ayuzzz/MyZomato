import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/core/models/product';
import { ProductsApiService } from 'src/app/core/services/api-services/products-api.service';

@Component({
  selector: 'app-category-seperator',
  templateUrl: './category-seperator.component.html',
  styleUrls: ['./category-seperator.component.css']
})
export class CategorySeperatorComponent implements OnInit {
  @Input()
  category:string;

  productsList:IProduct[];
  distinctCategories:string[];
  groupedProductsList:[];
  productsInCart:IProduct[];

  constructor(private _router:ActivatedRoute, private _productApiService:ProductsApiService) { 
    this.productsList = [];
    this.productsInCart = [];
    this.distinctCategories = [];
    this.groupedProductsList = [];
    this.category = "";
  }


  ngOnInit(): void { 
    let restaurantId = parseInt(this._router.snapshot.paramMap.get("restaurantId") as string);

    this.getProductsForRestaurant(restaurantId);
  }

  getProductsForRestaurant(restaurantId:number){
    this._productApiService.getProductsForRestaurant(restaurantId).subscribe(
      (response) => {this.productsList = response; this.populateCategories()});
  }   

  populateCategories(){
    // this.productsList.map(prod => {if(!this.distinctCategories.includes(prod.category)){
    //   this.distinctCategories.push(prod.category.toLocaleUpperCase())}
    // });

    this.distinctCategories = this.productsList.map(prod => prod.category)
    .filter((value, index, self) => self.indexOf(value) === index);
  }

  getProducts(category:string):IProduct[]{
    return this.productsList.filter(x => x.category === category);
  }

  updateCart(product:IProduct){
    this.productsInCart = JSON.parse(localStorage.getItem("productsInCart") as string) as IProduct[];
    
    if(this.productsInCart == null)
    {
      this.productsInCart = [];
      this.productsInCart.push(product);
    }
    else    
    {
      let productPresent = this.productsInCart.filter(x => x.id === product.id).length;

      if(productPresent === 0)
      {
        this.productsInCart.push(product);
      }
      else
      {
        let addedProduct = this.productsInCart.findIndex(x => x.id === product.id);
        if(addedProduct != -1)
        {
          this.productsInCart.splice(addedProduct, 1);
        }

        if(product.quantity > 0)
        {
          this.productsInCart.push(product);
        }          
      }
    }

    localStorage.setItem("productsInCart", JSON.stringify(this.productsInCart));
  }

}
