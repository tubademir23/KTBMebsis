using KTB.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KTB.API.DTOs
{
    public class UyeWithEserDto:UyeDto
    {
       
        public ICollection<EserDto> Eserler { get; set; }
        public int EserSayisi
        {
            get
            {
                return Eserler.Count();
            }
        }

    }
}
