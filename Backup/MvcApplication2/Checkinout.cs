//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Checkinout
    {
        public int Logid { get; set; }
        public string Userid { get; set; }
        public System.DateTime CheckTime { get; set; }
        public string CheckType { get; set; }
        public string Sensorid { get; set; }
        public bool Checked { get; set; }
        public Nullable<int> WorkType { get; set; }
        public Nullable<int> AttFlag { get; set; }
        public bool OpenDoorFlag { get; set; }
    
        public virtual Userinfo Userinfo { get; set; }
    }
}
