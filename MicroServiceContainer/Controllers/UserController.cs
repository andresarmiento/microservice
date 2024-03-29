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
        readonly IUserService _domain;
        public UserController(IUserService Domain)
        {
            _domain = Domain;
        }

        [HttpPost("[action]")]
        public int Insert(user dto)
        {
            return _domain.create(dto);
        }


        [HttpGet("[action]")]
        public List<user> GetAll()
        {
            return _domain.GetAll();
        }

        [HttpGet("[action]")]
        public user GetById(int id)
        {
            return _domain.GetById(id);
        }

    }
}
