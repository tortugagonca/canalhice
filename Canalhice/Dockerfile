FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev libgomp1
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /Canalhice
COPY ["Canalhice/Canalhice/canalhice.api.csproj", "canalhice.api/"]
RUN dotnet restore "Canalhice/canalhice.api.csproj"
COPY . .
WORKDIR "/Canalhice"
RUN dotnet build "canalhice.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "canalhice.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish
ENTRYPOINT ["dotnet", "canalhice.api.dll"]