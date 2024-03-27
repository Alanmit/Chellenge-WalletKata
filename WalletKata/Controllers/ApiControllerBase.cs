using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WalletKata.Business;

namespace WalletKata.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        //protected readonly ILogger Logger;

        public ApiControllerBase()//(ILogger logger)
        {
            //Logger = logger;
        }

        [ApiExplorerSettings(IgnoreApi = true)] // Esto se pone para que ande el Swagger porque es heredado por los Controllers
        public string GetGenericError(Exception ex)
        {
            // Si es una excepción de negocio, no la logueamos
            if (ex.GetType() != (typeof(BusinessException)))
            {
                var message = string.Format("Ha sucedido un error {0} Stack Trace: {1}", ex.Message, ex.StackTrace);
                //Logger.LogError(message);
            }

            return string.Format("{0}. Inner Exception -> {1}", ex.ToString(), ex.InnerException);
        }


    }
}
