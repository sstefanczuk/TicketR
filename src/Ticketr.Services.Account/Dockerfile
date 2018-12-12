FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5002

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Ticketr.Services.Account/Ticketr.Services.Account.csproj Ticketr.Services.Account/
RUN dotnet restore Ticketr.Services.Account/Ticketr.Services.Account.csproj
COPY . .
WORKDIR /src/Ticketr.Services.Account
RUN dotnet build Ticketr.Services.Account.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Ticketr.Services.Account.csproj -c Release -o /app

RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ticketr.Services.Account.dll"]
