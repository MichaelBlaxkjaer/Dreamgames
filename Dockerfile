FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine

WORKDIR /app
COPY bin/Release/netcoreapp3.0/publish/ .
ENTRYPOINT ["dotnet", "dreamgames.dll"]