using Application.Common.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Models.Entities;
using Infrastructure.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public class WalletKataDbContextEntity: IWalletKataDbContextEntity
    {
        private readonly WalletKataDbContext _walletKataDbContext;
        private ILogger<WalletKataDbContextEntity> _logger;

        public WalletKataDbContextEntity(WalletKataDbContext walletKataDbContext, ILogger<WalletKataDbContextEntity> logger) 
        {
            _walletKataDbContext = walletKataDbContext;
            _logger = logger;
        }

        public async Task<List<BalanceResponse>> GetBalanceQuery()
        {
            var result = await _walletKataDbContext.TiposMonedas.Where(y => y.Activo == "A").Join(_walletKataDbContext.Saldos, tm => tm.Id, s => s.IdTipoModena, (tm, s) => new BalanceResponse{Importe = s.Importe, Simbolo = tm.Modena, Descripcion = tm.Descripcion}).ToListAsync();
            return result; 
        }

        public async Task<DepositResponse> DepositQuery(DepositRequest request)
        {
            DepositResponse deposit = new DepositResponse();

            try
            {
                if (WalletValidator.validarMoneda(request.Moneda, _walletKataDbContext))
                {
                    var idTipoMneda = await _walletKataDbContext.TiposMonedas.Where(x => x.Modena == request.Moneda).Select(y => y.Id).FirstOrDefaultAsync();

                    var saldo = await _walletKataDbContext.Saldos.Where(x => x.IdTipoModena == idTipoMneda).FirstOrDefaultAsync();

                    if (saldo != null)
                    {
                        saldo.Importe = saldo.Importe + request.Importe;
                        await _walletKataDbContext.SaveChangesAsync();

                        deposit.SaldoActual = saldo.Importe;
                        deposit.Mensaje = "Deposito correcto.";
                    }
                }
                else {
                    deposit.Mensaje = "La moneda ingresa no existe o no es valida. Reingrese!";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: {ex}", ex.Message);
            }

            return deposit;
        }

    }
}
