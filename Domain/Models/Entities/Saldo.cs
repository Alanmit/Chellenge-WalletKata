using System;
using System.Collections.Generic;

namespace Domain.Models.Entities;

public partial class Saldo
{
    public int Id { get; set; }

    public int IdTipoModena { get; set; }

    public int Importe { get; set; }

    public virtual TiposMoneda IdTipoModenaNavigation { get; set; } = null!;
}
