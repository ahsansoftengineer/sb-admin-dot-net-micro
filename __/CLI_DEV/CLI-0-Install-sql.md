### Network of Docker, Redis, RabbitMQ
```bash
docker network create sba-dev-network
```

### DOCKER SQL
```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest
docker image ls
docker run --name sba-dev-sql --network sba-dev-network -p 1430:1433  -e 'HOMEBREW_NO_ENV_FILTERING=1' -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=P@55w0rd!123' -d mcr.microsoft.com/mssql/server:2022-latest

docker stop sba-dev-sql
docker rm sba-dev-sql

docker container ls
docker ps
```
### DOCKER Redis
#### Caching Criteria
- Cache CUDS            [CacheKey = api/hierarchy/v1/contrller/1]
- Cache Single          [CacheKey = api/hierarchy/v1/contrller/1]
- Cache Full List       [CacheKey = api/hierarchy/v1/contrller/list]
- Cache Full Options    [CacheKey = api/hierarchy/v1/contrller/options]
- Cache Full Dictionary [CacheKey = api/hierarchy/v1/contrller/dictonary]
```bash
docker pull redis
# docker run --name sba-redis-srvr -p 6379:6379 -d redis
docker run --name sba-dev-redis --network sba-dev-network -p 6379:6379 -d redis redis-server --requirepass 'P@55w0rd!123'
docker stop sba-redis-dev
docker rm sba-redis-dev
sudo apt install redis-tools

redis-cli -a 'P@55w0rd!123'
set myKey Ahsan
get myKey
```
### Rabbit MQ
```bash
docker run -d --name sba-dev-rmq --hostname sba-rmq-host-dev --network sba-dev-network  -p 5672:5672 -p 15672:15672 rabbitmq:3-management
# docker run -d --name sba-rmq-dev --hostname sba-rmq-host-dev -p 5672:5672 -p 15672:15672 -e RABBITMQ_SERVER_ADDITIONAL_ERL_ARGS='-rabbitmq_management listener [{port,15672},{ip,"0.0.0.0"}]' rabbitmq:3-management

docker start sba-rmq-dev
docker stop sba-rmq-dev
docker rm sba-rmq-dev

```