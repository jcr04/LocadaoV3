using LocadaoV3.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace LocadaoV3.Infra.Repository.Clientes
{
    public class ClienteRepository(LocadaoDbContext context) : IClienteRepository
    {
        private readonly LocadaoDbContext _context = context;

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(Guid id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Cliente>> GetClientesDisponiveisAsync()
        {
            return await _context.Clientes
                                 .Where(c => c.TemCNH == true)
                                 .ToListAsync();
        }
    }
}
