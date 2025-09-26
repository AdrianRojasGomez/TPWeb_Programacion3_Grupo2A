using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulos> Listar()
        {

            List<Articulos> lista = new List<Articulos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {   

                // matias
                conexion.ConnectionString = "server = .\\SQLEXPRESS02; database = CATALOGO_P3_DB; integrated security =true ;";


                comando.CommandType = System.Data.CommandType.Text;
               
                /// ////matias
                comando.CommandText = "SELECT A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.Id, " +
                   "       ISNULL(I1.ImagenUrl, '') AS ImagenUrl, " +
                   "       ISNULL(C.Id, 0) AS IdCategoria, ISNULL(C.Descripcion, '') AS Categoria, " +
                   "       ISNULL(M.Id, 0) AS IdMarca,    ISNULL(M.Descripcion, '') AS Marca " +
                   "       FROM Articulos A " +
                   "       OUTER APPLY ( " +
                   "        SELECT TOP 1 ImagenUrl " +
                   "        FROM Imagenes I " +
                   "       WHERE I.IdArticulo = A.Id " +
                   "       ORDER BY I.Id " +
                   ") I1 " +
                   "LEFT JOIN Categorias C ON A.IdCategoria = C.Id " +
                   "LEFT JOIN Marcas     M ON A.IdMarca     = M.Id";



                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {

                    Articulos aux = new Articulos();
                    aux.Id = (int)lector["ID"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Precio = (decimal)lector["Precio"];
                    aux.ImagenUrl = new Imagenes();
                    aux.ImagenUrl.ImagenUrl = (string)lector["ImagenUrl"];
                    aux.Categoria = new Categorias();
                    aux.Marca = new Marcas();
                    aux.Categoria.Id = (int)lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)lector["Categoria"];

                    aux.Marca.Id = (int)lector["IdMarca"];
                    aux.Marca.Descripcion = (string)lector["Marca"];

                    lista.Add(aux);

                }
                conexion.Close();

                return lista;


            }
            catch (Exception ex)
            {
                throw ex;
            }




        }


    }
}
