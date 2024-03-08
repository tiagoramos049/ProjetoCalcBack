using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoCalcBack.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using ProjetoCalcBack.Services;
using ProjetoCalcBack.Repositories;

namespace ProjetoCalcBack.Controllers
{
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Gerente";

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model) 
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null) 
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpPost]
        [Route("calculate")]
        [Authorize]
        public IActionResult Calculate([FromBody] CalculationRequest request)
        {
            var operation = new Operation();
            double result = operation.PerformOperation(request.Value1, request.Value2, request.Operation);
            return Ok(result);
        }
    }
}
