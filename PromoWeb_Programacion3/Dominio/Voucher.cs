using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Voucher
    {

        public int Id { get; set; }

        public string CodigoVouchers { get; set; }  

        public DateTime? FechaCanje { get; set; }

        public int IdCliente { get; set; }   
        public int IdArticulo { get; set; }






    }
}
