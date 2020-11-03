#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["XafBlazorDocker.Blazor.Server/XafBlazorDocker.Blazor.Server.csproj", "XafBlazorDocker.Blazor.Server/"]
COPY ["XafBlazorDocker.Blazor.Server/nuget.config", "XafBlazorDocker.Blazor.Server/"]
COPY ["XafBlazorDocker.Module.Blazor/XafBlazorDocker.Module.Blazor.csproj", "XafBlazorDocker.Module.Blazor/"]
COPY ["XafBlazorDocker.Module/XafBlazorDocker.Module.csproj", "XafBlazorDocker.Module/"]
RUN dotnet restore "XafBlazorDocker.Blazor.Server/XafBlazorDocker.Blazor.Server.csproj"
COPY . .
WORKDIR "/src/XafBlazorDocker.Blazor.Server"
RUN dotnet build "XafBlazorDocker.Blazor.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "XafBlazorDocker.Blazor.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "XafBlazorDocker.Blazor.Server.dll"]