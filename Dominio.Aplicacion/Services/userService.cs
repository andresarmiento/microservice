using Dominio.Aplicacion.Interfaces;
using Dominio.Infraestructura.Context;
using Dominio.Model.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Aplicacion.Services
{
    public class userService : IUserService
    {
        private readonly MysqlContext _context;

        public userService(MysqlContext dbcontext)
        {
            _context = dbcontext;
        }

        public int create(user dto)
        {
            try
            {
                _context.user.Add(dto);
                var result = _context.SaveChanges();

                return result;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }

        public List<user> GetAll()
        {
            try
            {
                
                return _context.user.ToList();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public user GetById(int id)
        {
            try
            {
                return _context.user.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
