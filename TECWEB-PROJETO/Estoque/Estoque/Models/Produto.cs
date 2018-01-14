using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleEstoque.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="É necessário digitar um nome"), StringLength(20, ErrorMessage = "Máximo de 20 caracteres")]
        public string Nome { get; set; }

        public string Descricao { get; set; }
        [Required,Range(0,999.99,ErrorMessage ="Valor inválido. Insira um valor menor que 1000")]
        public int Quantidade { get; set; }
        [StringLength(20,ErrorMessage ="Máximo de 20 caracteres")]
        public string CodigoExterno { get; set; }

        [Required(ErrorMessage = "Selecione um fornecedor")]
        public int FornecedorId { get; set; }

        [Required(ErrorMessage = "Selecione uma categoria")]
        public int CategoriaId { get; set; }
    }
}