var builder = DistributedApplication.CreateBuilder(args);

// 1. Infraestructura base (Aspire descargará y gestionará los contenedores automáticamente)
var postgres = builder.AddPostgres("polyglots-db")
    .WithDataVolume("polyglots-postgres-data"); // Persistencia local

var db = postgres.AddDatabase("polyglots-dev-db");

var redis = builder.AddRedis("polyglots-cache");

var rabbitmq = builder.AddRabbitMQ("polyglots-broker");

// 2. Microservicios del Backend
var api = builder.AddProject<Projects.Polyglots_Presentation_WebAPI>("polyglots-api")
    .WithReference(db)      // Inyecta automáticamente la cadena de conexión
    .WithReference(redis)   // Inyecta la configuración de Redis
    .WithReference(rabbitmq); // Inyecta la configuración de RabbitMQ

// 3. Frontend (Blazor WASM)
builder.AddProject<Projects.Polyglots_Presentation_WebApp>("polyglots-web")
    .WithReference(api); // Permite al frontend descubrir la URL de la API dinámicamente

builder.Build().Run();