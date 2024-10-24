﻿using LocadaoV3.Application.Commands;
using LocadaoV3.Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocadaoV3.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservasController : ControllerBase
{
    private readonly IReservaQueryService _reservaQueryService;
    private readonly ICommandHandler<CreateReservaCommand> _createReservaHandler;
    private readonly ICommandHandler<UpdateReservaCommand> _updateReservaHandler;

    public ReservasController(
        IReservaQueryService reservaQueryService,
        ICommandHandler<CreateReservaCommand> createReservaHandler,
        ICommandHandler<UpdateReservaCommand> updateReservaHandler)
    {
        _reservaQueryService = reservaQueryService;
        _createReservaHandler = createReservaHandler;
        _updateReservaHandler = updateReservaHandler;
        // Inicialize outros handlers aqui
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReservaCommand command)
    {
        try
        {
            var reservaId = await _createReservaHandler.HandleAsync(command);
            var reserva = await _reservaQueryService.GetReservaByIdAsync(reservaId);
            return CreatedAtAction(nameof(GetById), new { id = reservaId }, reserva);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var reserva = await _reservaQueryService.GetReservaByIdAsync(id);
        if (reserva == null) return NotFound();
        return Ok(reserva);
    }

    [HttpGet]
    public async Task<IActionResult> GetReservasDisponiveis()
    {
        var reservas = await _reservaQueryService.GetReservasDisponiveisAsync();
        return Ok(reservas);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateReservaCommand command)
    {
        if (id != command.ReservaId)
        {
            return BadRequest("O ID da reserva na URL é diferente do corpo da requisição.");
        }

        try
        {
            await _updateReservaHandler.HandleAsync(command);
            var reservaAtualizada = await _reservaQueryService.GetReservaByIdAsync(id);
            return Ok(reservaAtualizada);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
