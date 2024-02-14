using MediatR;

namespace MVM.SmartParking.Application.EmpresasContext.Commands;

public class DeletarEmpresaCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}