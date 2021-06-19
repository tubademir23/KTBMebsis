using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KTB.API.DTOs
{
    public class UyeDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanını girin.")]
        public String Adi { get; set; }
        public String Soyadi { get; set; }
        public int MeslekId { get; set; }
    }
}
