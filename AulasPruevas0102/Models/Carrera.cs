//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AulasPruevas0102.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Carrera
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Carrera()
        {
            this.Grupoes = new HashSet<Grupo>();
        }
    
        public int IdCarrera { get; set; }
        public Nullable<int> IdFacultad { get; set; }
        public string Nombre { get; set; }
    
        public virtual Facultad Facultad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grupo> Grupoes { get; set; }
    }
}