FROM microsoft/dotnet:2.2-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Exercicio.Tres/Exercicio.Tres/Exercicio.Tres.csproj Exercicio.Tres/Exercicio.Tres/
RUN dotnet restore Exercicio.Tres/Exercicio.Tres/Exercicio.Tres.csproj
COPY . .
WORKDIR /src/Exercicio.Tres/Exercicio.Tres
RUN dotnet build Exercicio.Tres.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Exercicio.Tres.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Exercicio.Tres.dll"]
