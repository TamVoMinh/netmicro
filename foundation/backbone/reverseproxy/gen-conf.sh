#!/bin/sh

mkdir /nginx
mkdir /nginx/isys
mkdir /nginx/isys/locations

cat /templs/nmro.main.conf | sed "s/@PUBLIC_ORIGIN/$1/g" > /nginx/nginx.conf
cat /templs/isys.conf | sed "s/@PUBLIC_ORIGIN/$1/g" > /nginx/isys/main.conf

echo "ALL PARAMETERS $1"

cat /templs/isys/elk.conf | sed "s/@PUBLIC_ORIGIN/$1/g" > /nginx/isys/locations/elk.conf

