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
    
    public partial class Predmet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Predmet()
        {
            this.Plan_i_program = new HashSet<Plan_i_program>();
            this.Predmet_Hijerarhija = new HashSet<Predmet_Hijerarhija>();
            this.Predmet_Hijerarhija1 = new HashSet<Predmet_Hijerarhija>();
        }
    
        public int ID_Predmet { get; set; }
        public string Naziv { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Plan_i_program> Plan_i_program { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Predmet_Hijerarhija> Predmet_Hijerarhija { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Predmet_Hijerarhija> Predmet_Hijerarhija1 { get; set; }
    }
}