using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleEstoque.Models
{
    public class Departamento { 
    
        [Key]
        [Required]
        public int Id { get; set; }

        [DisplayName("Nome")]
        [StringLength(50)]
        [Required]
        public string Nome { get; set; }
        [NotMapped]
        public Companhia Companhia { get; set; }
 
        public int CompanhiaId { get; set; }

    }
}