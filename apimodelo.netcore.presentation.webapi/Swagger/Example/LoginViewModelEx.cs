using apimodelo.netcore.presentation.webapi.Models;
using Swashbuckle.AspNetCore.Examples;

namespace apimodelo.netcore.presentation.webapi.Swagger.Example
{
    public class LoginViewModelEx : IExamplesProvider
    {
        public object GetExamples()
        {
            return new LoginViewModel
            {
                usuario = "estevaobraga",
                senha = "123456"
            };
        }
    }
}