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
    
    public partial class Zalba
    {
        public int ID_Zalba { get; set; }
        public Nullable<int> ID_Student { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
