//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RailwayMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class train
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public train()
        {
            this.Main_Schedule = new HashSet<Main_Schedule>();
            this.Main_Schedule_Details = new HashSet<Main_Schedule_Details>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<double> speed { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Main_Schedule> Main_Schedule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Main_Schedule_Details> Main_Schedule_Details { get; set; }
    }
}
