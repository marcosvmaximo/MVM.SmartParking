using MVM.SmartParking.Core;

namespace MVM.SmartParking.Business.Entities;

public class Empresa : Entity
{
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public int QuantidadeVagasCarro { get; set; }
    public int QuantidadeVagasMoto { get; set; }
    public Endereco Endereco {get; set; }
    public Contato Contato { get; set; }
    public IEnumerable<Bilhete> Bilhetes { get; set; }
}