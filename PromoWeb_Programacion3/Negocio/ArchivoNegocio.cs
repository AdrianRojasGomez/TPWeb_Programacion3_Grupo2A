using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using dominio;
using negocio;


namespace negocio

{
    public class ArchivoNegocio
    {
        /*public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(
                    "SELECT A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.Id, " +
                    "ISNULL(I1.ImagenUrl, '') AS ImagenUrl, " +
                    "ISNULL(C.Id, 0) AS IdCategoria, ISNULL(C.Descripcion, '') AS Categoria, " +
                    "ISNULL(M.Id, 0) AS IdMarca, ISNULL(M.Descripcion, '') AS Marca, " +
                    "ISNULL(CL.Id, 0) AS Id, ISNULL(CL.Documento, '') AS Documento, " +
                    "ISNULL(CL.Nombre, '') AS NombreCliente, ISNULL(CL.Apellido, '') AS ApellidoCliente, " +
                    "ISNULL(CL.Email, '') AS EmailCliente, ISNULL(CL.Direccion, '') AS DireccionCliente, " +
                    "ISNULL(CL.Ciudad, '') AS CiudadCliente, ISNULL(CL.CP, 0) AS CPCliente, " +
                    "ISNULL(V.CodigoVoucher, '') AS CodigoVoucher, ISNULL(V.FechaCanje, NULL) AS FechaCanje " +
                    "FROM Articulos A " +
                    "OUTER APPLY ( " +
                    "    SELECT TOP 1 ImagenUrl " +
                    "    FROM Imagenes I " +
                    "    WHERE I.IdArticulo = A.Id " +
                    "    ORDER BY I.Id " +
                    ") I1 " +
                    "LEFT JOIN Categorias C ON A.IdCategoria = C.Id " +
                    "LEFT JOIN Marcas M ON A.IdMarca = M.Id " +
                    "LEFT JOIN Vouchers V ON A.Id = V.IdArticulo " +
                    "LEFT JOIN Clientes CL ON V.Id = CL.Id"
                );

                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.ImagenUrl = new dominio.Imagen { ImagenUrl = (string)datos.Lector["ImagenUrl"] };

                    aux.Categoria = new dominio.Categoria
                    {
                        Id = (int)datos.Lector["IdCategoria"],
                        Descripcion = (string)datos.Lector["Categoria"]
                    };

                    aux.Marca = new dominio.Marca
                    {
                        Id = (int)datos.Lector["IdMarca"],
                        Descripcion = (string)datos.Lector["Marca"]
                    };
                    
                    aux.Cliente = new dominio.Cliente
                    {
                        Id = (int)datos.Lector["Id"],
                        Documento = (string)datos.Lector["Documento"],
                        Nombre = (string)datos.Lector["NombreCliente"],
                        Apellido = (string)datos.Lector["ApellidoCliente"],
                        Email = (string)datos.Lector["EmailCliente"],
                        Direccion = (string)datos.Lector["DireccionCliente"],
                        Ciudad = (string)datos.Lector["CiudadCliente"],
                        CP = (int)datos.Lector["CPCliente"]
                    };

                    aux.Voucher = new dominio.Voucher
                    {
                        CodigoVoucher = (string)datos.Lector["CodigoVoucher"],
                        FechaCanje = (DateTime)(datos.Lector["FechaCanje"] != DBNull.Value ? (DateTime)datos.Lector["FechaCanje"] : (DateTime?)null)
                    };

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
                datos.CerrarConexion();
            }
        }*/

        public List<Articulo> ListarConSP()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {


                datos.SetearSP("SP_ObtenerArticulos");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.ImagenUrl = new dominio.Imagen { ImagenUrl = (string)datos.Lector["ImagenUrl"] };

                    aux.Categoria = new dominio.Categoria
                    {
                        Id = (int)datos.Lector["IdCategoria"],
                        Descripcion = (string)datos.Lector["Categoria"]
                    };

                    aux.Marca = new dominio.Marca
                    {
                        Id = (int)datos.Lector["IdMarca"],
                        Descripcion = (string)datos.Lector["Marca"]
                    };

                    aux.Cliente = new dominio.Cliente
                    {
                        Id = datos.Lector["IdCliente"] != DBNull.Value ? (int)datos.Lector["IdCliente"] : 0,
                        Documento = datos.Lector["Documento"] != DBNull.Value ? (string)datos.Lector["Documento"] : "",
                        Nombre = datos.Lector["NombreCliente"] != DBNull.Value ? (string)datos.Lector["NombreCliente"] : "",
                        Apellido = datos.Lector["ApellidoCliente"] != DBNull.Value ? (string)datos.Lector["ApellidoCliente"] : "",
                        Email = datos.Lector["EmailCliente"] != DBNull.Value ? (string)datos.Lector["EmailCliente"] : "",
                        Direccion = datos.Lector["DireccionCliente"] != DBNull.Value ? (string)datos.Lector["DireccionCliente"] : "",
                        Ciudad = datos.Lector["CiudadCliente"] != DBNull.Value ? (string)datos.Lector["CiudadCliente"] : "",
                        CP = datos.Lector["CPCliente"] != DBNull.Value ? (int)datos.Lector["CPCliente"] : 0
                    };

                    aux.Voucher = new dominio.Voucher
                    {
                        CodigoVoucher = datos.Lector["CodigoVoucher"] != DBNull.Value ? (string)datos.Lector["CodigoVoucher"] : "",
                        FechaCanje = datos.Lector["FechaCanje"] != DBNull.Value ? (DateTime?)datos.Lector["FechaCanje"] : null
                    };


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

                datos.CerrarConexion();
            }
        }
        //metodo para agregar articulos
        public int Agregar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                AccesoDatos datosVerif = new AccesoDatos();
                datosVerif.SetearConsulta("SELECT COUNT(*) FROM Articulos WHERE Codigo = @Codigo");
                datosVerif.SetearParametros("@Codigo", articulo.Codigo);
                int count = Convert.ToInt32(datosVerif.EjecutarEscalar());
                datosVerif.CerrarConexion();

                if (count > 0)
                {
                    throw new Exception("Ya existe un artículo con el código: " + articulo.Codigo);
                }

                // Inserto el artículo
                datos.SetearConsulta(
                        "INSERT INTO Articulos (Codigo, Nombre, Descripcion, Precio, IdCategoria, IdMarca) " +
                        "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @IdCategoria, @IdMarca); " +
                        "SELECT SCOPE_IDENTITY();"
                    );

                    datos.SetearParametros("@Codigo", articulo.Codigo);
                    datos.SetearParametros("@Nombre", articulo.Nombre);
                    datos.SetearParametros("@Descripcion", articulo.Descripcion);
                    datos.SetearParametros("@Precio", articulo.Precio);
                    datos.SetearParametros("@IdCategoria", articulo.Categoria.Id);
                    datos.SetearParametros("@IdMarca", articulo.Marca.Id);


                    int idArticulo = Convert.ToInt32(datos.EjecutarEscalar());


                    if (!string.IsNullOrEmpty(articulo.ImagenUrl.ImagenUrl))
                    {
                        AccesoDatos datosImg = new AccesoDatos();
                        datosImg.SetearConsulta(
                            "INSERT INTO Imagenes (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)"
                        );
                        datosImg.SetearParametros("@IdArticulo", idArticulo);
                        datosImg.SetearParametros("@ImagenUrl", articulo.ImagenUrl.ImagenUrl);
                        datosImg.EjecutarAccion();
                        datosImg.CerrarConexion();
                    }

                    return idArticulo;
                }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        //metodo para modificar articulos
        public int Modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            AccesoDatos datosImg = null;

            try
            {
                datos.SetearConsulta(
                    "UPDATE Articulos " +
                    "SET Codigo = @Codigo, " +
                    "    Nombre = @Nombre, " +
                    "    Descripcion = @Descripcion, " +
                    "    Precio = @Precio, " +
                    "    IdCategoria = @IdCategoria, " +
                    "    IdMarca = @IdMarca " +
                    "WHERE Id = @Id;"
                );

                datos.SetearParametros("@Id", articulo.Id);
                datos.SetearParametros("@Codigo", articulo.Codigo);
                datos.SetearParametros("@Nombre", articulo.Nombre);
                datos.SetearParametros("@Descripcion", articulo.Descripcion);
                datos.SetearParametros("@Precio", articulo.Precio);
                datos.SetearParametros("@IdCategoria", articulo.Categoria.Id);
                datos.SetearParametros("@IdMarca", articulo.Marca.Id);

                datos.EjecutarAccion();

                
                if (!string.IsNullOrEmpty(articulo.ImagenUrl?.ImagenUrl))
                {
                    datosImg = new AccesoDatos();
                    datosImg.SetearConsulta(
                        "IF EXISTS (SELECT 1 FROM Imagenes WHERE IdArticulo = @IdArticulo) " +
                        "   UPDATE Imagenes SET ImagenUrl = @ImagenUrl WHERE IdArticulo = @IdArticulo; " +
                        "ELSE " +
                        "   INSERT INTO Imagenes (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl);"
                    );
                    datosImg.SetearParametros("@IdArticulo", articulo.Id);
                    datosImg.SetearParametros("@ImagenUrl", articulo.ImagenUrl.ImagenUrl);
                    datosImg.EjecutarAccion();
                    datosImg.CerrarConexion();
                }

                return articulo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();                    
            }
        }
        //metodo para eliminar articulos
        public void Eliminar(int id)
        {
            try
            {
                AccesoDatos accesoDatos = new AccesoDatos();
                accesoDatos.SetearConsulta("DELETE FROM CATALOGO_P3_DB.dbo.ARTICULOS WHERE Id = @Id");
                accesoDatos.SetearParametros("@Id", id);
                accesoDatos.EjecutarAccion();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }

}
