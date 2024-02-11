using Microsoft.AspNetCore.Mvc;
using MVM.SmartParking.Application.EmpresasContext.Commands;
using MVM.SmartParking.Application.EmpresasContext.ViewModels;

namespace MVM.SmartParking.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmpresasController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> ObterTodasEmpresas()
    {
        return Ok();
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<EmpresaViewModel>> ObterEmpresaPorId([FromRoute]Guid id)
    {
        return Ok();

    }
    
    [HttpPost]
    public async Task<ActionResult> CadastrarEmpresa([FromBody]EmpresaCommand request)
    {
        return Ok();

    }
    
    [HttpPut("contato")]
    public async Task<ActionResult> AtualizarContatoEmpresa([FromBody]ContatoCommand request)
    {
        return Ok();

    }
    
    [HttpPut("endereco")]
    public async Task<ActionResult> AtualizarEnderecoEmpresa([FromBody]EnderecoCommand request)
    {
        return Ok();

    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeletarEmpresa([FromRoute]Guid id)
    {
        return Ok();

    }
}