using System;
using System.Collections.Generic;

namespace MosqueProj.Model
{
    public class YearDTO : CreateYearDTO
    {
        public int Id { get; set; } 
    }

    public class CreateYearDTO
    {
        public DateTime YearDate { get; set; }
    }
}
