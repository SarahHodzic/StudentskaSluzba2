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
    
    public partial class Predmet_Hijerarhija
    {
        public int ID_Predmet_Hijerarhija { get; set; }
        public int ID_Predmet { get; set; }
        public int ID_Predmet_Uslov { get; set; }
    
        public virtual Predmet Predmet { get; set; }
        public virtual Predmet Predmet1 { get; set; }
    }
}
