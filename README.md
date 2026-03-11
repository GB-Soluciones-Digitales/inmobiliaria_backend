# 🏡 Inmobiliaria API - Backend

API RESTful robusta y escalable desarrollada con **.NET 9**. Diseñada bajo los principios de **Clean Architecture**, este servicio actúa como el motor principal de la plataforma, gestionando el catálogo de propiedades, procesamiento multimedia server-side y autenticación segura.

![.NET](https://img.shields.io/badge/.NET-9.0-purple)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-Supabase-blue)
![Docker](https://img.shields.io/badge/Docker-Koyeb-2496ED)
![Status](https://img.shields.io/badge/Status-Production-green)

## 🏗️ Arquitectura y Patrones

El proyecto está estructurado para garantizar el bajo acoplamiento y la alta cohesión:
* **Domain:** Entidades core y reglas de negocio.
* **Application:** Casos de uso e interfaces (CQRS / MediatR - *si aplica*).
* **Infrastructure:** Acceso a datos, integraciones externas (Cloudinary) y persistencia.
* **API:** Controladores, inyección de dependencias y middlewares.

## 🛠️ Tecnologías

* **Core:** ASP.NET Core Web API (.NET 9).
* **Base de Datos:** PostgreSQL (alojada en Supabase).
* **ORM:** Entity Framework Core (Code First).
* **Almacenamiento Multimedia:** Cloudinary API (con transformaciones WebP al vuelo)
* **Seguridad:** Autenticación y Autorización basada en JWT
* **Infraestructura:** Docker + Koyeb

## 🚀 Instalación y Ejecución Local

1.  **Clonar el repositorio:**
    ```bash
    git clone [https://github.com/Brian13b/inmobiliaria-backend.git](https://github.com/Brian13b/inmobiliaria-backend.git)
    cd inmobiliaria-backend
    ```

2.  **Configurar Variables de Entorno:**
    Renombrar `appsettings.json.example` a `appsettings.json` y configurar la cadena de conexión de Supabase y claves JWT.
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Host=aws-0-us-west-2.pooler.supabase.com;Port=6543;Database=postgres;..."
    }
    ```

3.  **Aplicar Migraciones (Base de Datos):**
    ```bash
    dotnet ef database update --project Inmobiliaria.Infrastructure --startup-project Inmobiliaria.API
    ```

4.  **Ejecutar:**
    ```bash
    dotnet run --project Inmobiliaria.API
    ```

## 🗺️ Roadmap & Updates

Estado actual del desarrollo y planes futuros.

### ✅ Versión 1.0 (Lanzamiento Actual)
- [x] Arquitectura limpia (Domain, Infrastructure, API).
- [x] CRUD completo de Propiedades.
- [x] Integración con Base de Datos PostgreSQL (Supabase).
- [x] Filtrado avanzado (Precio, Tipo, Operación, Ambientes).
- [x] Despliegue continuo en Koyeb mediante Docker.
- [x] Autenticación JWT para endpoints administrativos.
- [x] Optimización server-side de imágenes (Cloudinary/WebP).
- [x] Contenerización (Docker) y despliegue en Koyeb.

### 🚧 En Progreso (v1.1)
- [ ] Implementación de `MailingService` para formularios de contacto.

### 🔮 Futuro (v2.0)
- [ ] Sistema de "Favoritos" para usuarios registrados.
- [ ] Integración con mapas interactivos (GeoLocation API).
- [ ] Tests Unitarios (xUnit) y de Integración.

## 📄 Licencia
Este proyecto está bajo la Licencia MIT.