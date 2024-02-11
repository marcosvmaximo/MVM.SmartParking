using Microsoft.AspNetCore.Mvc;
using MVM.SmartParking.Application.VeiculosContext.Commands;
using MVM.SmartParking.Application.VeiculosContext.ViewModels;

namespace MVM.SmartParking.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class VeiculosController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CadastrarVeiculo(VeiculoCommand request)
    {
        return Ok();
    }

    [HttpPost("entrada")]
    public async Task<ActionResult<VeiculoViewModel>> MarcarEntrada(MarcarEntradaVeiculoCommand request)
    {
        return Ok();
    }
    
    [HttpPost("saida")]
    public async Task<ActionResult<VeiculoViewModel>> MarcarSaida(MarcarSaidaVeiculoCommand request)
    {
        return Ok();

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VeiculoViewModel>>> ObterVeiculosEstacionados()
    {
        return Ok();

    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<VeiculoViewModel>> ObterVeiculoPorId([FromRoute]Guid id)
    {
        return Ok();
    }
}