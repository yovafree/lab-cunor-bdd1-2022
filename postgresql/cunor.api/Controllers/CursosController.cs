using cunor.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cunor.api.Controllers;

[ApiController]
[Route("[controller]")]
public class CursosController : ControllerBase
{
    private readonly ILogger<CursosController> _logger;
    private readonly CunorContext _context;

    public CursosController(ILogger<CursosController> logger, CunorContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Curso> Get()
    {
        return _context.Cursos.ToArray();
    }

    [HttpPost]
    public void Add(Curso curso){
        _context.Cursos.Add(curso);
        _context.SaveChanges();
    }

    [HttpPut]
    public void Update(Curso curso){
        var item = _context.Cursos.Find(curso.CodCurso);

        if (item != null){
            item.Nombre = curso.Nombre;
            item.Descripcion = curso.Descripcion;
            item.Carrera = curso.Carrera;
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }

    [HttpDelete]
    public void Delete(int id){
        var item = _context.Cursos.Find(id);

        if (item != null){
            _context.Entry(item).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
