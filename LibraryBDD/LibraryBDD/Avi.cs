//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryBDD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Avi
    {
        public int Id { get; set; }
        public double Note { get; set; }
        public string Commentaire { get; set; }
        public int User_Id { get; set; }
        public int Movies_Id { get; set; }
    
        public virtual Movy Movy { get; set; }
        public virtual User User { get; set; }
    }
}
