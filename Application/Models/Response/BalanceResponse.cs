using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response
{
    public class BalanceResponse
    {
        public int Importe { get; set; }
        public string Simbolo { get; set; }
        public string? Descripcion { get; set; }

    }
}
