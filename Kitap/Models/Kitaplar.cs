using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kitap.Models
{
    public class Kitaplar
    {
        [Key]
        public int Id { get; set; }
        public string KitapAdi { get; set; }
        public int KitapSayfaSayisi { get; set; }
        public string Ozet { get; set; }
        public string YazarAdi { get; set; }
        public byte[] Image { get; set; }
    }
}
