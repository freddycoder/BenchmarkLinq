FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /src

# Copy everything
COPY . ./

RUN dotnet restore

RUN dotnet build -c Release -o /src/bin
RUN dotnet publish -c Release -o /src/bin/publish

WORKDIR /src/bin/publish
ENTRYPOINT ["dotnet", "BenchmarkLinq.dll"]
