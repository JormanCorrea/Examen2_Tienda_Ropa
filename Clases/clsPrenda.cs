using Examen2_Tienda_Ropa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen2_Tienda_Ropa.Clases
{
    public class clsPrenda
    {
        private DBExamenEntities1 dbExamen = new DBExamenEntities1(); //Instancia de la base de datos
        public Prenda prenda { get; set; }
        public string Insertar()
        {
            try
            {
                dbExamen.Prendas.Add(prenda); 
                dbExamen.SaveChanges(); 
                return "Prenda insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la prenda: " + ex.Message;
            }
        }
    }
}