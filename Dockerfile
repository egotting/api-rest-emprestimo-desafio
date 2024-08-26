FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["api-rest-emprestimo-desafio/api-rest-emprestimo-desafio.csproj", "api-rest-emprestimo-desafio/"]
RUN dotnet restore "api-rest-emprestimo-desafio/api-rest-emprestimo-desafio.csproj"
COPY . .
WORKDIR "/src/api-rest-emprestimo-desafio"
RUN dotnet build "api-rest-emprestimo-desafio.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "api-rest-emprestimo-desafio.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api-rest-emprestimo-desafio.dll"]
