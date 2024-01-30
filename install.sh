docker-compose build 
docker-compose up db -d 
docker-compose up kibana -d


ping 127.0.0.1 -n 30 > ttl 
sleep 10

docker-compose up api  -d 

echo "Go to: http://localhost:7201/swagger"

echo "Hold On.... Running Kibana and Elasticsearch"
sleep 20
echo "Elasticsearch to: http://localhost:9200"
echo "Kibana to: http://localhost:5601"

