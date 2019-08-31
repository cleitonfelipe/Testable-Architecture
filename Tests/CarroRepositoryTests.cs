using Data.Repository;
using Data.Repository.Interface;
using Domain;
using Moq;
using NUnit.Framework;

namespace Tests
{
    //[TestFixture]
    public class CarroRepositoryTests : BaseTestCarro
    {
        //Arrange
        public DomainCarro Carro { get; set; }

        private ICarroRepository carroRepository;
        private Mock<ICarroRepository> mock;

        //[SetUp]
        public void Initialized()
        {
            carroRepository = new CarroRepository();
            mock = new Mock<ICarroRepository>(MockBehavior.Strict);
        }

        //[Test]
        //[Order(1)]
        public void Criar_Novo_Carro()
        {
            //Act
            Carro = new DomainCarro()
            {
                Marca = "GM",
                Modelo = "Prisma",
                Versao = "Joy"
            };

            var carro = carroRepository.Create(Carro);

            //Assert
            Assert.IsTrue(carro);
        }

        //[Test]
        //[Order(2)]
        public void Buscar_Carro()
        {
            var carro = carroRepository.GetAll(x => x.Modelo == "Prisma");

            Assert.IsNotNull(carro);
        }

        //[Test]
        //[Order(3)]
        public void Atualizar_Carro()
        {
            var carro = carroRepository.GetAll(x => x.Modelo == "LTS");

            carro[0].Modelo = "Prisma";

            carroRepository.Update(carro[0].Id, carro[0]);
        }
    }
}
