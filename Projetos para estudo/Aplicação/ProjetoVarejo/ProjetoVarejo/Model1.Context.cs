﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoVarejo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class varejoEntities : DbContext
    {
        public varejoEntities()
            : base("name=varejoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cliente_tb> cliente_tb { get; set; }
        public virtual DbSet<funcionario_tb> funcionario_tb { get; set; }
        public virtual DbSet<produto_tb> produto_tb { get; set; }
        public virtual DbSet<venda_tb> venda_tb { get; set; }
    }
}
