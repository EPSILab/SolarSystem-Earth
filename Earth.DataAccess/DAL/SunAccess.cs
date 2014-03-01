using EPSILab.SolarSystem.Earth.DataAccess.Model;
using System;

namespace EPSILab.SolarSystem.Earth.DataAccess.DAL
{
    /// <summary>
    /// Singleton class for database access
    /// </summary>
    static class SunAccess
    {
        #region Constructors

        /// <summary>
        /// Static constructor. Initialize the database access
        /// </summary>
        static SunAccess()
        {
            Lazy = new Lazy<SunEntities>(() => new SunEntities());
        }

        #endregion

        #region Attributes

        /// <summary>
        /// Lazy instance
        /// </summary>
        private static readonly Lazy<SunEntities> Lazy;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the database access instance
        /// </summary>
        public static SunEntities Instance
        {
            get { return Lazy.Value; }
        }

        #endregion
    }
}