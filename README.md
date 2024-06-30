# SriWebService
Esta solución tiene dos proyectos una biblioteca de clases y un apiwebservice.

+ SriWebService: SriWebServiceTest/SriWebService
+ FacturacionSriApi: SriWebServiceTest/FacturacionSriApi

### FacturacionSriApi
Expone tres endpoints:

Enpoint para ver el estado del api:

+ api/health


Enpoint para procesos de recepcion y autorizacion:

+ api/sri/reception
+ api/sri/authorization

---

Este proyecto se puede levantar desde Rider en http o https, tambien ha sido agregado un **Dockerfile**:


```javascript
docker build -t facturacion_sri_api -f Dockerfile .
docker run -d -p 5191:80 --name facturacion_sri_api_container facturacion_sri_api
