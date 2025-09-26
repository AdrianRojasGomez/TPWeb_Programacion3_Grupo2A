using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {


        public List<Categorias> ListarCategorias()
        {
             

            List<Categorias> lista = new List<Categorias>();
            Accesodatos accesoDatos = new Accesodatos();

            try
            {
                accesoDatos.SetearConsulta("select id,descripcion from CATEGORIAS");
                accesoDatos.EjecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Categorias aux = new Categorias();
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
