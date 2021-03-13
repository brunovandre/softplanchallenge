FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY CalculateInterest ./CalculateInterest
COPY Shared ./Shared

WORKDIR /app/CalculateInterest/src/SoftPlanChallenge.CalculateInterest.API
RUN dotnet restore
RUN dotnet publish -c Release -o /app/CalculateInterest/out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/CalculateInterest/out .
ENTRYPOINT ["dotnet", "SoftPlanChallenge.CalculateInterest.API.dll"]