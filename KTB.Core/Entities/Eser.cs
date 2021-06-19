
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTB.Core.Entities
{
    public class Eser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string EserAdi { get; set; }
        public int UyeId { get; set; }
        public bool SilindiMi { get; set; }
        //for tracking
        public virtual Uye Uye { get; set; }
    }
}
