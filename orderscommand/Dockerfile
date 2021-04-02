FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY "./orderscommand/orderscommand.csproj" ./
RUN dotnet restore "orderscommand.csproj"

COPY . ./ 
RUN dotnet publish "./orderscommand/orderscommand.csproj" -c Debug -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "orderscommand.dll"]