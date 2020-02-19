#!/bin/bash
sed -i '127.0.0.1  nmro.local'          /etc/hosts
sed -i '127.0.0.1  oidc.nmro.local'     /etc/hosts
sed -i '127.0.0.1  api.nmro.local'      /etc/hosts
sed -i '127.0.0.1  kibana.nmro.local'   /etc/hosts
sed -i '127.0.0.1  docs.nmro.local'     /etc/hosts
sed -i '127.0.0.1  health.nmro.local'   /etc/hosts

