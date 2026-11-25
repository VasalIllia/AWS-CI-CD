FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /App

COPY AWS-CI-CD.App/AWS-CI-CD.App.csproj AWS-CI-CD.App/
RUN dotnet restore AWS-CI-CD.App/AWS-CI-CD.App.csproj

COPY AWS-CI-CD.App/ AWS-CI-CD.App/
RUN dotnet publish AWS-CI-CD.App/AWS-CI-CD.App.csproj -c Release --no-restore -o /out

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /App

COPY --from=build /out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "AWS-CI-CD.App.dll"]
