docker build -t usermanagement-query -f usermanagementquery/Dockerfile .
docker run -dp 44349:80 usermanagement-query
echo "`n`n---------------------------------------- usermanagement-query container is up and running---------------------------------------------------`n`n"

docker build -t restaurants-query -f restaurantsquery/Dockerfile .
docker run -dp 44339:80 restaurants-query
echo "`n`n---------------------------------------- restaurants-query container is up and running---------------------------------------------------`n`n"

docker build -t product-query -f productquery/Dockerfile .
docker run -dp 44310:80 product-query
echo "`n`n---------------------------------------- product-query container is up and running---------------------------------------------------`n`n"

docker build -t orders-command -f orderscommand/Dockerfile .
docker run -dp 44337:80 orders-command
echo "`n`n---------------------------------------- orders-command container is up and running---------------------------------------------------`n`n"

docker build -t orderpaymentprocessing-command -f orderPaymentProcessingCommand/Dockerfile .
docker run -dp 44364:80 orderpaymentprocessing-command
echo "`n`n---------------------------------------- orderPaymentProcessing-command container is up and running---------------------------------------------------`n`n"

docker ps