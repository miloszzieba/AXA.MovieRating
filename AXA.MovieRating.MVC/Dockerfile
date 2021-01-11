#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["AXA.MovieRating.MVC/AXA.MovieRating.MVC.csproj", "AXA.MovieRating.MVC/"]
RUN dotnet restore "AXA.MovieRating.MVC/AXA.MovieRating.MVC.csproj"
COPY . .
WORKDIR "/src/AXA.MovieRating.MVC"
RUN dotnet build "AXA.MovieRating.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AXA.MovieRating.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AXA.MovieRating.MVC.dll"]