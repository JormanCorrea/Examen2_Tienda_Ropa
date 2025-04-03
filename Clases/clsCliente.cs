using Examen2_Tienda_Ropa.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Examen2_Tienda_Ropa.Clases
{
    public class clsCliente
    {
        private DBExamenEntities1 db = new DBExamenEntities1(); // Conexión a la base de datos
        public Cliente cliente { get; set; }

        //relacion con prenda
        public List<Prenda> Prendas
        {
            get { return db.Prendas.Where(p => p.Cliente == cliente.Documento).ToList(); }
        }


        public string Insertar()
        {
            try
            {
                // Verificar si el cliente ya existe
                Cliente cli = Consultar(cliente.Documento);
                if (cli != null)
                {
                    return "El cliente con el documento ingresado ya existe, no se puede insertar nuevamente.";
                }

                db.Clientes.Add(cliente);
                db.SaveChanges();
                return "Cliente insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el cliente: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Cliente cli = Consultar(cliente.Documento);
                if (cli == null)
                {
                    return "El cliente con el documento ingresado no existe, por lo tanto no se puede actualizar";
                }
                db.Clientes.AddOrUpdate(cliente);
                db.SaveChanges();
                return "Se actualizó el cliente correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar el cliente: " + ex.Message;
            }
        }

        public List<Cliente> ConsultarTodos()
        {
            return db.Clientes
                .OrderBy(c => c.Nombre)
                .ToList();
        }

        public Cliente Consultar(string Documento)
        {
            return db.Clientes.FirstOrDefault(c => c.Documento == Documento);
        }

        public string Eliminar()
        {
            try
            {
                Cliente cli = Consultar(cliente.Documento);
                if (cli == null)
                {
                    return "El cliente con el documento ingresado no existe, por lo tanto no se puede eliminar";
                }
                db.Clientes.Remove(cli);
                db.SaveChanges();
                return "Se eliminó el cliente correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el cliente: " + ex.Message;
            }
        }

        public string Eliminar(string Documento)
        {
            try
            {
                Cliente cli = Consultar(Documento);
                if (cli == null)
                {
                    return "El cliente con el documento ingresado no existe, por lo tanto no se puede eliminar";
                }
                db.Clientes.Remove(cli);
                db.SaveChanges();
                return "Se eliminó el cliente correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el cliente: " + ex.Message;
            }
        }
    }
}