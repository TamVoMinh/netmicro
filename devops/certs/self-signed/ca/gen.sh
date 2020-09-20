#!/bin/sh

#generate root ca key
openssl genrsa -out ./devops/certs/self-signed/ca/ca.key 2048
#generate root ca cert
openssl req -new -x509 -key ./devops/certs/self-signed/ca/ca.key -out ./devops/certs/self-signed/ca/ca.crt -config ./devops/certs/self-signed/ca/ca.cnf
