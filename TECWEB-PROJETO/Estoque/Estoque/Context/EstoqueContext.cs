using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ControleEstoque.Context
{
    public class EstoqueContext : DbContext
    {
      
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Companhia> Companhias { get; set; }

        public DbSet<CategoriaProduto> Categorias { get; set; }

    }
}