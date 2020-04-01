FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base

LABEL version="1.0" maintainer="testedaniel"

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TCC.PUC.SCA.API/TCC.PUC.SCA.API.csproj", "TCC.PUC.SCA.API/"]
COPY ["TCC.PUC.SCA.Model/TCC.PUC.SCA.Model.csproj", "TCC.PUC.SCA.Model/"]
COPY ["TCC.PUC.SCA.Business/TCC.PUC.SCA.Business.csproj", "TCC.PUC.SCA.Business/"]
COPY ["TCC.PUC.SCA.Data/TCC.PUC.SCA.Data.csproj", "TCC.PUC.SCA.Data/"]
RUN dotnet restore "TCC.PUC.SCA.API/TCC.PUC.SCA.API.csproj"
COPY . .
WORKDIR "/src/TCC.PUC.SCA.API"
RUN dotnet build "TCC.PUC.SCA.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TCC.PUC.SCA.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TCC.PUC.SCA.API.dll"]