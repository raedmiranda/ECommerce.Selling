using System;
using System.Collections.Generic;

namespace ECommerce.Selling.Models
{
    public class VentaModel
    {
        public string Id { get; set; }
        public int IdUsuario { get; set; }
        public decimal PrecioTotal { get; set; }
        public string MedioDePago { get; set; }
        public DateTime Fecha { get; set; }

        public List<VentaDetalleModel> Detalle { get; set; }
    }
}
