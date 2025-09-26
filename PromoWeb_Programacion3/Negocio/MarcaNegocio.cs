using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {


        public List<Marcas> ListarMarcas()
        {
            List<Marcas> lista = new List<Marcas>();
            Accesodatos accesoDatos = new Accesodatos();

            try
            {
                accesoDatos.SetearConsulta("select id, descripcion from MARCAS");
                accesoDatos.EjecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Marcas aux = new Marcas();
                    aux.Id = (int)accesoDatos.Lector["id"];
                    aux.Descripcion = (string)accesoDatos.Lector["descripcion"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.CerrarConexion();

            }

        }





    }
}
