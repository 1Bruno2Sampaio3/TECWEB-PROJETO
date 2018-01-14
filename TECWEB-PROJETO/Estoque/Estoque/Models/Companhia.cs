using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleEstoque.Models
{
    public class Companhia
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome")]
        [StringLength(50)]
        [Required]
        public string Nome { get; set; }

        [DisplayName("CNPJ")]
        public string Cnpj { get; set; }

        [DisplayName("Endereco")]
        [StringLength(80)]
        [Required]
        public string Endereco { get; set; }
    }
}