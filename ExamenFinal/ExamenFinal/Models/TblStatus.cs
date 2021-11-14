using System;
using System.Collections.Generic;

#nullable disable

namespace ExamenFinal.Models
{
    public partial class TblStatus
    {
        public int StatusId { get; set; }
        public int? StatusCat { get; set; }
        public int? StatusCurs { get; set; }
        public string Status { get; set; }
    }
}
