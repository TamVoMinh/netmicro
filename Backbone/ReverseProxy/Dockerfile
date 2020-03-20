
FROM nginx:1.17.6-alpine as build
WORKDIR /

COPY Backbone/ReverseProxy/ .
ARG PUBLIC_ORIGIN
ARG FOUNDATION
RUN chmod +x /gen-conf.sh &&\
    sh -c "/gen-conf.sh ${PUBLIC_ORIGIN} ${FOUNDATION}"

FROM nginx:1.17.6-alpine
COPY --from=build /nginx /etc/nginx
COPY Backbone/ReverseProxy/entrypoint.sh /

RUN ["chmod", "+x", "/entrypoint.sh"]
ENTRYPOINT ["/entrypoint.sh"]
