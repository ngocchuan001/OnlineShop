FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 50739
EXPOSE 44352

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY OnlineShop.Presentation/OnlineShop.Presentation.csproj OnlineShop.Presentation/
RUN dotnet restore OnlineShop.Presentation/OnlineShop.Presentation.csproj
COPY . .
WORKDIR /src/OnlineShop.Presentation
RUN dotnet build OnlineShop.Presentation.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish OnlineShop.Presentation.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OnlineShop.Presentation.dll"]
