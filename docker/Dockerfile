FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build

ARG APP_NAME

WORKDIR /app

COPY ./src/${APP_NAME} .

RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview

ARG APP_NAME
ENV APP_NAME=${APP_NAME}

WORKDIR /app

COPY --from=build /app/out .

EXPOSE 8080

ENTRYPOINT sh -c "dotnet ${APP_NAME}.dll"