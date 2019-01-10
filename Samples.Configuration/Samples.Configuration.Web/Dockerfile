FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Samples.Configuration.Web/Samples.Configuration.Web.csproj", "Samples.Configuration.Web/"]
RUN dotnet restore "Samples.Configuration.Web/Samples.Configuration.Web.csproj"
COPY . .
WORKDIR "/src/Samples.Configuration.Web"
RUN dotnet build "Samples.Configuration.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Samples.Configuration.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Samples.Configuration.Web.dll"]