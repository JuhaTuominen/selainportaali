//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeaMODEPortal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Boat
    {
        public int BoatID { get; set; }
        public int MemberID { get; set; }
        public int RaceID { get; set; }
        public int TrainingID { get; set; }
        public Nullable<int> LoginID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Login Login { get; set; }
        public virtual Member Member { get; set; }
        public virtual Race Race { get; set; }
        public virtual Training Training { get; set; }
    }
}