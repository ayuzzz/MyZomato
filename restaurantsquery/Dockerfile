FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY "./restaurantsquery/restaurantsquery.csproj" ./
RUN dotnet restore "restaurantsquery.csproj"

COPY . ./ 
RUN dotnet publish "./restaurantsquery/restaurantsquery.csproj" -c Debug -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "restaurantsquery.dll"]