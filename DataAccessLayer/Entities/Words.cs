using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Words
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kelime giriniz")]
        [Display(Name = "Kelime")]
        public string Kelime { get; set; }
        [Required(ErrorMessage = "Kelime anlamı giriniz")]
        [Display(Name = "Kelime anlamı")]
        public string KelimeAnlami { get; set; }
    }
}
