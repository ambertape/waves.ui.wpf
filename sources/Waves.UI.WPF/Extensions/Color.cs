﻿using Waves.Core.Base;

namespace Waves.UI.WPF.Extensions
{
    /// <summary>
    ///     Color extensions.
    /// </summary>
    public static class Color
    {
        /// <summary>
        ///     Converts System.Windows.Media.Color to Waves.Core.Base.Color.
        /// </summary>
        /// <param name="color">Instance of System.Windows.Media.Color.</param>
        /// <returns>New instance of Waves.Core.Base.Color.</returns>
        public static WavesColor ToWavesColor(this System.Windows.Media.Color color)
        {
            return new WavesColor(color.A, color.R, color.G, color.B);
        }

        /// <summary>
        ///     Converts System.Windows.Media.Color to Waves.Core.Base.Color.
        /// </summary>
        /// <param name="color">Instance of System.Windows.Media.Color.</param>
        /// <returns>New instance of Waves.Core.Base.Color.</returns>
        public static System.Windows.Media.Color ToSystemColor(this WavesColor color)
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