using Microsoft.Win32;
using System;
using System.Globalization;
using System.Management;
using System.Security.Principal;
using System.Windows;
using TaskGenerator;

public enum WindowsTheme
{
    Default = 0,
    Light = 1,
    Dark = 2,
    HighContrast = 3
}

public class ThemeChangedArgument
{
    public WindowsTheme WindowsTheme { set; get; }
}

public class ThemeWatcher
{
    private const string RegistryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";

    private const string RegistryValueName = "AppsUseLightTheme";
    private static WindowsTheme windowsTheme;

    public WindowsTheme WindowsTheme
    {
        get { return windowsTheme; }
        set { windowsTheme = value; }
    }

    public void StartThemeWatching()
    {
        var currentUser = WindowsIdentity.GetCurrent();
        string query = string.Format(
            CultureInfo.InvariantCulture,
            @"SELECT * FROM RegistryValueChangeEvent WHERE Hive = 'HKEY_USERS' AND KeyPath = '{0}\\{1}' AND ValueName = '{2}'",
            currentUser.User.Value,
            RegistryKeyPath.Replace(@"\", @"\\"),
            RegistryValueName);

        try
        {
            windowsTheme = GetWindowsTheme();
            MergeThemeDictionaries(windowsTheme);

            var watcher = new ManagementEventWatcher(query);
            watcher.EventArrived += Watcher_EventArrived;
            SystemParameters.StaticPropertyChanged += SystemParameters_StaticPropertyChanged;
            // Start listening for events
            watcher.Start();
        }
        catch (Exception ex)
        {
            // This can fail on Windows 7
            windowsTheme = WindowsTheme.Default;

        }

    }

    private void MergeThemeDictionaries(WindowsTheme windowsTheme)
    {
        string appTheme = "Light";
        switch (windowsTheme)
        {
            case WindowsTheme.Light:
                appTheme = "Light";
                break;
            case WindowsTheme.Dark:
                appTheme = "Dark";
                break;
            case WindowsTheme.HighContrast:
                appTheme = "Dark";
                break;
        }

        App.Current.Resources.MergedDictionaries[0].Source = new Uri($"/Styles/Colors{appTheme}.xaml", UriKind.Relative);

    }

    private void SystemParameters_StaticPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        windowsTheme = GetWindowsTheme();

        MergeThemeDictionaries(windowsTheme);

        ThemeChangedArgument themeChangedArgument = new ThemeChangedArgument();
        themeChangedArgument.WindowsTheme = windowsTheme;

        App.WindowsThemeChanged?.Invoke(this, themeChangedArgument);

    }

    private void Watcher_EventArrived(object sender, EventArrivedEventArgs e)
    {
        windowsTheme = GetWindowsTheme();

        MergeThemeDictionaries(windowsTheme);

        ThemeChangedArgument themeChangedArgument = new ThemeChangedArgument();
        themeChangedArgument.WindowsTheme = windowsTheme;

        App.WindowsThemeChanged?.Invoke(this, themeChangedArgument);

    }

    public WindowsTheme GetWindowsTheme()
    {
        WindowsTheme theme = WindowsTheme.Light;

        try
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
            {
                object registryValueObject = key?.GetValue(RegistryValueName);
                if (registryValueObject == null)
                {
                    return WindowsTheme.Light;
                }

                int registryValue = (int)registryValueObject;

                if (SystemParameters.HighContrast)
                    theme = WindowsTheme.HighContrast;

                theme = registryValue > 0 ? WindowsTheme.Light : WindowsTheme.Dark;
            }

            return theme;
        }
        catch (Exception ex)
        {
            return theme;
        }
    }
}