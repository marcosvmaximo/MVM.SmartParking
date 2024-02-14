using System.Text.Json.Serialization;
using MediatR;

namespace MVM.SmartParking.Application.EmpresasContext.Commands;

public class AlterarEnderecoCommand : IRequest<bool>
{
    [JsonIgnore]
    public Guid EmpresaId { get; set; }
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Complemento { get; set; }
    public int Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Pais { get; set; }
}