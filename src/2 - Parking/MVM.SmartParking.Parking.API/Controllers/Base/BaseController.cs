using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVM.SmartParking.Company.API.Services.Notifications;
using MVM.SmartParking.Core.Application;

namespace MVM.SmartParking.Parking.API.Controllers.Base;

[ApiController]
public class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;
    protected readonly INotify _notify;

    public BaseController(IMediator mediator, INotify notify)
    {
        _mediator = mediator;
        _notify = notify;
    }

    protected async Task<ActionResult> SendMessage<TMessage>(TMessage message)
        where TMessage : IRequest<View>, new() => await CustomResponse(await _mediator.Send(message));

    protected async Task<ActionResult> CustomResponse(object response)
    {
        if (!ModelState.IsValid) ValidateModelState();
        
        if (_notify.AnyNotification()) 
            return BadRequest(_notify.GetNotifications());

        return Ok(response);
    }

    private void ValidateModelState()
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);

            foreach (var error in errors)
            {
                _notify.AddNotification(null, error);
            }
        }
    }
}