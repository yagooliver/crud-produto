FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
WORKDIR /app
EXPOSE 80/tcp

RUN apk add libgdiplus --update-cache --repository http://dl-3.alpinelinux.org/alpine/edge/testing/ --allow-untrusted && \
    apk add terminus-font && \
    apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT false

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build-env
COPY ["./CrudBackend.sln", "./"]
COPY ["./CrudBackend.Domain.Core.Shared/CrudBackend.Domain.Core.Shared.csproj", "./CrudBackend.Domain.Core.Shared/" ]
COPY ["./CrudBackend.Domain.Core/CrudBackend.Domain.Core.csproj", "./CrudBackend.Domain.Core/" ]
COPY ["./CrudBackend.Infra.CrossCutting.IOC/CrudBackend.Infra.CrossCutting.IOC.csproj", "./CrudBackend.Infra.CrossCutting.IOC/" ]
COPY ["./CrudBackend.Infra.CrossCutting.Bus/CrudBackend.Infra.CrossCutting.Bus.csproj", "./CrudBackend.Infra.CrossCutting.Bus/" ]
COPY ["./CrudBackend.Infra.Data/CrudBackend.Infra.Data.csproj", "./CrudBackend.Infra.Data/" ]
COPY ["./CrudBackend.Application/CrudBackend.Application.csproj", "./CrudBackend.Application/" ]
COPY ["./CrudBackend.Web.Api/CrudBackend.Web.Api.csproj", "./CrudBackend.Web.Api/" ]
RUN dotnet restore "./CrudBackend.Web.Api/CrudBackend.Web.Api.csproj"
COPY ./ .

RUN dotnet build "./CrudBackend.Web.Api/CrudBackend.Web.Api.csproj" --packages ./.nuget/packages -c Release -o /app/build

RUN dotnet test

FROM build-env AS publish
RUN dotnet publish "./CrudBackend.Web.Api/CrudBackend.Web.Api.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app/build
RUN chmod +x ./

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "CrudBackend.Web.Api.dll", "--server.urls", "http://*:80"]