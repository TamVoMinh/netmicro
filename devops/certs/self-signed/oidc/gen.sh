#!/bin/sh
#generate privage key
openssl genrsa -out ./devops/certs/self-signed/oidc/oidc.nmro.local.key 2048
#generate certificate signing Request
openssl req -config ./devops/certs/self-signed/oidc/csr.cnf -new  -key ./devops/certs/self-signed/oidc/oidc.nmro.local.key -out ./devops/certs/self-signed/oidc/oidc.nmro.local.csr -verbose
#sign to CSR
openssl x509 -req -in ./devops/certs/self-signed/oidc/oidc.nmro.local.csr -CA ./devops/certs/self-signed/ca/ca.crt -CAkey ./devops/certs/self-signed/ca/ca.key -CAcreateserial -out ./devops/certs/self-signed/oidc/oidc.nmro.local.crt
#create pfx for exchange
openssl pkcs12 -export -out ./devops/certs/self-signed/oidc/oidc.nmro.local.pfx -inkey ./devops/certs/self-signed/oidc/oidc.nmro.local.key -in ./devops/certs/self-signed/oidc/oidc.nmro.local.crt

