﻿namespace Fluid.UI.Windows.Extensions
{
    /// <summary>
    ///     Color extensions.
    /// </summary>
    public static class Color
    {
        /// <summary>
        ///     Converts System.Windows.Media.Color to Fluid.Core.Base.Color.
        /// </summary>
        /// <param name="color">Instance of System.Windows.Media.Color.</param>
        /// <returns>New instance of Fluid.Core.Base.Color.</returns>
        public static Fluid.Core.Base.Color ToFluidColor(this System.Windows.Media.Color color)
        {
            return new Fluid.Core.Base.Color(color.A, color.R, color.G, color.B);
        }

        /// <summary>
        ///     Converts System.Windows.Media.Color to Fluid.Core.Base.Color.
        /// </summary>
        /// <param name="color">Instance of System.Windows.Media.Color.</param>
        /// <returns>New instance of Fluid.Core.Base.Color.</returns>
        public static System.Windows.Media.Color ToSystemColor(this Fluid.Core.Base.Color color)
        {
            return new System.Windows.Media.Color()
            {
                A = color.A,
                R = color.R,
                G = color.G,
                B = color.B
            };
        }
    }
}