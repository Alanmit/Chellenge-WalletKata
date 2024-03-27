using System;
using System.Collections.Generic;

namespace Domain.Models.Entities;

public partial class TiposMoneda
{
    public int Id { get; set; }

    public string Modena { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Activo { get; set; } = null!;

    public virtual ICollection<Saldo> Saldos { get; set; } = new List<Saldo>();
}
