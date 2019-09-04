using System;
using System.Collections.Generic;

namespace SkolaMvc.Models
{
    public partial class Studenti
    {
        public int IdStudent { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime? DatumRođenja { get; set; }
        public string MestoRođenja { get; set; }
    }
}
