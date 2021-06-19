
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTB.Core.Entities
{
    public class Meslek
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order =0)]
        public int Id { get; set; }
        public string Adi { get; set; }
    }
}
