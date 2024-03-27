using Application.Common.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Models.Entities;
using Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using System.Net;

namespace Application.Test
{
    public class WalletKataDbContextEntityTest
    {
        private readonly Mock<IWalletKataDbContextEntity> _service;

        public WalletKataDbContextEntityTest()
        {
            _service = new Mock<IWalletKataDbContextEntity>();
        }


        [Fact]
        public async Task GetBalanceQuery_Balance_Success() 
        {
            var walletKataDbContext = Substitute.For<WalletKataDbContext>(new DbContextOptions<WalletKataDbContext>());
            var logger = Substitute.For<ILogger<WalletKataDbContextEntity>>();

            List<BalanceResponse> listaBalance = new List<BalanceResponse>();

            // Arrange
            BalanceResponse objBalanceARS = new BalanceResponse();
            objBalanceARS.Simbolo = "ARS";
            objBalanceARS.Importe = 5000;
            objBalanceARS.Descripcion = "Peso moneda de Argentina";

            BalanceResponse objBalanceUSD = new BalanceResponse();
            objBalanceUSD.Simbolo = "USD";
            objBalanceUSD.Importe = 3000;
            objBalanceUSD.Descripcion = "Dolar moneda estadounidense";

            BalanceResponse objBalanceEUR = new BalanceResponse();
            objBalanceEUR.Simbolo = "EUR";
            objBalanceEUR.Importe = 1000;
            objBalanceEUR.Descripcion = "Euro moneda europea";

            listaBalance.Add(objBalanceARS);
            listaBalance.Add(objBalanceUSD);
            listaBalance.Add(objBalanceEUR);
            

            // Act
            var wallet = new WalletKataDbContextEntity(walletKataDbContext, logger);
            var result = await wallet.GetBalanceQuery();

            // Assert
            Assert.Equal(listaBalance, result);
        }


        [Fact]
        public async Task Deposit_Success() 
        {
            var walletKataDbContext = Substitute.For<WalletKataDbContext>(new DbContextOptions<WalletKataDbContext>());
            var logger = Substitute.For<ILogger<WalletKataDbContextEntity>>();

            // Arrange

            var request = new DepositRequest()
            {
                Moneda= "ARS",
                Importe= 1000
            };

            // Act
            var wallet = new WalletKataDbContextEntity(walletKataDbContext, logger);
            var result = await wallet.DepositQuery(request);

            // Assert
            //Assert.Equal(HttpStatusCode.OK, result.Status



        }

    }
}
