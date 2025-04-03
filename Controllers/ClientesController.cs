using Examen2_Tienda_Ropa.Clases;
using Examen2_Tienda_Ropa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Examen2_Tienda_Ropa.Controllers
{
    [RoutePrefix("api/Clientes")]
    public class ClientesController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Cliente> ConsultarTodos()
        {
            clsCliente cliente = new clsCliente();
            return cliente.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXDocumento")]
        public Cliente ConsultarXDocumento(string Documento)
        {
            clsCliente cliente = new clsCliente();
            return cliente.Consultar(Documento);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Cliente cliente)
        {
            clsCliente Cliente = new clsCliente();
            Cliente.cliente = cliente;

            // Verificar si el cliente ya existe antes de insertarlo
            if (Cliente.Consultar(cliente.Documento) != null)
            {
                return "El cliente con el documento ingresado ya existe.";
            }

            return Cliente.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Cliente cliente)
        {
            clsCliente objCliente = new clsCliente();
            objCliente.cliente = cliente;
            return objCliente.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Cliente cliente)
        {
            clsCliente objCliente = new clsCliente();
            objCliente.cliente = cliente;
            return objCliente.Eliminar();
        }

        [HttpDelete]
        [Route("EliminarXDocumento")]
        public string EliminarXDocumento(string Documento)
        {
            clsCliente objCliente = new clsCliente();
            return objCliente.Eliminar(Documento);
        }
    }
}