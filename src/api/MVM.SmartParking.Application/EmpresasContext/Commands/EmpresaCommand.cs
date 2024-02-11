namespace MVM.SmartParking.Application.EmpresasContext.Commands;

public class EmpresaCommand
{
    public string Nome { get; private set; }
    public string Cnpj { get; private set; }
    public int QuantidadeVagasCarro { get; private set; }
    public int QuantidadeVagasMoto { get; private set; }
    public EnderecoCommand Endereco { get; set; } 
    public ContatoCommand Contato { get; set; } 
}