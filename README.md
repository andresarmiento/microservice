<h3 align="center">Microservice C# </h3>

<h3 align="left">Connect with me:</h3>
<p align="left">
<a href="https://linkedin.com/in/andres-felipe-sarmiento-suarez" target="blank"><img align="center" src="https://raw.githubusercontent.com/rahuldkjain/github-profile-readme-generator/master/src/images/icons/Social/linked-in-alt.svg" alt="andres-felipe-sarmiento-suarez" height="30" width="40" /></a>
</p>

<h3 align="left">Languages and Tools:</h3>
<p align="left"> <a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> </a> <a href="https://www.docker.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/docker/docker-original-wordmark.svg" alt="docker" width="40" height="40"/> </a> <a href="https://www.mysql.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/mysql/mysql-original-wordmark.svg" alt="mysql" width="40" height="40"/> </a> </p>
<br>
<h3 align="left">Creacion de imagen</h3>
<p>
  docker-compose build
</p>
<br>
<h3 align="left">Creacion de contenedor</h3>
<p>
 estructura de conexion para base de datos mysql
server=mysql;port=3306;database=RetoPica;user=root;password=root;old guids=true;default command timeout=800

docker run -p {Puerto}:80 -d -e "ASPNETCORE_ENVIRONMENT=Development" -e "ConnectionStrings:ConexionDatabase={Cadena de conexion}" --name {Nombre de Contenedor} microservicecontainer:latest

Ejemplo:

docker run -p 7001:80 -d -e "ASPNETCORE_ENVIRONMENT=Development" -e "ConnectionStrings:ConexionDatabase=server=mysql;port=3306;database=RetoPica;user=root;password=root;old guids=true;default command timeout=800" --name Service1Test microservicecontainer:latest

</p>
<br>
<h3 align="left">Asignacion de Red mysql</h3>
<p>
 docker stop {Nombre de Contenedor}
docker network connect {IdRed} {Nombre de Contenedor}
docker start {Nombre de Contenedor}

Ejemplo:

docker stop Service1Test
docker network connect e53898440d0cd9204f56148e8b9de248fc1e6c55f66f148d8ddcf3cdb3c937fe Service1Test
docker start Service1Test
</p>
