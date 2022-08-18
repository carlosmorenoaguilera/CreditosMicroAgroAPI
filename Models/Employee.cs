using System;
using System.Collections.Generic;

namespace CreditosMicroAgroAPI.Models
{
    public partial class Employee
    {
        public long Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Nombre { get; set; }
        public string? Identidad { get; set; }
        public string? Tipo { get; set; }
        public Guid? IdGuid { get; set; }
        public string? Email { get; set; }
    }
}
