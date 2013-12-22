using System;
using SolarSystem.Earth.DataAccess.Model;

namespace SolarSystem.Earth.DataAccess.DataAccess
{
    public abstract class DALBase
    {
        protected static readonly SunModelEntities Db = new SunModelEntities();
    }
}