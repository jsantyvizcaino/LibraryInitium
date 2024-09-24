# Proyecto de Librería en .NET 8

Este proyecto es una aplicación de gestión de una librería desarrollada utilizando **.NET 8**. Implementa las mejores prácticas de desarrollo de software, incluyendo **Clean Architecture**, **CQRS**, y **Mediator**, además de manejar autenticación con **JWT** mediante un servicio personalizado.

## Características del Proyecto

- **.NET 8**: Framework principal para el desarrollo de la aplicación.
- **Entity Framework**: Utilizado para la interacción con la base de datos relacional, permitiendo un manejo eficiente y sencillo de las entidades **Usuario** y **Libro**.
- **OData**: Proporciona la capacidad de realizar consultas avanzadas y filtrado dinámico en las API de datos.
- **Mediator**: Patrón implementado para manejar la comunicación entre diferentes capas de la aplicación de manera desacoplada.
- **CQRS (Command Query Responsibility Segregation)**: Separación de las operaciones de escritura y lectura para mejorar la escalabilidad y mantenibilidad.
- **Clean Architecture**: Arquitectura modular que organiza el código en capas bien definidas y desacopladas.
- **DTO Automapper**: Utilizado para mapear de manera eficiente las entidades del dominio a los **Data Transfer Objects (DTO)**.
- **Repositorios e Interfaces**: La aplicación sigue el principio de abstracción utilizando interfaces y repositorios para manejar el acceso a los datos de manera limpia y desacoplada.
- **Middleware de Control de Errores**: Implementado para capturar y manejar excepciones globales, proporcionando respuestas consistentes y detalladas ante errores.

## Autenticación

La autenticación en esta aplicación se maneja mediante **JWT** (JSON Web Token). Se desarrolló un servicio de autenticación que genera un token **Bearer** para el acceso a las API protegidas.

## Estructura del Proyecto

El proyecto está dividido en capas de acuerdo con los principios de **Clean Architecture**:

- **Core**: Contiene las entidades de negocio, las interfaces de los repositorios y los servicios.
- **Application**: Implementa los casos de uso, patrones CQRS, Mediator y lógica de aplicación.
- **Infrastructure**: Maneja la interacción con la base de datos utilizando Entity Framework, así como otros servicios como la autenticación con JWT.
- **API**: Expone las APIs RESTful utilizando OData para las operaciones de consulta avanzadas. Además, se configura el middleware para el manejo de errores.

## Cómo Empezar

1. Clonar el repositorio.
2. Configurar el servidor de la base de datos en el archivo `appsettings.Development.json` dentro de la cadena de conexión.
3. En la carpeta `Inicializadores`, encontrarás:
   - Un **script SQL** que crea la base de datos, las tablas necesarias, y además inserta 10 registros en la tabla **Books**.
   - Un archivo **credenciales.txt** con las credenciales del usuario por defecto.
   - Un archivo **Postman Collection** (`collection.json`) con un conjunto de requests para probar las APIs.
4. Al ejecutar la aplicación, se verificará si hay registros en la tabla **Usuarios**. Si no existen, se ejecutará un método para crear un usuario por defecto.
5. Ejecutar la aplicación:
   ```bash
   dotnet run
