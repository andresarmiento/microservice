using Dominio.Aplicacion.Interfaces;
using Dominio.Model.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceContainer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _domain;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService Domain, ILogger<UserController> logger)
        {
            _domain = Domain;
            _logger = logger;
        }

        [HttpPost("[action]")]
        public int Insert(user dto)
        {
            try
            {
                _logger.LogTrace($"Insert User {dto}");
                return _domain.create(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
                //throw;
            }
        }


        [HttpGet("[action]")]
        public List<user> GetAll()
        {
            try
            {
                _logger.LogTrace($"GetAll user");
                return _domain.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
                //throw ex;
            }
        }

        [HttpGet("[action]")]
        public user GetById(int id)
        {
            try
            {
                _logger.LogTrace($"GetById user {id}");
                return _domain.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
                //throw;
            }
        }

    }
}
