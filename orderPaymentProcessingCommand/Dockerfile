FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY "./orderPaymentProcessingCommand/orderPaymentProcessingCommand.csproj" ./
RUN dotnet restore "orderPaymentProcessingCommand.csproj"

COPY . ./ 
RUN dotnet publish "./orderPaymentProcessingCommand/orderPaymentProcessingCommand.csproj" -c Debug -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "orderPaymentProcessingCommand.dll"]