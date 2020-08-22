FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

COPY --from=build-env ./ .

ENTRYPOINT ["dotnet", "orderserviceapi.dll"]