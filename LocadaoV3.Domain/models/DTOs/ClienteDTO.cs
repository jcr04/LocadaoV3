using System;

namespace LocadaoV3.Domain.Models.DTOs
{
    public class ClienteDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public bool TemCNH { get; set; }
        public bool IsPCD { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime? ValidadeCNH { get; set; }
    }
}
