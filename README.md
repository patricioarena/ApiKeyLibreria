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

![](https://devs.fepba.gov.ar/tfs/Perifericos/b0e7231e-55d8-4fd6-a012-888f5d25ba96/_api/_versioncontrol/itemContent?repositoryId=801bd68f-f581-44d1-bdf3-f259df1c02e3&path=%2Fimages%2F1.png&version=GBmaster&contentOnly=true&__v=5)

Para probar que funcione correctamente usar postman o cualquier cliente rest y agregar en los header el clientId y la apikey correspondiente.

Ejemplo:

![](https://devs.fepba.gov.ar/tfs/Perifericos/b0e7231e-55d8-4fd6-a012-888f5d25ba96/_api/_versioncontrol/itemContent?repositoryId=801bd68f-f581-44d1-bdf3-f259df1c02e3&path=%2Fimages%2F2.png&version=GBmaster&contentOnly=true&__v=5)

### Nota
Para generar key, gestionar o ver logs de errores.
- [Ver documentación](https://devs.fepba.gov.ar/tfs/Perifericos/APIKEY)
- [Ver servicio](http://serviciosdev.fepba.gov.ar/ApiKey/swagger/index.html)