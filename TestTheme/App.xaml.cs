using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TestTheme
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        public static void MyThemeChange(string newTheme)
        {
            // определяем путь к файлу ресурсов
            var uri = new Uri("Theme\\" + newTheme + ".xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            // сохраняем настройку
            //Properties.Settings.Default.ThemeSettings = newTheme;
            //Properties.Settings.Default.Save();
            //Properties.Settings.Default.Reload();
        }
    }
}
