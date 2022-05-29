using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Selling.Models
{
    public class VentaDetalleModel
    {
        public string IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
