using LocadaoV3.Application.Commands;
using LocadaoV3.Infra.Repository.Veiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Application.Handlers
{
    public class DeleteVeiculoCommandHandler : ICommandHandlerDelete<DeleteVeiculoCommand>
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public DeleteVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task HandleAsync(DeleteVeiculoCommand command)
        {
            await _veiculoRepository.DeleteAsync(command.Id);
        }
    }
}
