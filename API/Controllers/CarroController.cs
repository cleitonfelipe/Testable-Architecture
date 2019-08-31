using System.Collections.Generic;
using Data.Repository;
using Data.Repository.Interface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private IService _service;
        private ICarroRepository carroRepository;

        public CarroController()
        {

#if DEBUG
            carroRepository = new MockCarroRepository();
#else

            carroRepository = new CarroRepository();
#endif

            _service = new Service.Service(carroRepository);
        }
        // GET: api/Carro
        [HttpGet]
        public IEnumerable<DomainCarro> Get()
        {
            return _service.GetAll();
        }

        // GET: api/Carro/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var result = _service.Get(id);
            return Ok(result);
        }

        // POST: api/Carro
        [HttpPost]
        public bool Post([FromBody]DomainCarro value)
        {
            var result = _service.Create(value);
            return result;
        }

        // PUT: api/Carro/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody]DomainCarro value)
        {
            var result = _service.Update(id, value);
            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
