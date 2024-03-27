using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class DepositRequest
    {
        public string Moneda { get; set; }
        public int Importe { get; set; }
    }
}
