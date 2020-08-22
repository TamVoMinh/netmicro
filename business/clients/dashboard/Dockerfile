FROM nginx:1.17.6-alpine as base
WORKDIR /app


FROM node:10.16.0-alpine as build
WORKDIR /app

COPY business/clients/dashboard /app
RUN yarn install && yarn run build


FROM base as final
COPY --from=build  /app/build .
CMD ["nginx", "-g", "daemon off;"]
