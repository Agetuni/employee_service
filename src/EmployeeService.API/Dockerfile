#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/EmployeeService.API/EmployeeService.API.csproj", "src/EmployeeService.API/"]
COPY ["src/EmployeeService.Application/EmployeeService.Application.csproj", "src/EmployeeService.Application/"]
COPY ["EmployeeService.Infrastructure/EmployeeService.Infrastructure.csproj", "EmployeeService.Infrastructure/"]
RUN dotnet restore "src/EmployeeService.API/EmployeeService.API.csproj"
COPY . .
WORKDIR "/src/src/EmployeeService.API"
RUN dotnet build "EmployeeService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeService.API.dll"]