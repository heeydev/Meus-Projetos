using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PottencialPaymentAPI.Models
{
    public class Registro
    {
        public int IdVendedor { get; set; }                
        public int Id { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }        
        public EnumStatusRegistro Status { get; set; }
    }    
}