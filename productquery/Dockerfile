FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY "./productquery/productquery.csproj" ./
RUN dotnet restore "productquery.csproj"

COPY . ./ 
RUN dotnet publish "./productquery/productquery.csproj" -c Debug -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "productquery.dll"]