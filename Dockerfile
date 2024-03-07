#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/ProMatcher.Api/ProMatcher.Api.csproj", "src/ProMatcher.Api/"]
RUN dotnet restore "src/ProMatcher.Api/ProMatcher.Api.csproj"
COPY . .
WORKDIR "/src/src/ProMatcher.Api"
RUN dotnet build "ProMatcher.Api.csproj" -c Release -o /app/build

FROM build AS test
WORKDIR "/src/src/ProMatcher.Domain.Tests"
RUN dotnet test "ProMatcher.Domain.Tests.csproj" 

FROM test AS publish
WORKDIR "/src/src/ProMatcher.Api"
RUN dotnet publish "ProMatcher.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProMatcher.Api.dll"]