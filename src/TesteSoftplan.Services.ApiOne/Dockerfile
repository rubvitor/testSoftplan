#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TesteSoftplan.Services.ApiOne/TesteSoftplan.Services.ApiOne.csproj", "TesteSoftplan.Services.ApiOne/"]
RUN dotnet restore "TesteSoftplan.Services.ApiOne/TesteSoftplan.Services.ApiOne.csproj"
COPY . .
WORKDIR "/src/TesteSoftplan.Services.ApiOne"
RUN dotnet build "TesteSoftplan.Services.ApiOne.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TesteSoftplan.Services.ApiOne.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TesteSoftplan.Services.ApiOne.dll"]