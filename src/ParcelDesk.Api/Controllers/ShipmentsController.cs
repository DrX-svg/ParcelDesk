using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParcelDesk.Api.DTOs.Shipments;
using ParcelDesk.Api.Models;
using ParcelDesk.Api.Services;

namespace ParcelDesk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipmentsController : ControllerBase
{
    private readonly ShipmentService _shipmentService;

    public ShipmentsController(ShipmentService shipmentService)
    {
        _shipmentService = shipmentService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ShipmentResponse>>> GetAll(
        [FromQuery] ShipmentFilterRequest filter)
    {
        var shipments = await _shipmentService.GetAllAsync(
            filter.Status,
            filter.CustomerId,
            filter.City,
            filter.Search
        );

        var response = shipments
                                .Select(ToResponse)
                                .ToList();

        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ShipmentResponse>> GetById(int id)
    {
        var shipment = await _shipmentService.GetByIdAsync(id);

        if (shipment is null)
        {
            return NotFound();
        }

        return Ok(ToResponse(shipment));
    }

    [HttpGet("awb/{awb}")]
    public async Task<ActionResult<ShipmentResponse>> GetByAwb(string awb)
    {
        var shipment = await _shipmentService.GetByAwbAsync(awb);

        if (shipment is null)
        {
            return NotFound();
        }

        return Ok(ToResponse(shipment));
    }

    [HttpPost]
    public async Task<ActionResult<ShipmentResponse>> Create(CreateShipmentRequest request)
    {
        var shipment = await _shipmentService.CreateAsync(
            request.CustomerId,
            request.SenderAddress,
            request.DestinationAddress,
            request.City,
            request.Weight,
            request.Notes);

        if (shipment is null)
        {
            return BadRequest(new
            {
                error = $"Customer with id {request.CustomerId} does not exist."
            });
        }

        var response = ToResponse(shipment);

        return CreatedAtAction(
            nameof(GetById),
            new { id = shipment.Id },
            response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ShipmentResponse>> Update(
        int id,
        UpdateShipmentRequest request)
    {
        var shipment = await _shipmentService.UpdateAsync(
            id,
            request.SenderAddress,
            request.DestinationAddress,
            request.City,
            request.Weight,
            request.Notes);

        if (shipment is null)
        {
            return NotFound();
        }

        return Ok(ToResponse(shipment));
    }

    [HttpPatch("{id:int}/status")]
    public async Task<ActionResult<ShipmentResponse>> ChangeStatus(
        int id,
        UpdateShipmentStatusRequest request)
    {
        var newStatus = request.Status!.Value;

        var result = await _shipmentService.ChangeStatusAsync(
            id,
            newStatus);

        if (result == ShipmentStatusChangeResult.NotFound)
        {
            return NotFound();
        }

        if (result == ShipmentStatusChangeResult.InvalidTransition)
        {
            return Conflict(new
            {
                error = "The requested status transition is not allowed."
            });
        }

        var shipment = await _shipmentService.GetByIdAsync(id);

        return Ok(ToResponse(shipment!));
    }

    [HttpGet("{id:int}/history")]
    public async Task<ActionResult<List<ShipmentStatusHistoryResponse>>> GetHistory(
        int id)
    {
        var history = await _shipmentService.GetHistoryAsync(id);

        if (history is null)
        {
            return NotFound();
        }

        var response = history.Select(entry =>
                                        new ShipmentStatusHistoryResponse
                                        {
                                            Id = entry.Id,
                                            ShipmentId = entry.ShipmentId,
                                            Status = entry.Status.ToString(),
                                            ChangedAtUtc = entry.ChangedAtUtc
                                        }).ToList();

        return Ok(response);
    }



    private static ShipmentResponse ToResponse(Shipment shipment)
    {
        return new ShipmentResponse
        {
            Id = shipment.Id,
            Awb = shipment.Awb,
            CustomerId = shipment.CustomerId,
            CustomerName = shipment.Customer?.Name ?? string.Empty,
            SenderAddress = shipment.SenderAddress,
            DestinationAddress = shipment.DestinationAddress,
            City = shipment.City,
            Weight = shipment.Weight,
            Status = shipment.Status.ToString(),
            CreatedAtUtc = shipment.CreatedAtUtc,
            UpdatedAtUtc = shipment.UpdatedAtUtc,
            Notes = shipment.Notes
        };
    }
}