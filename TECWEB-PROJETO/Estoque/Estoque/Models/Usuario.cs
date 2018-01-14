using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleEstoque.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome")]
        [StringLength(50)]
        [Required]
        public string Nome { get; set; }

        [DisplayName("E-mail")]
        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        [DisplayName("Senha")]
        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 4)]
        public string Senha { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido!")]
        public DateTime DataNascimento { get; set; }
    }
}