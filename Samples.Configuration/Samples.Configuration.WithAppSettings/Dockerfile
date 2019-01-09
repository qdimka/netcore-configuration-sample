FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Samples.Configuration.WithAppSettings/Samples.Configuration.WithAppSettings.csproj", "Samples.Configuration.WithAppSettings/"]
RUN dotnet restore "Samples.Configuration.WithAppSettings/Samples.Configuration.WithAppSettings.csproj"
COPY . .
WORKDIR "/src/Samples.Configuration.WithAppSettings"
RUN dotnet build "Samples.Configuration.WithAppSettings.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Samples.Configuration.WithAppSettings.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Samples.Configuration.WithAppSettings.dll"]