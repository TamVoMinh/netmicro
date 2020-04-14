ARG ELK_VERSION

# https://github.com/elastic/logstash-docker
FROM docker.elastic.co/logstash/logstash:${ELK_VERSION}
# Add logstash plugins
RUN bin/logstash-plugin install logstash-output-http
