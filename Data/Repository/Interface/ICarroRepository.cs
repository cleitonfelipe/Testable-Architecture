using Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Data.Repository.Interface
{
    public interface ICarroRepository
    {
        bool Create(DomainCarro carro);
        bool Update(int Id, DomainCarro carro);
        List<DomainCarro> GetAll(Func<DomainCarro, bool> where = null);
        DomainCarro Get(int Id);
    }
}
