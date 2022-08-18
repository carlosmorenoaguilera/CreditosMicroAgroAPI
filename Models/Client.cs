using System;
using System.Collections.Generic;

namespace CreditosMicroAgroAPI.Models
{
    public partial class Client
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? Identidad { get; set; }
        public string? Ciudad { get; set; }
    }
}
