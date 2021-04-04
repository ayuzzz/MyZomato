docker build -t myzomato-ui -f DockerFile .
docker run -dp 4200:80 myzomato-ui
echo "`n`n---------------------------------------- myzomato-ui container is up and running---------------------------------------------------`n`n"