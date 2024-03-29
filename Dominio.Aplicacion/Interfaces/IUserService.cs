using Dominio.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Aplicacion.Interfaces
{
    public interface IUserService
    {
        int create(user dto);
        List<user> GetAll();
        user GetById(int id);
    }
}
