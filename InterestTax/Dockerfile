FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY InterestTax ./InterestTax
COPY Shared ./Shared

WORKDIR /app/InterestTax/src/SoftPlanChallenge.InterestTax.API
RUN dotnet restore
RUN dotnet publish -c Release -o /app/InterestTax/out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/InterestTax/out .
ENTRYPOINT ["dotnet", "SoftPlanChallenge.InterestTax.API.dll"]