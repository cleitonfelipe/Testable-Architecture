using Data.Repository.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Repository
{
    public class CarroRepository : ICarroRepository
    {
        private MontadoraContext dbContext;

        public CarroRepository()
        {
            dbContext = new MontadoraContext();
        }
        public bool Create(DomainCarro carro)
        {
            bool result;
            try
            {
                dbContext.Carros.Add(carro);

                var count = dbContext.SaveChanges();
                if (count < 0)
                    result = true;
                else
                    result = false;

                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public DomainCarro Get(int Id)
        {
            try
            {
                var carro = dbContext.Carros.FirstOrDefault(x => x.Id == Id);
                return carro;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public List<DomainCarro> GetAll(Func<DomainCarro, bool> where = null)
        {
            List<DomainCarro> list = new List<DomainCarro>();
            try
            {
                if (where != null)
                {
                    list = dbContext.Carros.Where(where).ToList();
                    return list;
                }
                list = dbContext.Carros.ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public bool Update(int Id, DomainCarro carro)
        {
            bool result;
            try
            {
                dbContext.Carros.Update(carro);

                var count = dbContext.SaveChanges();
                if (count < 0)
                    result = true;
                else
                    result = false;

                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
