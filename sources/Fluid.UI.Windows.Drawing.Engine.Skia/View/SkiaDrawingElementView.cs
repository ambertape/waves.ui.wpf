﻿using System;
using System.ComponentModel;
using Fluid.Core.Base;
using Fluid.Core.Base.Interfaces;
using Fluid.Core.Services.Interfaces;
using Fluid.UI.Windows.Drawing.Engine.Skia.Behavior;
using Fluid.UI.Windows.Controls.Drawing.View.Interfaces;
using Microsoft.Xaml.Behaviors;
using SkiaSharp.Views.WPF;

namespace Fluid.UI.Windows.Drawing.Engine.Skia.View
{
    /// <summary>
    ///     Drawing canvas.
    /// </summary>
    [Category("Fluid - Drawing")]
    public class SkiaDrawingElementView : SKElement, IDrawingElementView
    {
        /// <summary>
        /// Creates new instance of <see cref="SkiaDrawingElementView" />.
        /// </summary>
        /// <param name="inputService">Input service.</param>
        public SkiaDrawingElementView(IInputService inputService)
        {
            InitializeBehaviors(inputService);
            SubscribeEvents();
        }

        /// <summary>
        ///     Finalizes instance.
        /// </summary>
        ~SkiaDrawingElementView()
        {
            Dispose();
        }

        /// <inheritdoc />
        public event EventHandler<IMessage> MessageReceived;

        /// <summary>
        ///     Notifies when message received.
        /// </summary>
        /// <param name="e">Message.</param>
        protected virtual void OnMessageReceived(IMessage e)
        {
            MessageReceived?.Invoke(this, e);
        }

        /// <summary>
        /// Initializes behaviors.
        /// </summary>
        /// <param name="inputService">Input service.</param>
        private void InitializeBehaviors(IInputService inputService)
        {
            Interaction.GetBehaviors(this).Add(new SkiaPaintBehavior(inputService));
        }

        /// <summary>
        ///     Subscribes events.
        /// </summary>
        private void SubscribeEvents()
        {
        }

        /// <summary>
        ///     Unsubscribe events.
        /// </summary>
        private void UnsubscribeEvents()
        {
        }

        /// <inheritdoc />
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            UnsubscribeEvents();
        }
    }
}