FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Samples.Configuration.WithSecrets/Samples.Configuration.WithSecrets.csproj", "Samples.Configuration.WithSecrets/"]
RUN dotnet restore "Samples.Configuration.WithSecrets/Samples.Configuration.WithSecrets.csproj"
COPY . .
WORKDIR "/src/Samples.Configuration.WithSecrets"
RUN dotnet build "Samples.Configuration.WithSecrets.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Samples.Configuration.WithSecrets.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Samples.Configuration.WithSecrets.dll"]