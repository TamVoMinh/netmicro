 #!/bin/sh
all_args=("$@")
cmd_arg=$1
opt_arg=$2
rest_args=("${all_args[@]:2}")

allowed_cmds=(build up down)
match_cmd=$(echo "${allowed_cmds[@]:0}" | grep -o $cmd_arg)
if [ ! -z $match_cmd ];
then
    . cli/dcb-list.sh
    . cli/load_dotenv.sh

    echo "docker-compose [$FOUNDATION]" $cmd_arg $opt_arg ${rest_args[@]}
    if [ $FOUNDATION == "ELK" ];
    then
        docker-compose ${_COMPOSES[*]} -f Foundation/Elk/docker-compose.yml $cmd_arg $opt_arg ${rest_args[@]}
    else
        docker-compose ${_COMPOSES[*]} -f Foundation/Dozzle/docker-compose.yml $cmd_arg $opt_arg ${rest_args[@]}
    fi
    docker image prune --filter "dangling=true"
elif [ $cmd_arg = "clear" ]
then
    docker stop $(docker ps -q) | docker rm $(docker ps -aq)
    docker rmi $(docker images | grep "nmro" | awk '{print $3}')
    docker rmi slnbased
    docker image prune --filter "dangling=true"
fi
