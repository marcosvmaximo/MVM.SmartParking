using MVM.SmartParking.Core;
using MVM.SmartParking.Domain.Entities;
using MVM.SmartParking.Domain.Enum;

namespace MVM.SmartParking.Domain.Entities;

public class Veiculo : Entity
{
    private List<Bilhete> _bilhetes;

    public Veiculo(ETipoAutomovel tipoAutomovel, int marcaId, int modeloId, string placa, string cor)
    {
        _bilhetes = new();

        TipoAutomovel = tipoAutomovel;
        MarcaId = marcaId;
        ModeloId = modeloId;
        Placa = placa;
        Cor = cor;
    }

    public ETipoAutomovel TipoAutomovel { get; private set; }
    public int MarcaId { get; private set; }
    public int ModeloId { get; private set; }
    public string Placa { get; private set; }
    public string Cor { get; private set; }
    
    // Ef
    public IReadOnlyCollection<Bilhete> Bilhetes => _bilhetes;
}