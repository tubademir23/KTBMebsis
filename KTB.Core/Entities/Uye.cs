using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KTB.Core.Entities
{
    public class Uye
    {
        public Uye()
        {
            Eserler = new Collection<Eser>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public String Adi { get; set; }
        public String Soyadi { get; set; }
        public int MeslekId { get; set; }
        public bool SilindiMi { get; set; }

        //for tracking
        public Meslek Meslek { get; set; }
        public ICollection<Eser> Eserler{ get; set; }
        
    }
}
