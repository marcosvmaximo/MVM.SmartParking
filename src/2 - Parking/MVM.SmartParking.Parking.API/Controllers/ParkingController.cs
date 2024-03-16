using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVM.SmartParking.Company.API.Services.Notifications;
using MVM.SmartParking.Parking.API.Controllers.Base;
using MVM.SmartParking.Parking.Application.Commands;
using MVM.SmartParking.Parking.Application.Commands.Views;

namespace MVM.SmartParking.Parking.API.Controllers;

[ApiController]
[Route("api/parking")]
public class ParkingController : BaseController
{
    public ParkingController(IMediator mediator, INotify notify) : base(mediator, notify)
    {
    }
    
    //
    // [HttpGet("{plate}")]
    // public async Task<ActionResult> GetVehicleByPlate([FromRoute]string plate)
    // {
    //     var query = new GetVehicleQuery();
    // }

    [HttpPost]
    [ProducesDefaultResponseType]
    [ProducesResponseType(typeof(RegisterVehicleView), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RegisterVehicleView>> RegisterVehicle([FromBody] RegisterVehicleCommand request)
    {
        return await SendMessage(request);
    }
}