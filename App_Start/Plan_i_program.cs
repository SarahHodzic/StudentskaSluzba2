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
    
    public partial class Plan_i_program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plan_i_program()
        {
            this.Pohadjanjes = new HashSet<Pohadjanje>();
            this.Izborni_predmet = new HashSet<Izborni_predmet>();
        }
    
        public int ID_plan_i_program { get; set; }
        public Nullable<int> ID_predmet { get; set; }
        public Nullable<int> ID_tipn { get; set; }
        public Nullable<int> ID_Godina_Studij { get; set; }
    
        public virtual Predmet Predmet { get; set; }
        public virtual Tip_Nastave Tip_Nastave { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pohadjanje> Pohadjanjes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Izborni_predmet> Izborni_predmet { get; set; }
    }
}
