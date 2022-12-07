#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Blaze-Or/Blaze-Or.csproj", "Blaze-Or/"]
RUN dotnet restore "Blaze-Or/Blaze-Or.csproj"
COPY . .
WORKDIR "/src/Blaze-Or"
RUN dotnet build "Blaze-Or.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Blaze-Or.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blaze-Or.dll"]