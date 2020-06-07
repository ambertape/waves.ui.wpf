﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Composition;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Core.Base.Interfaces;
using Waves.UI.WPF.Base;
using Microsoft.Win32;
using Waves.UI.Base.Interfaces;
using Waves.UI.Services.Interfaces;
using Application = System.Windows.Application;

namespace Waves.UI.WPF.Services
{
    /// <summary>
    ///     Windows UI theme service.
    /// </summary>
    [Export(typeof(IService))]
    public class ThemeService : Waves.Core.Base.Service, IThemeService
    {
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    

        //    

        //    

        //    private bool _isSystemUsingDarkTheme;
        //    
        //    
        //    

        //    

        //    private ITheme _selectedTheme;
        //    
        //    private bool _useAutomaticScheme = true;

        //    /// <inheritdoc />
        //    public override Guid Id { get; } 

        //    /// <inheritdoc />
        //    public override string Name { get; set; } 

        //    /// <inheritdoc />
        //    public bool UseDarkScheme { get; set; }

        //    /// <inheritdoc />
        //    public bool UseAutomaticScheme
        //    {
        //        get => _useAutomaticScheme;
        //        set
        //        {
        //            _useAutomaticScheme = value;

        //            if (value)
        //                InitializeSystemThemeCheckerDaemon();
        //        }
        //    }

        //    /// <inheritdoc />
        //    public ITheme SelectedTheme
        //    {
        //        get => _selectedTheme;
        //        set
        //        {
        //            if (value == _selectedTheme) return;
        //            _selectedTheme = value;
        //            OnPropertyChanged();
        //            

        //            
        //        }
        //    }

        //    /// <inheritdoc />
        //    public ObservableCollection<ITheme> Themes { get; } = new ObservableCollection<ITheme>();

        //    /// <inheritdoc />
        //    public event EventHandler ThemeChanged;

        //    /// <inheritdoc />
        //   
        //   
        //   

        //   
        //   

        //   
        //   
        //   

        //    /// <inheritdoc />
        //    public override void Initialize()
        //    {
        //        

        //        
        //        

        //        
        //        

        //        
        //    }

        //    /// <inheritdoc />
        //    public override void LoadConfiguration(IConfiguration configuration)
        //    {
        //        
        //        
        //        
        //        
        //        
        //        
        //        
        //        
        //        
        //        
        //    }

        //    /// <inheritdoc />
        //    public override void SaveConfiguration(IConfiguration configuration)
        //    {
        //        
        //        
        //        
        //        
        //        
        //        
        //        
        //        
        //        
        //        
        //    }

        //    /// <inheritdoc />
        //    public override void Dispose()
        //    {
        //        // 
        //    }

        //    /// <summary>
        //    ///     Initializes system theme checker daemon.
        //    /// </summary>
        //    private void InitializeSystemThemeCheckerDaemon()
        //    {
        //        if (!UseAutomaticScheme) return;

        //        Task.Run(async delegate
        //        {
        //            do
        //            {
        //                try
        //                {
        //                    var value = (int) Registry.GetValue(
        //                        @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize",
        //                        "AppsUseLightTheme", "1");

        //                    _isSystemUsingDarkTheme = value != 1;

        //                    await Task.Delay(2500).ConfigureAwait(false);

        //                    if (!UseAutomaticScheme)
        //                        break;

        //                    if (_isSystemUsingDarkTheme && SelectedTheme.IsDark) continue;
        //                    if (!_isSystemUsingDarkTheme && !SelectedTheme.IsDark) continue;

        //                    _application.Dispatcher.Invoke(delegate
        //                    {
        //                        foreach (var theme in Themes)
        //                            if (_isSystemUsingDarkTheme)
        //                            {
        //                                if (theme.IsDark)
        //                                {
        //                                    SelectedTheme = theme;
        //                                    return;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                if (!theme.IsDark)
        //                                {
        //                                    SelectedTheme = theme;
        //                                    return;
        //                                }
        //                            }
        //                    });
        //                }
        //                catch (Exception e)
        //                {
        //                    OnMessageReceived(this,
        //                        new Message("Theme Service", "Error checking system theme:\r\n" + e, Name,
        //                            MessageType.Error));
        //                }
        //            } while (UseAutomaticScheme);
        //        });
        //    }

        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    

        //    /// <summary>
        //    ///     Initializes themes.
        //    /// </summary>
        //    private void InitializeThemes()
        //    {
        //        
        //        
        //        
        //        
        //        
        //        
        //        
        //        
        //        
        //        
        //    }

        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    

        //    /// <summary>
        //    ///     Initializes base themes.
        //    /// </summary>
        //    private void InitializeBaseThemes()
        //    {
        //        try
        //        {
        //            CreateSystemAccentDictionary();
        //        }
        //        catch (Exception e)
        //        {
        //            OnMessageReceived(this,
        //                new Message("Theme Service", "Error initializing system accent theme:\r\n" + e, Name, MessageType.Error));
        //        }

        //        try
        //        { 
        //            Themes.Add(new Theme("Dark / System accent", Guid.Parse("842FB00F-1B3B-4FE1-BB47-EC80BF99B623"),
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },

        //                _systemAccentResourceDictionary,

        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                true));

        //            Themes.Add(new Theme("Dark / Blue", Guid.Parse("39834D2D-42D3-4440-9109-F1C1175ECE22"),
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(AccentBlueColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                true));

        //            Themes.Add(new Theme("Dark / Green", Guid.Parse("B0976F22-9812-4CD4-9A48-D50C89751FE8"),
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(AccentGreenColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                true));

        //            Themes.Add(new Theme("Dark / Red", Guid.Parse("77C4FC42-C9AC-435A-9FA6-16208CA94FA9"),
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(AccentRedColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                true));

        //            Themes.Add(new Theme("Dark / Yellow", Guid.Parse("56A2C1ED-6F69-45A9-AE3E-972A77340CAF"),
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(AccentYellowColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                true));

        //            Themes.Add(new Theme("Black / White", Guid.Parse("ADDCB340-5E01-4974-9A5F-7EEA0C013AF9"),
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(AccentWhiteColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                true));

        //            Themes.Add(new Theme("Light / System accent", Guid.Parse("B7369E9A-A2BB-4E63-9474-F26259C0DEF7"),
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },

        //                _systemAccentResourceDictionary,

        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                false));

        //            Themes.Add(new Theme("Light / Blue", Guid.Parse("27D324B4-3279-481C-899B-153A60BAC3D0"),
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(AccentBlueColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                false));

        //            Themes.Add(new Theme("Light / Green", Guid.Parse("C8AD5DCD-5E81-41C1-A18F-4C5DEA11B800"),
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(AccentGreenColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                false));

        //            Themes.Add(new Theme("Light / Red", Guid.Parse("D7E3FCC7-6375-4994-ABE9-266CEA4DD576"),
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(AccentRedColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                false));

        //            Themes.Add(new Theme("Light / Yellow", Guid.Parse("B42FC3FE-8022-4D0D-8D02-86540BD68862"),
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(AccentYellowColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                false));

        //            Themes.Add(new Theme("White / Black", Guid.Parse("E14927EB-6231-4C31-8FFE-7CFA6DF713FE"),
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(AccentBlackColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                new ResourceDictionary
        //                {
        //                    Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //                },
        //                false));

        //            OnMessageReceived(this,
        //                new Message("Initialization", "Base themes initialized.", Name, MessageType.Information));
        //        }
        //        catch (Exception e)
        //        {
        //            OnMessageReceived(this,
        //                new Message("Theme Service", "Error initializing base themes:\r\n" + e, Name, MessageType.Error));
        //        }
        //    }

        //    /// <summary>
        //    /// Creates system accent resource dictionary.
        //    /// </summary>
        //    private void CreateSystemAccentDictionary()
        //    {
        //        var accent = SystemParameters.WindowGlassBrush as SolidColorBrush;
        //        if (accent == null) return;

        //        var accentColor = accent.Color;

        //        _systemAccentResourceDictionary = new ResourceDictionary();

        //        for (var i = 500; i > 0; i -= 100)
        //        {
        //            var color = GetColor(accentColor, i / 500.0f);

        //            _systemAccentResourceDictionary.Add("Accent-Color-" + i, color);
        //            _systemAccentResourceDictionary.Add("Accent-" + i + "-Brush", new SolidColorBrush(color));
        //        }

        //        for (var i = 600; i < 1000; i += 100)
        //        {
        //            var color = GetColor(accentColor, i / 500.0f);

        //            _systemAccentResourceDictionary.Add("Accent-Color-" + i, color);
        //            _systemAccentResourceDictionary.Add("Accent-" + i + "-Brush", new SolidColorBrush(color));
        //        }

        //        var luminance = (0.299 * accentColor.R + 0.587 * accentColor.G + 0.114 * accentColor.B) / 255;

        //        ResourceDictionary resourceDictionary;

        //        if (luminance > 0.5)
        //        {
        //            resourceDictionary = new ResourceDictionary()
        //            {
        //                Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //            };
        //        }
        //        else
        //        {
        //            resourceDictionary = new ResourceDictionary()
        //            {
        //                Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
        //            };
        //        }

        //        for (var i = 100; i < 1000; i += 400)
        //        {
        //            var colorKey = "Color-Foreground-" + i;
        //            var brushKey = "Primary-Foreground-" + i + "-Brush";

        //            var color = (System.Windows.Media.Color)resourceDictionary[colorKey];

        //            _systemAccentResourceDictionary.Add("Accent-Color-Foreground-" + i, color);
        //            _systemAccentResourceDictionary.Add("Accent-Foreground-" + i + "-Brush", new SolidColorBrush(color));
        //        }
        //    }

        //    
        //    
        //    
        //    
        //    
        //    

        //    
        //    
        //    

        //    

        //    
        //    
        //    
        //    
        //    
        //    

        //    
        //    
        //    

        //    
        //    
        //    

        //    

        //    ;
        //    
        //    
        //    
        //    
        //    
        //    
        //    

        //    /// <summary>
        //    /// Gets color by brightness index.
        //    /// </summary>
        //    /// <param name="color">Original color.</param>
        //    /// <param name="index">Brightness index.</param>
        //    /// <returns>Color.</returns>
        //    private static System.Windows.Media.Color GetColor(System.Windows.Media.Color color, float index)
        //    {
        //        var a = (float)255;
        //        var r = color.R * index;
        //        var g = color.G * index;
        //        var b = color.B * index;

        //        if (a > 255) a = 255;
        //        if (a < 0) a = 0;

        //        if (r > 255) r = 255;
        //        if (r < 0) r = 0;

        //        if (g > 255) g = 255;
        //        if (g < 0) g = 0;

        //        if (b > 255) b = 255;
        //        if (b < 0) b = 0;

        //        var ab = (byte)a;
        //        var rb = (byte)r;
        //        var gb = (byte)g;
        //        var bb = (byte)b;

        //        return System.Windows.Media.Color.FromArgb(ab, rb, gb, bb);
        //    }
        //}

        private const string PrimaryLightColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Primary.Light.xaml";
        private const string PrimaryDarkColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Primary.Dark.xaml";
        private const string AccentWhiteColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Accent.White.xaml";
        private const string AccentBlackColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Accent.Haiti.xaml";
        private const string AccentBlueColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Accent.Picton.Blue.xaml";
        private const string AccentGreenColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Accent.Jade.xaml";
        private const string AccentRedColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Accent.Sunset.Orange.xaml";
        private const string AccentYellowColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Accent.Ronchi.xaml";
        private const string AccentTemplateDictionaryUri = "/Waves.UI.WPF;component/Colors/Accent.Template.xaml";
        private const string MiscellaneousColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Miscellaneous.Classic.xaml";

        private readonly object _themesCollectionLocker = new object();

        private bool _useDarkScheme = false;

        private ResourceDictionary _oldPrimaryResourceDictionary;
        private ResourceDictionary _oldAccentResourceDictionary;
        private ResourceDictionary _oldMiscellaneousResourceDictionary;

        private Guid _selectedThemeId = Guid.Empty;

        private ITheme _selectedTheme;

        private Application _application;
        
        /// <inheritdoc />
        public event EventHandler ThemeChanged;

        /// <inheritdoc />
        public override Guid Id { get; } = Guid.Parse("61482A15-667C-4993-AEAE-4F19A62C17B8");

        /// <inheritdoc />
        public override string Name { get; set; } = "WPF UI Theme Service";

        /// <inheritdoc />
        public bool UseDarkScheme
        {
            get => _useDarkScheme;
            set
            {
                if (_useDarkScheme.Equals(value)) return;

                _useDarkScheme = value;

                UpdateTheme();

                OnThemeChanged();

                OnPropertyChanged();
            }
        }

        /// <inheritdoc />
        public bool UseAutomaticScheme { get; set; } = true;

        /// <inheritdoc />
        public ITheme SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                if (value == null) return;

                if (value.Equals(_selectedTheme)) return;

                var useDarkSet = false;
                if (_selectedTheme != null)
                    useDarkSet = _selectedTheme.UseDarkSet;

                _selectedTheme = value;

                _selectedThemeId = _selectedTheme.Id;

                _selectedTheme.UseDarkSet = useDarkSet;

                UpdateTheme();

                OnThemeChanged();

                OnPropertyChanged();
            }
        }

        /// <inheritdoc />
        public ObservableCollection<ITheme> Themes { get; private set; } = new ObservableCollection<ITheme>();

        /// <summary>
        /// Attaches application.
        /// </summary>
        /// <param name="application">Application.</param>
        public void AttachApplication(Application application)
        {
            _application = application;

            InitializeSelectedTheme();
            //InitializeSystemThemeCheckerDaemon();

            OnMessageReceived(this,
                new Message("Initialization", "Application attached - " + application, Name, MessageType.Information));
        }

        /// <inheritdoc />
        public override void Initialize()
        {
            if (IsInitialized) return;

            InitializeCollectionSynchronization();
            InitializeThemes();

            OnMessageReceived(this,
                new Message("Initialization", "Service was initialized.", Name, MessageType.Information));

            IsInitialized = true;
        }

        /// <inheritdoc />
        public override void LoadConfiguration(IConfiguration configuration)
        {
            try
            {
                _selectedThemeId = LoadConfigurationValue(configuration, "ThemesService-SelectedThemeId", Guid.Empty);
                UseAutomaticScheme = LoadConfigurationValue(configuration, "ThemesService-UseAutomaticScheme", false);
                UseDarkScheme = LoadConfigurationValue(configuration, "ThemesService-UseDarkScheme", false);
            }
            catch (Exception e)
            {
                OnMessageReceived(this,
                    new Message("Theme Service", "Error loading configuration:\r\n" + e, Name, MessageType.Error));
            }
        }

        /// <inheritdoc />
        public override void SaveConfiguration(IConfiguration configuration)
        {
            try
            {
                configuration.SetPropertyValue("ThemesService-SelectedThemeId", _selectedThemeId);
                configuration.SetPropertyValue("ThemesService-UseAutomaticScheme", UseAutomaticScheme);
                configuration.SetPropertyValue("ThemesService-UseDarkScheme", UseDarkScheme);
            }
            catch (Exception e)
            {
                OnMessageReceived(this,
                    new Message("Theme Service", "Error saving configuration:\r\n" + e, Name, MessageType.Error));
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            Themes.Clear();
        }

        /// <summary>
        /// Notifies when theme changed.
        /// </summary>
        protected virtual void OnThemeChanged()
        {
            ThemeChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///     Initializes collection synchronization.S
        /// </summary>
        private void InitializeCollectionSynchronization()
        {
            try
            {
                BindingOperations.EnableCollectionSynchronization(Themes, _themesCollectionLocker);
            }
            catch (Exception e)
            {
                OnMessageReceived(this,
                    new Message("Theme Service", "Error enabling collection synchronization:\r\n" + e, Name,
                        MessageType.Error));
            }
        }

        /// <summary>
        /// Initializes themes.
        /// </summary>
        private void InitializeThemes()
        {
            try
            {
                Themes.Clear();

                InitializeBaseThemes();

                if (Themes.Count == 0)
                    throw new Exception("Themes were not loaded.");
            }
            catch (Exception e)
            {
                OnMessageReceived(this,
                    new Message("Theme Service", "Error initializing base themes:\r\n" + e, Name, MessageType.Error));
            }
        }

        /// <summary>
        /// Initializes base themes.
        /// </summary>
        private void InitializeBaseThemes()
        {
            var lightPrimaryColorsResourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
            };

            var darkPrimaryColorsResourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
            };

            var accentGreenColorsResourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(AccentGreenColorsDictionaryUri, UriKind.RelativeOrAbsolute)
            };

            var accentBlueColorsResourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(AccentBlueColorsDictionaryUri, UriKind.RelativeOrAbsolute)
            };

            var accentRedColorsResourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(AccentRedColorsDictionaryUri, UriKind.RelativeOrAbsolute)
            };

            var accentYellowColorsResourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(AccentYellowColorsDictionaryUri, UriKind.RelativeOrAbsolute)
            };

            var miscellaneousColorsResourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
            };

            var primaryLightColorName = (string)lightPrimaryColorsResourceDictionary["ColorSetName"];
            var primaryDarkColorName = (string)darkPrimaryColorsResourceDictionary["ColorSetName"];
            var accentGreenColorName = (string)accentGreenColorsResourceDictionary["ColorSetName"];
            var accentBlueColorName = (string)accentBlueColorsResourceDictionary["ColorSetName"];
            var accentRedColorName = (string)accentRedColorsResourceDictionary["ColorSetName"];
            var accentYellowColorName = (string)accentYellowColorsResourceDictionary["ColorSetName"];
            var miscellaneousColorName = (string)miscellaneousColorsResourceDictionary["ColorSetName"];

            var primaryLightColorSetId = Guid.Parse((string)lightPrimaryColorsResourceDictionary["ColorSetId"]);
            var primaryDarkColorSetId = Guid.Parse((string)darkPrimaryColorsResourceDictionary["ColorSetId"]);
            var accentGreenColorSetId = Guid.Parse((string)accentGreenColorsResourceDictionary["ColorSetId"]);
            var accentBlueColorSetId = Guid.Parse((string)accentBlueColorsResourceDictionary["ColorSetId"]);
            var accentRedColorSetId = Guid.Parse((string)accentRedColorsResourceDictionary["ColorSetId"]);
            var accentYellowColorSetId = Guid.Parse((string)accentYellowColorsResourceDictionary["ColorSetId"]);
            var miscellaneousColorSetId = Guid.Parse((string)miscellaneousColorsResourceDictionary["ColorSetId"]);

                var lightPrimaryColorSet = new PrimaryColorSet(primaryLightColorSetId,
                primaryLightColorName,
                lightPrimaryColorsResourceDictionary);

            var darkPrimaryColorSet = new PrimaryColorSet(primaryDarkColorSetId,
                primaryDarkColorName,
                darkPrimaryColorsResourceDictionary);

            var greenAccentColorSet = new AccentColorSet(accentGreenColorSetId,
                accentGreenColorName,
                accentGreenColorsResourceDictionary);

            var blueAccentColorSet = new AccentColorSet(accentBlueColorSetId,
                accentBlueColorName,
                accentBlueColorsResourceDictionary);

            var redAccentColorSet = new AccentColorSet(accentRedColorSetId,
                accentRedColorName,
                accentRedColorsResourceDictionary);

            var yellowAccentColorSet = new AccentColorSet(accentYellowColorSetId,
                accentYellowColorName,
                accentYellowColorsResourceDictionary);

            var miscellaneousColorSet = new MiscellaneousColorSet(miscellaneousColorSetId,
                miscellaneousColorName,
                miscellaneousColorsResourceDictionary);

            Themes.Add(new Theme(
                Guid.Parse("12E87107-C2FC-4D68-908C-377B80A4056A"),
                accentGreenColorName,
                lightPrimaryColorSet,
                darkPrimaryColorSet,
                greenAccentColorSet,
                miscellaneousColorSet));

            Themes.Add(new Theme(
                Guid.Parse("2549DD92-C094-4EF5-B50D-0DD187DFE154"),
                accentBlueColorName,
                lightPrimaryColorSet,
                darkPrimaryColorSet,
                blueAccentColorSet,
                miscellaneousColorSet));

            Themes.Add(new Theme(
                Guid.Parse("07B33F24-141B-4D9A-9C3A-946B0FC6BC82"),
                accentRedColorName,
                lightPrimaryColorSet,
                darkPrimaryColorSet,
                redAccentColorSet,
                miscellaneousColorSet));

            Themes.Add(new Theme(
                Guid.Parse("4F7E14EA-B219-40C6-8870-D9D080756D15"),
                accentYellowColorName,
                lightPrimaryColorSet,
                darkPrimaryColorSet,
                yellowAccentColorSet,
                miscellaneousColorSet));

            foreach (var theme in Themes)
            {
                theme.PrimaryColorSetChanged += OnThemePrimaryColorSetChanged;
            }
        }

        /// <summary>
        /// Actions when theme's primary color set changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnThemePrimaryColorSetChanged(object sender, EventArgs e)
        {
            UpdateTheme();

            UseDarkScheme = SelectedTheme.UseDarkSet;
        }

        /// <summary>
        ///     Updates theme.
        /// </summary>
        private void UpdateTheme()
        {
            if (_application == null) return;

            try
            {
                var dictionaries = _application.Resources.MergedDictionaries;

                _application.Resources.BeginInit();

                if (dictionaries.Count > 1)
                {
                    dictionaries.Remove(_oldPrimaryResourceDictionary);
                    dictionaries.Remove(_oldAccentResourceDictionary);
                    dictionaries.Remove(_oldMiscellaneousResourceDictionary);
                }

                var primaryColorSet = SelectedTheme.PrimaryColorSet as PrimaryColorSet;
                if (primaryColorSet == null) return;

                var accentColorSet = SelectedTheme.AccentColorSet as AccentColorSet;
                if (accentColorSet == null) return;

                var miscellaneousColorSet = SelectedTheme.MiscellaneousColorSet as MiscellaneousColorSet;
                if (miscellaneousColorSet == null) return;

                dictionaries.Add(primaryColorSet.ResourceDictionary);
                dictionaries.Add(accentColorSet.ResourceDictionary);
                dictionaries.Add(miscellaneousColorSet.ResourceDictionary);

                _oldPrimaryResourceDictionary = primaryColorSet.ResourceDictionary;
                _oldAccentResourceDictionary = accentColorSet.ResourceDictionary;
                _oldMiscellaneousResourceDictionary = miscellaneousColorSet.ResourceDictionary;

                _application.Resources.EndInit();

                OnMessageReceived(this,
                    SelectedTheme.UseDarkSet
                        ? new Message("Theme Service", "Theme changed to \"" + SelectedTheme.Name + "\" (Dark).", Name,
                            MessageType.Information)
                        : new Message("Theme Service", "Theme changed to \"" + SelectedTheme.Name + "\" (Light).", Name,
                            MessageType.Information));
            }
            catch (Exception e)
            {
                OnMessageReceived(this,
                    new Message("Theme Service", "Error updating theme:\r\n" + e, Name, MessageType.Error));
            }
        }

        /// <summary>
        ///     Initialized selected theme.
        /// </summary>
        private void InitializeSelectedTheme()
        {
            if (Themes.Count > 0)
            {
                try
                {
                    if (_selectedThemeId.Equals(Guid.Empty))
                    {
                        SelectedTheme = Themes.First();
                    }
                    else
                    {
                        foreach (var theme in Themes)
                        {
                            if (theme.Id != _selectedThemeId) continue;

                            SelectedTheme = theme;

                            SelectedTheme.UseDarkSet = UseDarkScheme;

                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    OnMessageReceived(this,
                        new Message("Theme Service", "Error initializing selected theme:\r\n" + e, Name,
                            MessageType.Error));
                }
            }
            else
            {
                OnMessageReceived(this, new Message("Theme Service", "Themes not found.", Name, MessageType.Error));
            }
        }
    }
}