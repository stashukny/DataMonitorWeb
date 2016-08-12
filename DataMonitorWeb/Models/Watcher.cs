//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataMonitorWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Watcher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LevelId { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> SourceId { get; set; }
        public Nullable<int> MetricId { get; set; }
        public int ThreasholdId { get; set; }
        public int NotificationId { get; set; }
        public Nullable<long> LastValue { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Level Level { get; set; }
        public virtual Metric Metric { get; set; }
        public virtual Notification Notification { get; set; }
        public virtual Source Source { get; set; }
        public virtual Threashold Threashold { get; set; }
    }
}
