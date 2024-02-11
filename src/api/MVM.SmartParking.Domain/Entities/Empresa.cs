using MVM.SmartParking.Core;

namespace MVM.SmartParking.Domain.Entities;

public class Empresa : Entity
{
    private List<Bilhete> _bilhetes;

    public Empresa(string nome, string cnpj, Endereco endereco, Contato contato, int quantidadeVagasCarro, int quantidadeVagasMoto)
    {
        Nome = nome;
        Cnpj = cnpj;
        Endereco = endereco;
        Contato = contato;
        QuantidadeVagasCarro = quantidadeVagasCarro;
        QuantidadeVagasMoto = quantidadeVagasMoto;
        
        _bilhetes = new();
    }

    public string Nome { get; private set; }
    public string Cnpj { get; private set; }
    public int QuantidadeVagasCarro { get; private set; }
    public int QuantidadeVagasMoto { get; private set; }
    public Endereco Endereco {get; private set; }
    public Contato Contato { get; private set; }
    public IReadOnlyCollection<Bilhete> BilhetesEstacionamento => _bilhetes;
}