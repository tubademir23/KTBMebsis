using KTB.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KTB.API.DTOs
{
    public class EserWithUyeDto:EserDto
    {
       
        public UyeDto Uye { get; set; }
    }
}
