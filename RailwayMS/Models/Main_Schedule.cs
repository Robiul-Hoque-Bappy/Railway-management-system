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
    
    public partial class Main_Schedule
    {
        public int Id { get; set; }
        public Nullable<int> TrainId { get; set; }
        public Nullable<int> SubRouteId { get; set; }
        public Nullable<int> RouteId { get; set; }
        public string Day { get; set; }
        public Nullable<double> ArrivalTime { get; set; }
        public Nullable<double> DepartureTime { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Route Route { get; set; }
        public virtual Sub_Route Sub_Route { get; set; }
        public virtual train train { get; set; }
    }
}