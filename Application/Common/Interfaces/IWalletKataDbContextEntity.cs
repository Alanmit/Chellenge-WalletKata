using Application.Models.Request;
using Application.Models.Response;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IWalletKataDbContextEntity
    {
        public Task<List<BalanceResponse>> GetBalanceQuery();

        public Task<DepositResponse> DepositQuery(DepositRequest request);
    }
}
