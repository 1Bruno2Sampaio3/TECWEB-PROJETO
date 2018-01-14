using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleEstoque.Models
{
    public class CategoriaProduto
    {
        [Key, Required(ErrorMessage = "É necessário adicionarum nome")]
        public int Id { get; set; }

        [Required(ErrorMessage ="É necessário adicionarum nome"),
         StringLength(15, MinimumLength = 3, ErrorMessage = "Necessário no minimo 3 e no máximo 15 letras.")
        ]
        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}