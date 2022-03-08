
### Creación de un controlador a partir de un modelo.

dotnet aspnet-codegenerator controller -name ColaboradorController -actions -api -m Colaborador -dc CunorContext -outDir Controllers

dotnet aspnet-codegenerator controller -name EstudiantesController -actions -api -m Estudiante -dc CunorContext -outDir Controllers

dotnet aspnet-codegenerator controller -name PuestosController -actions -api -m Puesto -dc CunorContext -outDir Controllers