FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Exercicio.Quinze/Exercicio.Quinze/Exercicio.Quinze.csproj", "Exercicio.Quinze/Exercicio.Quinze/"]
COPY ["Exercicio.Tres/Exercicio.Tres/Exercicio.Tres.csproj", "Exercicio.Tres/Exercicio.Tres/"]
RUN dotnet restore "Exercicio.Quinze/Exercicio.Quinze/Exercicio.Quinze.csproj"
COPY . .
WORKDIR "/src/Exercicio.Quinze/Exercicio.Quinze"
RUN dotnet build "Exercicio.Quinze.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Exercicio.Quinze.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Exercicio.Quinze.dll"]