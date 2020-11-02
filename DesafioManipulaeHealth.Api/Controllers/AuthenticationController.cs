using DesafioManipulaeHealth.Domain.Response;
using DesafioManipulaeHealth.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace DesafioManipulaeHealth.Api.Controllers
{
    //[EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ApiController
    {
        private readonly ILogger _logger;
        private readonly ITokenService _tokenService;

        public AuthenticationController(ILogger logger, ITokenService tokenService)
        {
            _logger = logger;
            _tokenService = tokenService;
        }

        [HttpGet()]
        [AllowAnonymous]
        public IResult Get()
        {
            try
            {
                var token = _tokenService.GenerateToken();

                return ViewModelResult(token);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao fazer login.");

                return ErrorResult("Falha ao fazer login");
            }
        }
    }
}
