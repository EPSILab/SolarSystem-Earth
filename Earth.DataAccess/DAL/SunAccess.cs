using System;
using SolarSystem.Earth.DataAccess.Model;

namespace SolarSystem.Earth.DataAccess.DAL
{
    /// <summary>
    /// Singleton class for database access
    /// </summary>
    public class SunAccess
    {
        #region Constructors

        /// <summary>
        /// Static constructor. Initialize the database access
        /// </summary>
        static SunAccess()
        {
            Lazy = new Lazy<SunModelEntities>(() => new SunModelEntities());
        }

        /// <summary>
        /// Private constructor to prevent creating instances
        /// </summary>
        private SunAccess()
        {
        }

        #endregion

        #region Attributes

        /// <summary>
        /// Lazy instance
        /// </summary>
        private static readonly Lazy<SunModelEntities> Lazy;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the database access instance
        /// </summary>
        public static SunModelEntities Instance
        {
            get { return Lazy.Value; }
        }

        #endregion
    }
}