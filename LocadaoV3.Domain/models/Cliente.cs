using System;
using System.ComponentModel.DataAnnotations;

namespace LocadaoV3.Domain.Models
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 dígitos.")]
        public string Cpf { get; set; }

        [Required]
        public bool TemCNH { get; set; }

        [Required]
        public bool IsPCD { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ValidadeCNH { get; set; } 
    }
}
