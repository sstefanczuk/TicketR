FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY TicketR.Api/TicketR.Api.csproj TicketR.Api/
RUN dotnet restore TicketR.Api/TicketR.Api.csproj
COPY . .
WORKDIR /src/TicketR.Api
RUN dotnet build TicketR.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TicketR.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TicketR.Api.dll"]
