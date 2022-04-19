using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;

namespace TaskGenerator
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        private ThemeWatcher themeWatcher;
        private WindowsTheme systrayTheme = WindowsTheme.Light;
        public static EventHandler<ThemeChangedArgument> WindowsThemeChanged;

        protected override void OnLoadCompleted(NavigationEventArgs e)
        {
            base.OnLoadCompleted(e);

            Resources.MergedDictionaries[0].Source = new Uri($"/Styles/ColorsDark.xaml", UriKind.Relative);
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            themeWatcher = new ThemeWatcher();
            systrayTheme = themeWatcher.GetWindowsTheme();
            themeWatcher.StartThemeWatching();

            if (WindowsThemeChanged != null)
            {
                WindowsThemeChanged -= OnWindowsThemeChanged;
            }

            WindowsThemeChanged += OnWindowsThemeChanged;
        }

        private void OnWindowsThemeChanged(object sender, ThemeChangedArgument e)
        {
            systrayTheme = e.WindowsTheme;
            InvalidedMainWindow();
        }


        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            try
            {
                if (WindowsThemeChanged != null)
                {
                    WindowsThemeChanged -= OnWindowsThemeChanged;
                }
                Application.Current?.Shutdown();
                Process.GetCurrentProcess()?.Kill();
            }
            catch (Exception ex)
            {

            }
        }

        private void InvalidedMainWindow()
        {
           // Resources.MergedDictionaries[0].Source = new Uri($"/Styles/ColorsDark.xaml", UriKind.Relative);
            App.Current.MainWindow.UpdateLayout();
            ((MainWindow)(App.Current.MainWindow)).generator.Background = Application.Current.Resources["BackgroundBrush"] as SolidColorBrush;
        }

    }
}
