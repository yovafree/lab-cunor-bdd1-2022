using cunor.api.Models;
using Microsoft.AspNetCore.Mvc;

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
        return _context.Curso.ToArray();
    }

    [HttpPost]
    public void Add(Curso curso){
        _context.Curso.Add(curso);
    }
}
