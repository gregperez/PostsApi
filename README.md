<p align="center">
  <a href="https://dotnet.microsoft.com/es-es/" target="blank"><img src="https://upload.wikimedia.org/wikipedia/commons/7/7d/Microsoft_.NET_logo.svg" width="200" alt=".NET Logo" /></a>
</p>


# Posts API

1. Clonar el proyecto
2. Ejecutar migración inicial para BD
```
dotnet ef migrations add InitialCreate
```
3. Clonar el archivo ```.env.template``` y renombralo a ```.env```
4. Configurar las variables de entorno
5. Levantar la base de datos
```
docker-compose up -d db
```

6. Compilar y ejecutar la API
```
docker compose build
docker compose up posts_api
```

7. Actualizar BD
```
dotnet ef database update
```
