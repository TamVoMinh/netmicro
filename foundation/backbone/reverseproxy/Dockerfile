
FROM nginx:1.17.6-alpine as build
WORKDIR /

COPY foundation/backbone/reverseproxy/ .
ARG PUBLIC_ORIGIN
RUN chmod +x /gen-conf.sh &&\
    sh -c "/gen-conf.sh ${PUBLIC_ORIGIN}"

FROM nginx:1.17.6-alpine
COPY --from=build /nginx /etc/nginx
COPY foundation/backbone/reverseproxy/entrypoint.sh /

RUN ["chmod", "+x", "/entrypoint.sh"]
ENTRYPOINT ["/entrypoint.sh"]
