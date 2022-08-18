using System;
using System.Collections.Generic;

namespace CreditosMicroAgroAPI.Models
{
    public partial class Loan
    {
        public long Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string? TipoProducto { get; set; }
        public decimal? Monto { get; set; }
        public string? Plazo { get; set; }
        public long? Cliente { get; set; }
    }
}
