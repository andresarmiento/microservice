##Creacion de imagen

docker-compose build

##Creacion de contenedor
estructura de conexion para base de datos mysql
server=mysql;port=3306;database=RetoPica;user=root;password=root;old guids=true;default command timeout=800

docker run -p {Puerto}:80 -d -e "ASPNETCORE_ENVIRONMENT=Development" -e "ConnectionStrings:ConexionDatabase={Cadena de conexion}" --name {Nombre de Contenedor} microservicecontainer:latest

Ejemplo:

docker run -p 7001:80 -d -e "ASPNETCORE_ENVIRONMENT=Development" -e "ConnectionStrings:ConexionDatabase=server=mysql;port=3306;database=RetoPica;user=root;password=root;old guids=true;default command timeout=800" --name Service1Test microservicecontainer:latest


## Asignacion de Red mysql

docker stop {Nombre de Contenedor}
docker network connect {IdRed} {Nombre de Contenedor}
docker start {Nombre de Contenedor}

Ejemplo:

docker stop Service1Test
docker network connect e53898440d0cd9204f56148e8b9de248fc1e6c55f66f148d8ddcf3cdb3c937fe Service1Test
docker start Service1Test


## Crear tabla en base de datos
es necesario actualizar la cadena de conexion ubicada en appsettings.json, se debe cambiar la configuracion para acceder al servidor de mysql bajo la siguiente estructura
server=[servidor];port=[puerto];database=[Base de datos];user=[usuario];password=[password];old guids=true;default command timeout=800;

Ejemplo:
 "ConnectionStrings": {
    "ConexionDatabase": "server=localhost;port=3306;database=RetoPica;user=root;password=root;old guids=true;default command timeout=800;"
  }

## Ejecutar script en base de datos
para crear la tabla o aplicar cambios en el modelo es necesario ejecutar el siguiente script

dotnet ef --startup-project MicroServiceContainer  database update --project Dominio.Infraestructura



## Crear migraciones para modelo
si se realizan cambios obre el modelo es necesario crear migraciones para generar los scripts de actualizacion hacia base de datos para esto es necesario ejecutar el siguiente 
script el cual es el encargado de crear una nueva migracion; para ejecutar cambios en la base de datos realizar paso anterior despues de generar migracion 

dotnet ef --startup-project MicroServiceContainer  migrations add MigrationsMySqlInicial --project Dominio.Infraestructura
