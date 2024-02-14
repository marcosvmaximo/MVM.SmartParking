using System.Text.Json.Serialization;
using MediatR;

namespace MVM.SmartParking.Application.EmpresasContext.Commands;

public class AlterarContatoCommand : IRequest<bool>
{
    [JsonIgnore]
    public Guid EmpresaId { get; set; }
    public string Ddd { get; set; }
    public string Telefone { get; set; }
}