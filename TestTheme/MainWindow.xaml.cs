using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestTheme
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Thread thread = new Thread(AutoChangerFun);
		static bool b = false;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void FirstResurs_Click(object sender, RoutedEventArgs e)
		{
			App.MyThemeChange("Dictionary1");
		}

		private void SecondResurs_Click(object sender, RoutedEventArgs e)
		{
			App.MyThemeChange("Dictionary2");
		}

		private void MyResurs_Click(object sender, RoutedEventArgs e)
		{
			App.MyThemeChange("MyDictionary");
		}

		private void AutoChanger_Click(object sender, RoutedEventArgs e)
		{
			thread.Start();
		}

		private static void AutoChangerFun()
		{
			string[] arr = { "Dictionary1", "Dictionary2" };
			int i = 0;
			int c = 0;
			while (b)
			{
				if (i >= arr.Length)
				{
					i = 0;
				}
				App.MyThemeChange(arr[i]);
				c++;
				//Trace.WriteLine(c);
				i++;
			}
		}

		private void AutoChangerStop_Click(object sender, RoutedEventArgs e)
		{
			thread.Abort();
		}

		private void SaveColor_Click(object sender, RoutedEventArgs e)
		{
			BrushConverter brushConverter = new BrushConverter();
			Brush brush = (Brush)brushConverter.ConvertFromString("#ffffffff");
			if(ColoreTB.Text.Length == 9)
			{
				brush = (Brush)brushConverter.ConvertFromString(ColoreTB.Text);
				//CardGrid.Background = brush;
			}
			Trace.WriteLine(FindResource("1SCB"));
			Trace.WriteLine(Convert.ToString(App.Current.Resources.MergedDictionaries[0].Values));
			ResourceDictionary resourceDictionary = (ResourceDictionary)App.Current.Resources[0];
			App.Current.Resources["1SCB"] = brush;
			//Trace.WriteLine((resourceDictionary.FindName("1SCB")) as SolidColorBrush);
			//App.Current.FindResource("1SCB") = (SolidColorBrush)brush;
		}
	}
}
