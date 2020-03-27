FROM mcr.microsoft.com/dotnet/core/runtime:3.1-alpine
COPY ./publish/ app/
ENTRYPOINT ["dotnet","app/AzureLab.MailAlert.dll"]