using MVM.SmartParking.Business.Enum;
using MVM.SmartParking.Core;
using MVM.SmartParking.Business.Entities;

namespace MVM.SmartParking.Business.Entities;

public class Veiculo : Entity
{
    public ETipoAutomovel TipoAutomovel { get; set; }
    public int MarcaId { get; set; }
    public int ModeloId { get; set; }
    public string Placa { get; set; }
    public string Cor { get; set; }
    public IEnumerable<Bilhete> Bilhetes { get; set; }
}