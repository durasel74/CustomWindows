using System;
using System.Windows;
using System.Windows.Media;

// You need to replace the namespace with your own
namespace CustomStandart
{
	public partial class MainWindow : Window
	{
		// This method must be called after InitializeComponent()
		#region Initialize CustomWindow
		public void InitializeCustomWindow()
		{
			this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
			this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
			this.Deactivated += DeactivatedWindowEffects;
			this.Activated += ActivatedWindowEffects;
			this.StateChanged += CaptionHeightChanged;
		}
		#endregion

		#region Control buttons
		public void ExitClick(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
		public void MaximizedClick(object sender, RoutedEventArgs e)
		{
			if (this.WindowState == WindowState.Normal)
				this.WindowState = WindowState.Maximized;
			else
				this.WindowState = WindowState.Normal;
		}
		public void HideClick(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}
		#endregion

		#region Window effects
		public void DeactivatedWindowEffects(object sender, EventArgs e)
		{
			this.BorderBrush = Brushes.Transparent;
			this.Foreground = (Brush)FindResource("DeactiveTitleFontColor");
		}
		public void ActivatedWindowEffects(object sender, EventArgs e)
		{
			this.BorderBrush = Brushes.Black;
			this.Foreground = (Brush)FindResource("WindowTitleFontColor");
		}
		public void CaptionHeightChanged(object sender, EventArgs e)
		{
			if (this.WindowState == WindowState.Maximized)
				this.Resources["ResizeBorderThickness"] =
					(Thickness)FindResource("ResizeBorderThicknessMaximize");
			else
				this.Resources["ResizeBorderThickness"] =
					(Thickness)FindResource("ResizeBorderThicknessNormal");
		}
		#endregion
	}
}
