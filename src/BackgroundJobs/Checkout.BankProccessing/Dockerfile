FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "BackgroundJobs/Checkout.BankProccessing/Checkout.BankProccessing.csproj"

COPY . .
RUN dotnet build "BackgroundJobs/Checkout.BankProccessing/Checkout.BankProccessing.csproj" -c Release -o /app

FROM build as publish
RUN dotnet publish "BackgroundJobs/Checkout.BankProccessing/Checkout.BankProccessing.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Checkout.BankProccessing.dll"]