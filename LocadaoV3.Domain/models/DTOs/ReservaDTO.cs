﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Domain.Models.DTOs
{
        public class ReservaDTO
        {
            public Guid Id { get; set; }
            public Guid ClienteId { get; set; }
            public string ClienteNome { get; set; } // Considerando que você quer mostrar o nome do cliente na reserva
            public Guid VeiculoId { get; set; }
            public string VeiculoDescricao { get; set; } // Uma descrição simplificada do veículo, como "Marca Modelo"
            public DateTime DataInicio { get; set; }
            public DateTime DataFim { get; set; }
            public string Status { get; set; }
        }
}