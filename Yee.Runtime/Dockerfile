FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
RUN apt-get update && apt-get install -y --allow-unauthenticated libgdiplus libc6-dev libx11-dev

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY [".", "."]
RUN dotnet restore "Yee.Runtime/Yee.Runtime.csproj"
WORKDIR "/src/Yee.Runtime/"
RUN dotnet build "Yee.Runtime.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Yee.Runtime.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "Yee.Runtime.dll"]
