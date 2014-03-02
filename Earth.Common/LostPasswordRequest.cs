using System;

namespace EPSILab.SolarSystem.Earth.Common
{
    public class LostPasswordRequest
    {
        public int Id { get; set; }
        public Member Member { get; set; }
        public DateTime RequestDateTime { get; set; }
        public string GeneratedKey { get; set; }
    }
}