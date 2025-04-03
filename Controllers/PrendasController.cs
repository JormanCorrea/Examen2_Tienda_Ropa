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
    [RoutePrefix("api/Prendas")]
    public class PrendasController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Prenda prenda)
        {
            clsPrenda Prenda = new clsPrenda();
            Prenda.prenda = prenda;
            return Prenda.Insertar();
        }
    }
}