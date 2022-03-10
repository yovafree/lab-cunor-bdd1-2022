
### Creación de un controlador a partir de un modelo.

dotnet aspnet-codegenerator controller -name ColaboradorController -actions -api -m Colaborador -dc CunorContext -outDir Controllers

dotnet aspnet-codegenerator controller -name EstudiantesController -actions -api -m Estudiante -dc CunorContext -outDir Controllers

dotnet aspnet-codegenerator controller -name PuestosController -actions -api -m Puesto -dc CunorContext -outDir Controllers

### Scaffold DBContext para el mapeo de la base de datos a objetos.

dotnet ef dbcontext scaffold "Host=localhost;Username=postgres;Password=12345678;Database=cunor;Port=5435" Npgsql.EntityFrameworkCore.PostgreSQL -o Models -f