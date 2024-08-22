# Usar a imagem base do SDK do .NET para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
EXPOSE 5003
#EXPOSE 9229

# Copiar o arquivo nuget.config para resolver dependências
COPY nuget.config ./

# Copiar todos os arquivos da solução e restaurar as dependências
COPY ./ ./
WORKDIR /src/Presentation/Mover.Loc.Api
RUN dotnet restore Mover.Loc.Api.csproj

# Construir todos os projetos
WORKDIR /src/Presentation/Mover.Loc.Api
RUN dotnet build -c Release -o /app/build

# Publicar a API
RUN dotnet publish -c Release -o /app/publish

# Configurar a imagem final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Mover.Loc.Api.dll"]
