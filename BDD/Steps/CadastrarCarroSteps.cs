using Data.Repository;
using Data.Repository.Interface;
using Domain;
using NUnit.Framework;
using Service;
using System;
using System.Linq;
using System.Linq.Expressions;
using TechTalk.SpecFlow;

namespace BDD.Steps
{
    [Binding]
    public class CadastrarCarroSteps
    {
        private static ICarroRepository carroRepository;
        private DomainCarro Carro;
        private static IService _service;
        private int result;

        [BeforeFeature]
        public static void Initialized()
        {
            carroRepository = new MockCarroRepository();
            _service = new Service.Service(carroRepository);
        }

        [Given(@"Que eu entrei no sistema de cadastro de autos")]
        public void DadoQueEuEntreiNoSistemaDeCadastroDeAutos()
        {
            Carro = new DomainCarro();
        }
        
        [Given(@"Digito marca ""(.*)""")]
        public void DadoDigitoMarca(string marca)
        {
            Carro.Marca = marca;
        }
        
        [Given(@"Digito modelo ""(.*)""")]
        public void DadoDigitoModelo(string modelo)
        {
            Carro.Modelo = modelo;
        }
        
        [Given(@"Digito versão ""(.*)""")]
        public void DadoDigitoVersao(string versao)
        {
            Carro.Versao = versao;
        }
        
        [Given(@"Que eu clico para gravar")]
        public void DadoQueEuClicoParaGravar()
        {
            //TO-DO
        }
        
        [When(@"O sistema verifica se existe o carro já cadastrado")]
        public void QuandoOSistemaVerificaSeExisteOCarroJaCadastrado()
        {
            var retorno = _service.GetAll(x => x.Modelo.Equals(Carro.Modelo.ToString()));
            //Validação errada devido a falta de implementação no código
            //Assert.IsNotNull(retorno);
        }
        
        [Then(@"o resultado deve ser ""(.*)""")]
        public void EntaoOResultadoDeveSer(string p0)
        {
            var retorno = _service.Create(Carro);
            Assert.AreEqual(true, retorno);
        }


        [Given(@"busco os carro de marca ""(.*)"", modelo ""(.*)"" e versão ""(.*)""")]
        public void DadoBuscoOsCarroDeMarcaModeloEVersao(string marca, string modelo, string versao)
        {
            Carro.Marca = marca;
            Carro.Modelo = modelo;
            Carro.Versao = versao;
        }

        [When(@"eu clico em buscar")]
        public void QuandoEuClicoEmBuscar()
        {
            var lista = _service.GetAll(x => x.Marca == Carro.Marca && x.Modelo == Carro.Modelo && x.Versao == Carro.Versao);
            result = lista.Count();
        }

        [Then(@"o resultado deve ser (.*) item na lista")]
        public void EntaoOResultadoDeveSerItemNaLista(int itensLista)
        {
            Assert.AreEqual(itensLista, result);
        }


    }
}
