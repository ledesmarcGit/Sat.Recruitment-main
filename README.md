# SAT Recruitment

El objetivo de esta prueba es refactorizar el código de este proyecto.
Se puede realizar cualquier cambio que considere necesario en el código y en los test.


## Requisitos 

- Todos los test deben pasar.
- El código debe seguir los principios de la programación orientada a objetos (SOLID, DRY, etc...).
- El código resultante debe ser mantenible y extensible.





Decidi implementar para este proyecto la arquitectura "Onion Architecture" para asegurarme que sea mantenible y facilmente 
extensible,esta arquitectura me permitio controlar el acoplamiento entre clases ademas esta indudablemente sesgada 
hacia la programacion orientada a objetos y antepone los objetos a todos los demas.
Se tuvo en cuenta el principio de inyeccion de dependencias en todo el codigo para evitar el acoplamiento.

Capas implementadas:
-Capa de dominio (Domain): Centro de la arquitectura, contiene todas las entidades del dominio, son planos sin logica 
compleja
-Servicios de dominio(Application):Encargada de definir las interfaces para permitir almacenar y recuperar objetos, 
y de las reglas de negocio.
-Capa Persistence:Aqui estan las implementaciones de las interfaces definidas en la capa Application, esta capa permitira 
facilmente implementar una base de datos.
-WebAPI: Aqui esta todo lo relacionado con la logica de presentacion, controladores, middlewares y el acceso a la API.
-Test.

 Implemente el patron CQRS, separando las operaciones de lectura y escritura esto permite aplicar uno de los principios SOLID
 de responsabilida unica.
 Implemente el patron Mediator, me permitio reducir las dependencias entre objetos mediante un objeto mediador.
 La Api se puede probar mediante Swagger.

Se actualizo a NET 6.

Librerias utilizadas
MediatR-> Patron Mediator
AutoMapper -> Mapeo de objetos, DTO.
FluentValidation -> Validaciones fuertemente tipadas.
XUnit -> Tests

Para una proxima iteracion del proyecto se podria implementar una base de datos y seguridad mediante JWT.

Autor: Marcos Ledesma.-
Email: ledesmarc@hotmail.com
