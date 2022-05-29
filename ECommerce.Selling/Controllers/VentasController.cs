using ECommerce.Selling.DataAccess;
using ECommerce.Selling.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.Selling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        // GET: api/<VentasController>
        [HttpGet]
        public IEnumerable<VentaModel> Get()
        {
            var response = new List<VentaModel>();
            response = VentaModelDAO.Instancia.Listar();
            return response;
        }

        // GET api/<VentasController>/5
        [HttpGet("{id}")]
        public VentaModel Get(string id)
        {
            var response = new VentaModel();
            response = VentaModelDAO.Instancia.Devolver(id);
            return response;
        }

        // POST api/<VentasController>
        [HttpPost]
        public void Post([FromBody] VentaModel value)
        {
            
            
        }

        // PUT api/<VentasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] VentaModel value)
        {

        }

        // DELETE api/<VentasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
