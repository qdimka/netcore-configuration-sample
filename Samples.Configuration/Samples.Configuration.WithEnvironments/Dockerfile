FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Samples.Configuration.WithEnvironments/Samples.Configuration.WithEnvironments.csproj", "Samples.Configuration.WithEnvironments/"]
RUN dotnet restore "Samples.Configuration.WithEnvironments/Samples.Configuration.WithEnvironments.csproj"
COPY . .
WORKDIR "/src/Samples.Configuration.WithEnvironments"
RUN dotnet build "Samples.Configuration.WithEnvironments.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Samples.Configuration.WithEnvironments.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Samples.Configuration.WithEnvironments.dll"]