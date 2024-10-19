using LocadaoV3.Domain.Models;

namespace LocadaoV3.Infra.Repository.Reservas
{
    public interface IReservaRepository
    {
        Task<Reserva> AddAsync(Reserva reserva);
        Task<Reserva> GetByIdAsync(Guid id);
        Task<IEnumerable<Reserva>> GetByClienteIdAsync(Guid clienteId);

        Task CancelarReservaAsync(Guid reservaId);

        Task<Reserva> UpdateReservaAsync(Reserva updatedReserva);

        Task<IEnumerable<Reserva>> GetReservasDisponiveisAsync();
    }

}