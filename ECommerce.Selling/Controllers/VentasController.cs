using ECommerce.Selling.DataAccess;
using ECommerce.Selling.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.Selling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        // Forma 1: Método API rápido, que retorna la respuesta de la operación sin encapsular.
        // GET: api/<VentasController>
        [HttpGet]
        public IEnumerable<VentaModel> Get()
        {
            var response = new List<VentaModel>();
            response = VentaModelDAO.Instancia.Listar();
            return response;
        }

        // Forma 1: Método API rápido, que retorna la respuesta de la operación sin encapsular.
        // GET api/<VentasController>/5
        [HttpGet("{id}")]
        public VentaModel Get(string id)
        {
            var response = new VentaModel();
            response = VentaModelDAO.Instancia.Devolver(id);
            return response;
        }

        // Forma 2: Método API rápido, que retorna la respuesta de la operación sin encapsular, pero definiendo los estados HTTP de la respuesta.
        // POST api/<VentasController>
        [HttpPost]
        public ActionResult Post([FromBody] VentaModel value)
        {
            ActionResult result = null;
            var response = false;
            try
            {
                value.Fecha = DateTime.Now;
                response = VentaModelDAO.Instancia.Insertar(value);
                if (!response)
                {
                    result = BadRequest(response);
                }
                else
                {
                    result = Ok(value);
                }
            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
            return result;
        }

        //  Forma 3: Método API Completo, usando un ObjectResponse que encapsule el resultado a entregar 
        // PUT api/<VentasController>/5
        [HttpPut("{id}")]
        public ActionResult<ObjectResponse<bool>> Put(string id, [FromBody] VentaModel value)
        {
            ActionResult result = null;
            ObjectResponse<bool> response = new ObjectResponse<bool> { DataRequest = "Update: " + id };
            try
            {
                var registrado = VentaModelDAO.Instancia.Actualizar(value);
                if (registrado)
                {
                    response.DataResponse = true;
                    response.StatusResponse = new StatusResponse() { Message = "Operacion Exitosa", Status = "OK" };

                    result = Ok(response);
                }
                else
                {
                    response.DataResponse = false;
                    response.StatusResponse = new StatusResponse() { Message = "No se pudo realizar la operación", Status = "NoOK" };

                    result = BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.DataResponse = false;
                response.StatusResponse = new StatusResponse() { Message = ex.Message, Status = "NoOK" };

                result = StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return result;
        }

        //  Forma 3: Método API Completo, usando un ObjectResponse que encapsule el resultado a entregar 
        // DELETE api/<VentasController>/5
        [HttpDelete("{id}")]
        public ActionResult<ObjectResponse<bool>> Delete(string id)
        {
            ActionResult result = null;
            ObjectResponse<bool> response = new ObjectResponse<bool>();

            response.DataRequest = "Delete: " + id;
            try
            {
                var registrado = VentaModelDAO.Instancia.Eliminar(id);
                if (registrado)
                {
                    response.DataResponse = true;
                    response.StatusResponse = new StatusResponse() { Message = "Operacion Exitosa", Status = "OK" };

                    result = Ok(response);
                }
                else
                {
                    response.DataResponse = false;
                    response.StatusResponse = new StatusResponse() { Message = "No se pudo realizar la operación", Status = "NoOK" };

                    result = BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.DataResponse = false;
                response.StatusResponse = new StatusResponse() { Message = ex.Message, Status = "NoOK" };

                result = StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return result;
        }
    }
}
