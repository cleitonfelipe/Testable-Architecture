using Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CarroDomainTests
    {
        //Arrange
        private readonly DomainCarro domainCarro;
        private const int Id = 1;
        private const string Marca = "GM";
        private const string Modelo = "Prisma";
        private const string Versao = "Joy";

        public CarroDomainTests()
        {
            domainCarro = new DomainCarro();
        }

        [Test]
        public void TestSetAndGetId()
        {
            //Act
            domainCarro.Id = Id;

            //Assert
            Assert.That(domainCarro.Id,
                Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetMarca()
        {
            domainCarro.Marca = Marca;

            Assert.That(domainCarro.Marca,
                Is.EqualTo(Marca));
        }

        [Test]
        public void TestSetAndGetModelo()
        {
            domainCarro.Modelo = Modelo;

            Assert.That(domainCarro.Modelo,
                Is.EqualTo(Modelo));
        }

        [Test]
        public void TestSetAndGetVersao()
        {
            domainCarro.Versao = Versao;

            Assert.That(domainCarro.Versao,
                Is.EqualTo(Versao));
        }

    }
}
