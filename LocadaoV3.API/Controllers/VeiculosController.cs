﻿using LocadaoV3.Application.Commands;
using LocadaoV3.Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocadaoV3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly ICommandHandler<CreateVeiculoCommand> _createVeiculoHandler;
        private readonly ICommandHandler<UpdateVeiculoCommand> _updateVeiculoHandler;
        private readonly ICommandHandlerDelete<DeleteVeiculoCommand> _deleteVeiculoHandler;
        private readonly IVeiculoQueryService _veiculoQueryService;

        public VeiculosController(
            ICommandHandler<CreateVeiculoCommand> createVeiculoHandler,
            ICommandHandler<UpdateVeiculoCommand> updateVeiculoHandler,
            ICommandHandlerDelete<DeleteVeiculoCommand> deleteVeiculoHandler,
            IVeiculoQueryService veiculoQueryService)
        {
            _createVeiculoHandler = createVeiculoHandler;
            _updateVeiculoHandler = updateVeiculoHandler;
            _deleteVeiculoHandler = deleteVeiculoHandler;
            _veiculoQueryService = veiculoQueryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVeiculoCommand command)
        {
            var veiculoId = await _createVeiculoHandler.HandleAsync(command);
            var veiculoDto = await _veiculoQueryService.GetVeiculoByIdAsync(veiculoId);
            return CreatedAtAction(nameof(GetById), new { id = veiculoId }, veiculoDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var veiculoDto = await _veiculoQueryService.GetVeiculoByIdAsync(id);
            if (veiculoDto == null) return NotFound();
            return Ok(veiculoDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetVeiculosDisponiveis()
        {
            var veiculos = await _veiculoQueryService.GetVeiculosDisponiveisAsync();
            return Ok(veiculos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVeiculoCommand command)
        {
            if (id != command.Id)
                return BadRequest("O ID do veículo na URL é diferente do corpo da requisição.");

            await _updateVeiculoHandler.HandleAsync(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteVeiculoHandler.HandleAsync(new DeleteVeiculoCommand { Id = id });
            return NoContent();
        }
    }
}
