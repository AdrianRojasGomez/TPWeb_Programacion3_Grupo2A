using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Dominio;
using negocio;

namespace PromoWeb_Programacion3
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = "Ingrese el codigo aqui";
        }

        protected void BtnConfigVouchers_Click(object sender, EventArgs e)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
          
           List<Voucher>listavoucher = new List<Voucher>();
            

          /*
            accesoDatos.SetearConsulta("SELECT  a.Codigo, a.Nombre, a.Descripcion, a.Precio,m.Descripcion AS Marca,   c.Descripcion AS Categoria,i.ImagenUrl FROM Articulos a LEFT JOIN Marcas m     ON m.Id = a.IdMarca  LEFT JOIN Categorias c ON c.Id = a.IdCategoria left join IMAGENES i on i.IdArticulo = a.Id WHERE Codigo = @Codigo");


            accesoDatos.SetearParametros("@Codigo", articulo.Trim());
            accesoDatos.EjecutarLectura();*/




            try
            {
                
                accesoDatos.SetearParametros();
                accesoDatos.SetearParametros();

                accesoDatos.SetearParametros();

                while (accesoDatos.Lector.Read()) { 
                
                    
                
                
                }


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

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {






        }


        public List<Voucher> listavoucher(string voucher)
        {

            AccesoDatos accesoDatos = new AccesoDatos();

            List<Voucher> listavoucher = new List<Voucher>();


            /*
              accesoDatos.SetearConsulta("SELECT  a.Codigo, a.Nombre, a.Descripcion, a.Precio,m.Descripcion AS Marca,   c.Descripcion AS Categoria,i.ImagenUrl FROM Articulos a LEFT JOIN Marcas m     ON m.Id = a.IdMarca  LEFT JOIN Categorias c ON c.Id = a.IdCategoria left join IMAGENES i on i.IdArticulo = a.Id WHERE Codigo = @Codigo");


              accesoDatos.SetearParametros("@Codigo", articulo.Trim());
              accesoDatos.EjecutarLectura();*/




            try
            {

                accesoDatos.SetearConsulta("select  v.CodigoVoucher,v.IdCliente,v.FechaCanje,v.IdArticulo " + " from Vouchers v " + "WHERE v.CodigoVoucher = @CodigoVoucher");
                accesoDatos.SetearParametros("@CodigoVoucher",voucher.Trim());
                accesoDatos.EjecutarLectura();

               

                while (accesoDatos.Lector.Read())
                {
                  /*
                    Articulo aux = new Articulo();


                    aux.Codigo = (string)accesoDatos.Lector["Codigo"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    aux.Precio = (decimal)accesoDatos.Lector["Precio"];*/

                    Voucher aux = new Voucher();

                    aux.CodigoVouchers = (string)accesoDatos.Lector["CodigoVoucher"];

                    if (accesoDatos.Lector["FechaCanje"] != DBNull.Value)
                        aux.FechaCanje = (DateTime)accesoDatos.Lector["FechaCanje"];
                    else
                        aux.FechaCanje = null;
                    

                    listavoucher.Add(aux);


                }
                return listavoucher;

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