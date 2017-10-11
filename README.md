# ![Logo](http://portal.iradius.es/CustomerFiles/Image/31) Project Description
IRadiusApiClient está formado por tres proyectos desarrollados con c# en .NET que tienen como objetivo mostrar el acceso de cliente a la API de IRadius. IRadius es la solución cloud de WiFi y Hotspots que permite la integración con redes sociales y aplicaciones y sistemas propios. De esta forma es posible la generación de credenciales de acceso a la red WiFi en base a parámetros propios como podrían ser el tiempo de estancia de un huésped, o el importe gastado por un cliente.

Para acceder a la API de IRadius requiere un token válido generado por la plataforma de IRadius. puede consultar la información del producto en http://www.iradius.es

Puede contactar con el departamento de soporte de IRadius para solicitar una cuenta de prueba en info@iradius.es.

## Comenzar
-------
Puede acceder a la API de IRadius compilando y referenciando el proyecto IRadiusApiClientLib https://github.com/ibertic/IRadiusApiClient/tree/master2/IRadiusApiClientLib.

## Ejemplo:
```c#
//Using to IRadius Api CLient Lib
using Ibertic.Iradius.Api.Client;
​
public class ApiManager
{
    private const string apiurl = "http://api.iradius.es";

    public string Token { get; set; }
    public ApiClient ApiClient { get; set}

  public ApiManager( string token)
    {
        this.Token = token;
        ApiClient = new ApiClient(apiurl, token);
    }
}
```

Authors & License
-----------------
This package is released under an open source MIT license.
