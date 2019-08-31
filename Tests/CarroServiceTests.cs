using Data.Repository;
using Data.Repository.Interface;
using Domain;
using NUnit.Framework;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class CarroServiceTests : BaseTestCarro
    {
        private ICarroRepository carroRepository;
        private DomainCarro Carro;
        private IService _service;

        [SetUp]
        public void Initialized()
        {
            carroRepository = new MockCarroRepository();
            _service = new Service.Service(carroRepository);
        }

        [Test]
        [Order(3)]
        public void Atualizar_Carro()
        {
            var carro = _service.Get(1);

            carro.Modelo = "Prisma";

            var carroReturn = _service.Update(carro.Id, carro);

            Assert.IsTrue(carroReturn);
        }

        [Test]
        [Order(2)]
        public void Buscar_Carro()
        {
            var carro = _service.GetAll(x => x.Modelo == "Prisma");

            Assert.IsNotNull(carro);
        }

        [Test]
        [Order(1)]
        public void Criar_Novo_Carro()
        {
            //Act
            Carro = new DomainCarro()
            {
                Marca = "GM",
                Modelo = "Prisma",
                Versao = "Joy"
            };

            var carro = _service.Create(Carro);

            //Assert
            Assert.IsTrue(carro);
        }
    }
}
