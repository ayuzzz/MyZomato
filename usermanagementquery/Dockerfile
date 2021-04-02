FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY "./usermanagementquery/usermanagementquery.csproj" ./
RUN dotnet restore "usermanagementquery.csproj"

COPY . ./ 
RUN dotnet publish "./usermanagementquery/usermanagementquery.csproj" -c Debug -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "usermanagementquery.dll"]