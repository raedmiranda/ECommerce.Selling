using System;

namespace ECommerce.Selling.Models
{
    public class VentaModel
    {
        public string Id { get; set; }
        public int IdUsuario { get; set; }
        public decimal precioTotal { get; set; }
        public string medioDePago { get; set; }
        public DateTime fecha { get; set; }
    }
}
