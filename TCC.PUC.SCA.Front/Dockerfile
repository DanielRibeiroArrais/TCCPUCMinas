FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TCC.PUC.SCA.Front/TCC.PUC.SCA.Front.csproj", "TCC.PUC.SCA.Front/"]
RUN dotnet restore "TCC.PUC.SCA.Front/TCC.PUC.SCA.Front.csproj"
COPY . .
WORKDIR "/src/TCC.PUC.SCA.Front"
RUN dotnet build "TCC.PUC.SCA.Front.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TCC.PUC.SCA.Front.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TCC.PUC.SCA.Front.dll"]