using System;

namespace EPSILab.SolarSystem.Earth.Common
{
    [Flags]
    public enum Role
    {
        Inactive = 0x0,
        MemberActive = 0x1,
        Bureau = 0x2 | MemberActive
    }
}