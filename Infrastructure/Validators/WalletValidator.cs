using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validators
{
    public static class WalletValidator
    {
        
        public static bool validarMoneda(string moneda, WalletKataDbContext walletKataDbContext)
        {
            var tipoMoneda = walletKataDbContext.TiposMonedas.Where(x => x.Modena.ToUpper() == moneda.ToUpper()).FirstOrDefault();

            if (tipoMoneda != null)
                return true;
            else
                return false;
        }
    }
}
