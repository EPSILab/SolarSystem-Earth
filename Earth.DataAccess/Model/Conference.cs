//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EPSILab.SolarSystem.Earth.DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Conference
    {
        public int Id { get; set; }
        public int IdCampus { get; set; }
        public string Name { get; set; }
        public System.DateTime Start_DateTime { get; set; }
        public System.DateTime End_DateTime { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPublished { get; set; }
        public string Url { get; set; }
    
        public virtual Campus Campus { get; set; }
    }
}
