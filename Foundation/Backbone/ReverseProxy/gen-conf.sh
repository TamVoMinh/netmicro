#!/bin/sh

mkdir /nginx
mkdir /nginx/isys
mkdir /nginx/isys/locations

cat /templs/nmro.main.conf | sed "s/@PUBLIC_ORIGIN/$1/g" > /nginx/nginx.conf
cat /templs/isys.conf | sed "s/@PUBLIC_ORIGIN/$1/g" > /nginx/isys/main.conf

echo "ALL PARAMETERS $1 $2"
echo "USE $2 AS FOUNDATION SERVICES"

if [ "$2" == "ELK" ] ;then
    cat /templs/isys/elk.conf | sed "s/@PUBLIC_ORIGIN/$1/g" > /nginx/isys/locations/elk.conf
else
    cat /templs/isys/dozzle.conf | sed "s/@PUBLIC_ORIGIN/$1/g" > /nginx/isys/locations/dozzle.conf
fi
