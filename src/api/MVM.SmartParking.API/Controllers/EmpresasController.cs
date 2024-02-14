using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVM.SmartParking.Application.EmpresasContext.Commands;
using MVM.SmartParking.Application.EmpresasContext.ViewModels;
using MVM.SmartParking.Business.Entities;
using MVM.SmartParking.Business.Interfaces;

namespace MVM.SmartParking.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmpresasController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IEmpresaRepository _repository;

    public EmpresasController(IMediator mediator, IEmpresaRepository repository)
    {
        _mediator = mediator;
        _repository = repository;
    }
    
    [HttpGet]
    public async Task<ActionResult> ObterTodasEmpresas()
    {
        var result= await _repository.GetAll();
        
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<EmpresaViewModel>> ObterEmpresaPorId([FromRoute]Guid id)
    {
        var result= await _repository.GetById(id);
        
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult> CadastrarEmpresa([FromBody]CriarEmpresaCommand request)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var result = await _mediator.Send(request);
        
        return Created("Post", result);
    }
    
    [HttpPut("contato")]
    public async Task<ActionResult> AtualizarContatoEmpresa([FromBody]AlterarContatoCommand request)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var result = await _mediator.Send(request);
        
        if (!result)
            return BadRequest();
        
        return NoContent();
    }
    
    [HttpPut("endereco")]
    public async Task<ActionResult> AtualizarEnderecoEmpresa([FromBody]AlterarEnderecoCommand request)
    {

        if (!ModelState.IsValid)
            return BadRequest();
        
        var result = await _mediator.Send(request);
        
        if (!result)
            return BadRequest();
        
        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeletarEmpresa([FromRoute]Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var request = new DeletarEmpresaCommand { Id = id };
        var result = await _mediator.Send(request);

        if (!result)
            return BadRequest();
        
        return NoContent();
    }

    // private EmpresaViewModel MapViewModel(Empresa empresa)
    // {
    //     return new EmpresaViewModel()
    //     {
    //         e
    //     };
    // }
}