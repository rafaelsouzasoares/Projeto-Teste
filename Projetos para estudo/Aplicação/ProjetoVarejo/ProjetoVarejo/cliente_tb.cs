//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class cliente_tb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente_tb()
        {
            this.venda_tb = new HashSet<venda_tb>();
        }
    
        public int cliente_id { get; set; }
        public string nome_cli { get; set; }
        public int cpf { get; set; }
        public int rg { get; set; }
        public Nullable<System.DateTime> data_nascimento { get; set; }
        public Nullable<int> telefone { get; set; }
        public string email { get; set; }
        public string endereco { get; set; }
        public Nullable<int> cep { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<venda_tb> venda_tb { get; set; }
    }
}
