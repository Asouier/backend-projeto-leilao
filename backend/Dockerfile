# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Definir o diretório de trabalho no container
WORKDIR /src

# Copiar o arquivo .csproj e restaurar dependências
COPY ./Backend.csproj ./
RUN dotnet restore

# Copiar o restante do código do projeto
COPY ./ ./

# Compilar o projeto
RUN dotnet build -c Release -o /app/build

# Publicar a aplicação
RUN dotnet publish -c Release -o /app/publish

# Etapa de execução
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# Definir o comando para rodar a aplicação
CMD ["dotnet", "Backend.dll"]
