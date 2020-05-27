﻿using Waves.Core.Base.Interfaces;
using Waves.UI.Windows.Controls.Modality.ViewModel;

namespace Waves.UI.Windows.Showcase.ViewModel.ModalWindow
{
    /// <summary>
    /// Show property modal window view model.
    /// </summary>
    public class ShowPropertyModalWindowViewModel : ModalWindowPresentationViewModel
    {
        /// <summary>
        /// Creates new instance of <see cref="ShowPropertyModalWindowViewModel"/>.
        /// </summary>
        public ShowPropertyModalWindowViewModel(IProperty property)
        {
            Property = property;
        }

        /// <summary>
        /// Gets  property.
        /// </summary>
        public IProperty Property { get; }

        /// <inheritdoc />
        public override void Initialize()
        {
        }
    }
}