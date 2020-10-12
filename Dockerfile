FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN dotnet publish "./src/Fibonacci.Web/Fibonacci.Web.csproj" -c Release -r linux-x64 /p:PublishSingleFile=false -o /publish

FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS final
WORKDIR /app/
COPY --from=build /publish .
ENTRYPOINT ["/app/Fibonacci.Web"]
