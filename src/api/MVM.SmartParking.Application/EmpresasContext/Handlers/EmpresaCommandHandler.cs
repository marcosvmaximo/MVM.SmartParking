using MediatR;
using MVM.SmartParking.Application.EmpresasContext.Commands;
using MVM.SmartParking.Application.EmpresasContext.ViewModels;
using MVM.SmartParking.Business.Entities;
using MVM.SmartParking.Business.Interfaces;

namespace MVM.SmartParking.Application.EmpresasContext.Handlers;

public class EmpresaCommandHandler : 
    IRequestHandler<CriarEmpresaCommand, Empresa>, 
    IRequestHandler<DeletarEmpresaCommand, bool>,
    IRequestHandler<AlterarEnderecoCommand, bool>,
    IRequestHandler<AlterarContatoCommand, bool>
{
    private readonly IEmpresaRepository _repository;

    public EmpresaCommandHandler(IEmpresaRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Empresa> Handle(CriarEmpresaCommand request, CancellationToken cancellationToken)
    {
        var existeEmpresa = await _repository.ObterPorCnpj(request.Cnpj);
        if(existeEmpresa == null)
            return null;
        
        var empresa = MapEmpresa(request);

        await _repository.Add(empresa);
        // await _repository.UnityOfWork.Commit();
        
        return empresa;
    }

    public async Task<bool> Handle(DeletarEmpresaCommand request, CancellationToken cancellationToken)
    {
        var empresa = await _repository.GetById(request.Id);

        if (empresa == null)
            return false;

        await _repository.Delete(empresa);
        // await _repository.UnityOfWork.Commit();

        return true;
    }

    public async Task<bool> Handle(AlterarEnderecoCommand request, CancellationToken cancellationToken)
    {
        var empresa = await _repository.GetById(request.EmpresaId);

        if (empresa == null)
            return false;
        
        var endereco = new Endereco()
        {
            Logradouro = request.Logradouro,
            Bairro = request.Bairro,
            Cep = request.Cep,
            Cidade = request.Cidade,
            Complemento = request.Complemento,
            Estado = request.Estado,
            Numero = request.Numero,
            Pais = request.Pais
        };

        empresa.Endereco = endereco;
        await _repository.Update(empresa);
        // await _repository.UnityOfWork.Commit();

        return true;
    }

    public async Task<bool> Handle(AlterarContatoCommand request, CancellationToken cancellationToken)
    {
        var empresa = await _repository.GetById(request.EmpresaId);

        if (empresa == null)
            return false;
        
        var contato = new Contato()
        {
            Ddd = request.Ddd,
            Telefone = request.Telefone
        };

        empresa.Contato = contato;
        await _repository.Update(empresa);
        // await _repository.UnityOfWork.Commit();

        return true;
    }
    
    private Empresa MapEmpresa(CriarEmpresaCommand command)
    {
        var contato = new Contato()
        {
            Ddd = command.AlterarContato.Ddd,
            Telefone = command.AlterarContato.Telefone
        };

        var endereco = new Endereco()
        {
            Logradouro = command.AlterarEndereco.Logradouro,
            Bairro = command.AlterarEndereco.Bairro,
            Cep = command.AlterarEndereco.Cep,
            Cidade = command.AlterarEndereco.Cidade,
            Complemento = command.AlterarEndereco.Complemento,
            Estado = command.AlterarEndereco.Estado,
            Numero = command.AlterarEndereco.Numero,
            Pais = command.AlterarEndereco.Pais
        };
            
        return new Empresa()
        {
            Nome = command.Nome,
            Cnpj = command.Cnpj,
            QuantidadeVagasCarro = command.QuantidadeVagasCarro,
            QuantidadeVagasMoto = command.QuantidadeVagasMoto,
            Contato = contato,
            Endereco = endereco
        };
    }
}