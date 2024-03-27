using Application.Common.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WalletKata.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WalletController : ApiControllerBase
    {
        private readonly IWalletKataDbContextEntity _walletKataDbContextEntity;

        public WalletController(IWalletKataDbContextEntity walletKataDbContextEntity)
        {
            _walletKataDbContextEntity = walletKataDbContextEntity;
        }

        [HttpGet("getBalance")]
        [ProducesResponseType(typeof(BalanceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<List<BalanceResponse>> GetBalance()
        {
            return await _walletKataDbContextEntity.GetBalanceQuery();
        }

        [HttpPut("deposit")]
        [ProducesResponseType(typeof(DepositResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<DepositResponse> Deposit(DepositRequest request)
        {
            return await _walletKataDbContextEntity.DepositQuery(request);
        }

        [HttpPut("withdraw")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Withdraw()
        {
            

            return Ok();
        }

        [HttpDelete("exchange")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Exchange()
        {
            

            return Ok();
        }

    }
}
