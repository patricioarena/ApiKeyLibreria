### Introducción
Libreria para autenticación que realiza la consulta al servicio Apikey.
###
### Instalacion
###
Instalar mediante el administrador de paquetes nuget. Si no tiene agregado el server nuget del CIFE.  [Ver documentación](https://devs.fepba.gov.ar/tfs/Documentacion/Documentaci%C3%B3n%20T%C3%A9cnica/_wiki/wikis/Documentaci%C3%B3n-T%C3%A9cnica.wiki?wikiVersion=GBwikiMaster&pagePath=%2FAgregar%20CIFE%20NugetServer%20a%20VisualStudio)
###
### Compilar y probar
Agregar atributo sobre el metodo del controller que se desea autenticar usando el servicio apikey.

**ApplicationId**: consultar en el servicio de apikey
**UrlEndpoint**: para setear este parametro se puede utilizar la parametrizaion provista, es decir, **UrlEndpoint**.***Testing***, **UrlEndpoint**.***UAT***, **UrlEndpoint**.***Production***.
También se puede establecer una url como string, es decir, UrlEndpoint = "http://serviciosdev/algo/algo.."

Ejemplo:

![](https://github.com/patricioarena/ApiKeyLibreria/blob/master/images/1.png)

Para probar que funcione correctamente usar postman o cualquier cliente rest y agregar en los header el clientId y la apikey correspondiente.

Ejemplo:

![](https://github.com/patricioarena/ApiKeyLibreria/blob/master/images/1.png)

### Nota
Para generar key, gestionar o ver logs de errores.
- [Ver documentación](https://devs.fepba.gov.ar/tfs/Perifericos/APIKEY)
- [Ver servicio](http://serviciosdev.fepba.gov.ar/ApiKey/swagger/index.html)
