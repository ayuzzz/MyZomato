This is a very basic food ordering application which has been created for learning purposes only.

It is based on the containerized Microservice Architecture with CQRS implementation.

Backend
=======
The backend stack involves :
	- .Net Core 3.1
	- SQL Server
	- Docker

Major packages/tools used include:
	- MassTransit
	- RabbitMQ
	- XUnit
	- Moq
	- Swagger (Swashbuckle)
	- docker desktop
	- Jenkins

Frontend
========
The Fronted is based on Angular 11


The highlighting features of the app are as follows :

1) Simple, clean UI
2) Dark mode functionality
3) Location-tracking based on IP address
4) Material design
5) Email notifications for the order status changes

Branch info
-----------
main -> this is the combined frontend-backend branch
myzomato-backend-master -> this is the master branch for the backend
myzomato-ui-master -> this is the master branch for the frontend
kubernetes-backend-master -> this branch is the master branch for kubernetes cluster related resources ("YAML" folder, "Helm Charts" folder)
[Simple yaml files for K8 cluster present in YAML folder whereas Helm deployment related files present in "Helm Charts" folder]


The main branch includes :
- Jenkins.groovy for the CI/CD pipelines using dockerhub
- docke-compose.yml for using docker compose to initialize the containers
- and ofcourse the frontend - backend code with Dockerfile for each service


Functionalities
===============

Landing page
------------
- There is a landing page which provide us the option to select the location, based on which the restaurant names get populated.
- The location drop-down has a location tracking feature which will track the current city on the basis of IP address of the user.

![Landing Page - Light Theme](https://user-images.githubusercontent.com/29431398/118089180-b88c0980-b3e5-11eb-9ed3-bcd6cbf37aab.png)

![Landing Page - Dark Theme](https://user-images.githubusercontent.com/29431398/118089280-cb9ed980-b3e5-11eb-9ad2-d13d3dcf5b17.png)

Restaurants List
----------------
- It shows the list of restaurants available in the selected city and some basic details about those restaurants
- The user can select anyone of these restaurants for the purpose of ordering the food.

![Restaurants List](https://user-images.githubusercontent.com/29431398/118089570-22a4ae80-b3e6-11eb-8fb9-2c39ddcaab0a.png)

Product list
------------
- Upon selecting a restaurant from the Restaurants list, the user will be able to select the food items and their quantity from this screen.

![Products List](https://user-images.githubusercontent.com/29431398/118089538-16b8ec80-b3e6-11eb-9cce-d52bed2cdad8.png)

Cart & Checkout
---------------
- Post selecting the quantity of the items, the cart will be dynamically updated and will allow the user to pay the bill and complete the order.

![Cart   Checkout - Dark Theme](https://user-images.githubusercontent.com/29431398/118089424-effab600-b3e5-11eb-9042-efe6a57e6516.png)

Internal order and payment processing pipeline
----------------------------------------------
- Post checkout, the payment is validated against the available amount in the user's wallet and the status of the order is auto updated every 10 seconds 
  (for demo purposes).
- User will receive an email upon every order update

My Orders
---------
- This screen shows the user all details regarding the orders that the user has placed in the past, which involves Ordered items, 
  ordered quantity, Order date, Order status, etc.
  
  ![My Orders - Light Theme](https://user-images.githubusercontent.com/29431398/118089479-043eb300-b3e6-11eb-80db-31bf42cae147.png)
  
  ![My Orders - Dark Theme](https://user-images.githubusercontent.com/29431398/118089452-fab54b00-b3e5-11eb-93a1-8e51da09b8df.png)

My Profile
----------
This screen shows the basic details about the user.

![My Profile](https://user-images.githubusercontent.com/29431398/118089504-0dc81b00-b3e6-11eb-9ca5-9b8626c3b46c.png)

