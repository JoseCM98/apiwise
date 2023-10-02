
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

RUN apt-get update \ 
    && apt-get install -y --no-install-recommends libgdiplus libc6-dev \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*
RUN cd /usr/lib && ln -s libgdiplus.so gdiplus.dll

WORKDIR /app

RUN mkdir -p /app/Logs/Error
RUN mkdir -p /app/Logs/Info
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["apiwise.csproj", "."]
RUN dotnet restore "apiwise.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "apiwise.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "apiwise.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "apiwise.dll"]

