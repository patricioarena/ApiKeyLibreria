### Introducción
Libreria para autenticación que realiza la consulta al servicio Apikey.
###
### Instalacion
###
Instalar mediante el administrador de paquetes nuget. Si no tiene agregado el server nuget del CIFE. [Ver documentación](https://github.com/patricioarena/images/blob/master/Nop/no-no-no.gif?raw=true)
###
### Compilar y probar
Agregar atributo sobre el metodo del controller que se desea autenticar usando el servicio apikey.

**ApplicationId**: consultar en el servicio de apikey
**UrlEndpoint**: para setear este parametro se puede utilizar la parametrizaion provista, es decir, **UrlEndpoint**.***Testing***, **UrlEndpoint**.***UAT***, **UrlEndpoint**.***Production***.
También se puede establecer una url como string, es decir, UrlEndpoint = "http://serviciosdev/algo/algo.."

Ejemplo:

![](https://github.com/patricioarena/images/blob/master/ApiKey/1.png)

Para probar que funcione correctamente usar postman o cualquier cliente rest y agregar en los header el clientId y la apikey correspondiente.

Ejemplo:

![](https://github.com/patricioarena/images/blob/master/ApiKey/2.png)

### Nota
Para generar key, gestionar o ver logs de errores.
- [Ver documentación](https://github.com/patricioarena/ApiKeyServicio)
- [Ver servicio](https://github.com/patricioarena/images/blob/master/Nop/no-no-no.gif?raw=true)
