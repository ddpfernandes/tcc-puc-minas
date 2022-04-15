FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5002

ENV ASPNETCORE_URLS=http://+:5002

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["Services/Supplier/Supplier.csproj", "Services/Supplier/"]
RUN dotnet restore "Services/Supplier/Supplier.csproj"
COPY . .
WORKDIR "/src/Services/Supplier"
RUN dotnet build "Supplier.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Supplier.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Supplier.dll"]
