//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentskaSluzba2.App_Start
{
    using System;
    using System.Collections.Generic;
    
    public partial class Studij
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Studij()
        {
            this.Godinas = new HashSet<Godina>();
            this.Godina_Studij = new HashSet<Godina_Studij>();
        }
    
        public int ID_studij { get; set; }
        public string Naziv { get; set; }
        public Nullable<int> ID_smjer { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Godina> Godinas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Godina_Studij> Godina_Studij { get; set; }
        public virtual Smjer Smjer { get; set; }
    }
}