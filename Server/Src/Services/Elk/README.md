# RUN ELK stack
```bash
   $ docker-compose -f docker-compose.yml up -d
```
# Remove containers
```bash
   $ docker-compose stop && docker-compose rm -f
```
# Ship logging file to logstash
```bash
   $ nc localhost 5000 < /path/to/logfile.log
```