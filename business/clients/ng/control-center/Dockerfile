FROM nginx:1.17.6-alpine as base
WORKDIR /app


FROM node:10.16.0-alpine as build
WORKDIR /workspace

COPY business/clients/ng/control-center/ /workspace
RUN yarn install && yarn build --prod

FROM base as final
COPY --from=build  /workspace/dist/control-center .
CMD ["nginx", "-g", "daemon off;"]
