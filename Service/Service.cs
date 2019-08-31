using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Data.Repository;
using Data.Repository.Interface;
using Domain;

namespace Service
{
    public class Service : IService
    {
        private ICarroRepository carroRepository;
        public Service(ICarroRepository repository)
        {
            carroRepository = repository;
        }
        public bool Create(DomainCarro carro)
        {
            try
            {
                var result = carroRepository.Create(carro);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DomainCarro Get(int Id)
        {
            try
            {
                var result = carroRepository.Get(Id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DomainCarro> GetAll(Func<DomainCarro, bool> where = null)
        {
            var result = new List<DomainCarro>();
            try
            {
                if (where is null)
                {
                    result = carroRepository.GetAll();
                    return result;
                }
                result = carroRepository.GetAll(where);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(int Id, DomainCarro carro)
        {
            try
            {
                var result = carroRepository.Update(Id, carro);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
