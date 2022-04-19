using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebDictionaryProject.Models
{
    public class WordViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Kelime giriniz")]
        [Display(Name  = "Kelime")]
        public string Kelime { get; set; }
        [Required(ErrorMessage = "Kelime anlamı giriniz")]
        [Display(Name = "Kelime anlamı")]
        public string KelimeAnlami { get; set; }
    }
}
