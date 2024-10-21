using LocadaoV3.Application.Commands;
using LocadaoV3.Domain.Models;
using LocadaoV3.Infra.Repository.Clientes;
using System;
using System.Threading.Tasks;

namespace LocadaoV3.Application.Handlers
{
    public class CreateClienteCommandHandler : ICommandHandler<CreateClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository;

        public CreateClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Guid> HandleAsync(CreateClienteCommand command)
        {
            var dataNascimentoUtc = command.DataNascimento.ToUniversalTime();
            command.DataNascimento = dataNascimentoUtc;

            if (command.ValidadeCNH.HasValue)
            {
                command.ValidadeCNH = command.ValidadeCNH.Value.ToUniversalTime();
            }

            var idade = CalcularIdade(dataNascimentoUtc);
            if (idade < 18)
            {
                throw new Exception("O cliente deve ter pelo menos 18 anos.");
            }

            if (command.TemCNH)
            {
                if (!command.ValidadeCNH.HasValue)
                {
                    throw new Exception("A validade da CNH deve ser informada.");
                }

                if (command.ValidadeCNH.Value.Date < DateTime.UtcNow.Date)
                {
                    throw new Exception("A CNH está vencida.");
                }
            }

            var cliente = new Cliente
            {
                Nome = command.Nome,
                Email = command.Email,
                Telefone = command.Telefone,
                Cpf = command.Cpf,
                TemCNH = command.TemCNH,
                IsPCD = command.IsPCD,
                DataNascimento = dataNascimentoUtc,
                ValidadeCNH = command.ValidadeCNH
            };

            await _clienteRepository.AddAsync(cliente);
            return cliente.Id;
        }

        private int CalcularIdade(DateTime dataNascimento)
        {
            var today = DateTime.Today;
            var age = today.Year - dataNascimento.Year;
            if (dataNascimento.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
