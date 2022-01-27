FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY ./ServiceTemplate.sln ./
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done
RUN dotnet restore
COPY . .
RUN dotnet publish ServiceTemplate.WebApi/ServiceTemplate.WebApi.csproj --no-restore -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "ServiceTemplate.WebApi.dll"]