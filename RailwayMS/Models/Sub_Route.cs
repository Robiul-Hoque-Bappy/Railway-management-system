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
    
    public partial class Sub_Route
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sub_Route()
        {
            this.Main_Schedule = new HashSet<Main_Schedule>();
        }
    
        public int Id { get; set; }
        public string Station_Name { get; set; }
        public Nullable<int> RouteId { get; set; }
        public bool IsActive { get; set; }
        public Nullable<double> Distance { get; set; }
        public Nullable<int> ShortOrder { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Main_Schedule> Main_Schedule { get; set; }
        public virtual Route Route { get; set; }
    }
}