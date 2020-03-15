FROM nginx:1.17.6-alpine
COPY Backbone/ReverseProxy/entrypoint.sh /

RUN ["chmod", "+x", "/entrypoint.sh"]
ENTRYPOINT ["/entrypoint.sh"]
