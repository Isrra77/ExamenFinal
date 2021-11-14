using System;
using System.Collections.Generic;

#nullable disable

namespace ExamenFinal.Models
{
    public partial class TblCatedratico
    {
        public int CatId { get; set; }
        public string CatNombre { get; set; }
        public string CatApellido { get; set; }
        public string CatCorreo { get; set; }
        public string CatStatus { get; set; }
    }
}
