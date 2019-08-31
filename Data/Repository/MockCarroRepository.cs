using Data.Repository.Interface;
using Domain;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Repository
{
    public class MockCarroRepository : ICarroRepository
    {
        private List<DomainCarro> Carros;
        public MockCarroRepository()
        {
            Carros = new List<DomainCarro>();
            var mockCarros = new List<DomainCarro>
            {
                new DomainCarro { Id = 1, Marca = "Carro 1", Modelo = "Modelo 1", Versao = "Basico" },
                new DomainCarro { Id = 2, Marca = "Carro 1", Modelo = "Modelo 2", Versao = "Super" },
                new DomainCarro { Id = 3, Marca = "Carro 2", Modelo = "Modelo 1", Versao = "Basico" },
                new DomainCarro { Id = 4, Marca = "Carro 2", Modelo = "Modelo 2", Versao = "Super" }
            };

            foreach (var carro in mockCarros)
            {
                Carros.Add(carro);
            }

        }
        public bool Create(DomainCarro carro)
        {
            Carros.Add(carro);
            return true;
        }

        public DomainCarro Get(int Id)
        {
            return Carros.FirstOrDefault(s => s.Id == Id);
        }

        public List<DomainCarro> GetAll(Func<DomainCarro, bool> where = null)
        {
            return Carros.Where(where).ToList();
        }

        public bool Update(int Id, DomainCarro carro)
        {
            var carroUpdate = Carros.FirstOrDefault(s => s.Id == Id);
            carroUpdate.Marca = carro.Marca;
            carroUpdate.Modelo = carro.Modelo;
            carroUpdate.Versao = carro.Versao;

            return true;
        }
    }
}
