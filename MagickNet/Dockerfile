FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MagickNet/MagickNet.csproj", "MagickNet/"]
RUN dotnet restore "MagickNet/MagickNet.csproj"
COPY . .
WORKDIR "/src/MagickNet"
RUN dotnet build "MagickNet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MagickNet.csproj" -c Release -o /app/publish --use-current-runtime

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MagickNet.dll"]
