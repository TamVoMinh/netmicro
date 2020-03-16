#!/bin/sh

cat /etc/nginx/templs/nmro.main.conf | sed "s/@PUBLIC_ORIGIN/${PUBLIC_ORIGIN}/g" > /etc/nginx/nginx.conf

exec nginx-debug -g 'daemon off;'
