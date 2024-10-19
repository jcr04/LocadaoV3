using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Application.Commands;
public class CreateAluguelCommand
{
    public Guid ClienteId { get; set; }
    public Guid VeiculoId { get; set; }
    public Guid AgenciaId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public decimal Valor { get; set; }
    public string Status { get; set; }
}

public class DeleteAluguelCommand
{
    public Guid Id { get; set; }
}