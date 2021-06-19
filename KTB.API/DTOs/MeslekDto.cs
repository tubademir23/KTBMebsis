using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KTB.API.DTOs
{
    public class MeslekDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanını girin.")]
        public string Adi { get; set; }
    }
}
