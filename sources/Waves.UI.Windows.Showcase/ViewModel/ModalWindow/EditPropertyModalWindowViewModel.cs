﻿using System;
using System.Collections.ObjectModel;
using Waves.Core.Base;
using Waves.Core.Base.Interfaces;
using Waves.UI.Windows.Controls.Modality.Base.Interfaces;
using Waves.UI.Windows.Controls.Modality.ViewModel;

namespace Waves.UI.Windows.Showcase.ViewModel.ModalWindow
{
    public class EditPropertyModalWindowViewModel : ModalWindowPresentationViewModel
    {
        private IModalWindowAction _action;
        private object _value;
        private Type _type = typeof(int);

        /// <summary>
        /// Creates new instance of <see cref="AddPropertyModalWindowViewModel"/>.
        /// </summary>
        public EditPropertyModalWindowViewModel(IProperty property)
        {
            Name = property.Name;
            Value = property.GetValue();
            CanBeDeleted = property.CanBeDeleted;
            IsReadOnly = property.IsReadOnly;
        }

        /// <summary>
        /// Gets whether property can be deleted.
        /// </summary>
        public bool CanBeDeleted { get; set; }

        /// <summary>
        /// Gets whether property is read only.
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; } = "New property";

        /// <summary>
        /// Gets or sets value.
        /// </summary>
        public object Value
        {
            get => _value;
            set
            {
                _value = value;

                try
                {
                    ConvertedValue = Convert.ChangeType(_value, Type);
                }
                catch (Exception e)
                {
                    OnMessageReceived(new Message(e, false));
                }

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets converted value.
        /// </summary>
        public object ConvertedValue { get; set; }

        /// <summary>
        /// Gets or sets type.
        /// </summary>
        public Type Type
        {
            get => _type;
            set
            {
                _type = value;

                try
                {
                    ConvertedValue = Convert.ChangeType(_value, Type);
                }
                catch (Exception e)
                {
                    OnMessageReceived(new Message(e, false));
                }

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets collection of types.
        /// </summary>
        public ObservableCollection<Type> Types { get; } = new ObservableCollection<Type>()
        {
            typeof(short),
            typeof(int),
            typeof(long),
            typeof(float),
            typeof(double),
            typeof(string),
        };

        /// <inheritdoc />
        public override void Initialize()
        {
            PropertyChanged += OnPropertyChanged;

            InitializeAction();
        }

        /// <summary>
        /// Gets result property.
        /// </summary>
        /// <returns>Property.</returns>
        public IProperty GetResultProperty()
        {
            var type = typeof(Property<>).MakeGenericType(Type);
            var args = new object[] { Name, ConvertedValue, IsReadOnly, CanBeDeleted };
            var property = (IProperty)Activator.CreateInstance(type, args);

            return property;
        }

        /// <summary>
        /// Notifies when property changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            InitializeAction();

            var isEnabled = true;

            if (e.PropertyName == "Name" || e.PropertyName == "Value")
            {
                if (string.IsNullOrEmpty(Name))
                {
                    isEnabled = false;
                }

                if (ConvertedValue == null)
                {
                    isEnabled = false;
                }

                if (_action == null) return;

                _action.IsEnabled = isEnabled;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeAction()
        {
            if (_action != null) return;
            if (Actions == null) return;

            foreach (var action in Actions)
            {
                if (action.Caption == "Save")
                {
                    _action = action;
                }
            }
        }

        /// <summary>
        /// Converts object to current type.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="input">Input.</param>
        /// <returns>Converted object.</returns>
        private T ConvertObject<T>(object input)
        {
            return (T)Convert.ChangeType(input, typeof(T));
        }
    }
}