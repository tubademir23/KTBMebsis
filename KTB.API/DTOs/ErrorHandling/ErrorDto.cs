using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTB.API.DTOs.ErrorHandling
{
    public class ErrorDto
    {
        public ErrorDto(int status)
        {
            Status = status;
            Errors = new List<string>(); 
        }
        public List<String> Errors{ get; set; }
        public int Status { get; set; }
    }
}
