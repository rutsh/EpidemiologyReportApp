using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Location
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? City { get; set; }
        public string? ExactLocation { get; set; }
        public string PatientId { get; set; } = null!;

        public virtual Patient Patient { get; set; } = null!;
    }
}
