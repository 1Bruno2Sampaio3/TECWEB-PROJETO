using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleEstoque.Models
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="É necessário existir um nome"),
         StringLength(20,MinimumLength = 3, ErrorMessage = "Necessário no minimo 3 e no máximo 15 letras.")]
        public string Nome { get; set; }

    }
}