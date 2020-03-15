 #!/bin/sh
all_args=("$@")
cmd_arg=$1
opt_arg=$2
rest_args=("${all_args[@]:2}")


allowed_cmds=(build up down)
match_cmd=$(echo "${allowed_cmds[@]:0}" | grep -o $cmd_arg)
if [ ! -z $match_cmd ]; then
    echo "docker-compose" $cmd_arg $opt_arg ${rest_args[@]}
    . cli/dcb-list.sh
    docker-compose ${_COMPOSES[*]} $cmd_arg $opt_arg ${rest_args[@]}
fi

docker image prune --filter "dangling=true"
