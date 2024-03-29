using Dominio.Aplicacion.Interfaces;
using Dominio.Infraestructura.Context;
using Dominio.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Aplicacion.Services
{
    public class userService : IUserService
    {
        readonly MysqlContext _context;
        public userService(MysqlContext dbcontext)
        {
            _context = dbcontext;
        }

        public int create(user dto) { 
        
            _context.user.Add(dto);
            var result = _context.SaveChanges();

            return result;
        }

        public List<user> GetAll()
        {
            return _context.user.ToList();
        }

        public user GetById(int id)
        {
            return _context.user.Where(x=> x.Id == id).FirstOrDefault();
        }
    }
}
