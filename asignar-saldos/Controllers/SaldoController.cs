using asignar_saldos.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SaldoController : ControllerBase
{
    private readonly SaldoService _saldoService;

    public SaldoController(SaldoService saldoService)
    {
        _saldoService = saldoService;
    }

    // Endpoint para obtener los saldos asignados a los gestores
    [HttpGet("asignar-saldos")]
    public IActionResult AsignarSaldosAGestores()
    {
        var saldosAsignados = _saldoService.AsignarSaldosAGestores();
        return Ok(saldosAsignados);
    }
}

