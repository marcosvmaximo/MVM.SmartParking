using MediatR;
using MVM.SmartParking.Business.Entities;

namespace MVM.SmartParking.Application.EmpresasContext.Commands;

public class CriarEmpresaCommand : IRequest<Empresa>
{
    public string Nome { get; private set; }
    public string Cnpj { get; private set; }
    public int QuantidadeVagasCarro { get; private set; }
    public int QuantidadeVagasMoto { get; private set; }
    public AlterarEnderecoCommand AlterarEndereco { get; set; } 
    public AlterarContatoCommand AlterarContato { get; set; } 
}