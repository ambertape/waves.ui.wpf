﻿using Fluid.Presentation.Base;
using Fluid.UI.Windows.Showcase.Services.Interfaces;

namespace Fluid.UI.Windows.Showcase.ViewModel.Tabs
{
    /// <summary>
    /// TextBoxes tab view model.
    /// </summary>
    public class TextBoxesTabViewModel : PresentationViewModel
    {
        private ITextGeneratorService _textGeneratorService;

        /// <summary>
        /// Gets or sets text1.
        /// </summary>
        public string Text1 { get; set; }

        /// <summary>
        /// Gets or sets text1.
        /// </summary>
        public string Text2 { get; set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            _textGeneratorService = App.Core.GetService<ITextGeneratorService>();

            GenerateData();
        }

        /// <summary>
        /// Generates data.
        /// </summary>
        private void GenerateData()
        {
            Text1 = _textGeneratorService.GenerateText();
            Text2 = _textGeneratorService.GenerateText();
        }
    }
}