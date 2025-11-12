using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Countries.Dtos
{
    public class UpdateCountryDto
    {
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public int? Code { get; set; }
        public string? Icon { get; set; }
    }
}
