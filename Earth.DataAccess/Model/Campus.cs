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
    
    public partial class Campus
    {
        public Campus()
        {
            this.Conference = new HashSet<Conference>();
            this.Member = new HashSet<Member>();
            this.Project = new HashSet<Project>();
        }
    
        public int Id { get; set; }
        public string Place { get; set; }
        public string ContactEmail { get; set; }
    
        public virtual ICollection<Conference> Conference { get; set; }
        public virtual ICollection<Member> Member { get; set; }
        public virtual ICollection<Project> Project { get; set; }
    }
}
