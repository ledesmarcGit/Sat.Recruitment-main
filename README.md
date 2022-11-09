# SAT Recruitment

El objetivo de esta prueba es refactorizar el código de este proyecto.
Se puede realizar cualquier cambio que considere necesario en el código y en los test.


## Requisitos 

- Todos los test deben pasar.
- El código debe seguir los principios de la programación orientada a objetos (SOLID, DRY, etc...).
- El código resultante debe ser mantenible y extensible.





Decidí implementar para este proyecto la arquitectura "Onion Architecture" para asegurarme que sea mantenible y facilmente 
extensible, esta arquitectura me permitio controlar el acoplamiento entre clases además esta indudablemente sesgada 
hacia la programación orientada a objetos y antepone los objetos a todos los demas.
Se tuvo en cuenta el principio de inyección de dependencias en todo el código para evitar el acoplamiento.

Capas implementadas:

-Capa de dominio (Domain): Centro de la arquitectura, contiene todas las entidades del dominio, son planos sin lógica 
compleja

-Servicios de dominio(Application):Encargada de definir las interfaces para permitir almacenar y recuperar objetos, 
y de las reglas de negocio.

-Capa Persistence: Aquí estan las implementaciones de las interfaces definidas en la capa Application, esta capa permitira 
facilmente implementar una base de datos.

-WebAPI: Aquí esta todo lo relacionado con la lógica de presentación, controladores, middlewares y el acceso a la API.

-Test.


 Implementé el patron CQRS, separando las operaciones de lectura y escritura esto permite aplicar uno de los principios SOLID
 de responsabilida única.
Implementé el patron Mediator, me permitio reducir las dependencias entre objetos mediante un objeto mediador.

La Api se puede probar mediante Swagger.

Se actualizo a NET 6.

Librerias utilizadas

MediatR-> Patron Mediator

AutoMapper -> Mapeo de objetos, DTO.

FluentValidation -> Validaciones fuertemente tipadas.

XUnit -> Tests

Para una próxima iteración del proyecto se podría implementar una base de datos y seguridad mediante JWT.

Nota: setear WebAPI como proyecto de inicio.

Autor: Marcos Ledesma.-
Email: ledesmarc@hotmail.com
