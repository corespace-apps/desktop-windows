using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace Corespace {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window {

        private bool maximized_window = false;

        public MainWindow() {
            InitializeComponent();
        }

        protected override void OnMouseLeftButtonDown( MouseButtonEventArgs e ) {
            base.OnMouseLeftButtonDown(e);

            Point pt = e.GetPosition(topBar);

            Debug.WriteLine(pt.Y);

            if (pt.Y < topBar.ActualHeight) {
                DragMove();
            }
        }

        private void resize_application_Click( object sender, RoutedEventArgs e ) {
            if (maximized_window) {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
                resize_application_icon.Source = new BitmapImage(new Uri("/Resource/Icons/fullscreen_icon.png", UriKind.Relative));
                maximized_window = false;
            } else {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
                resize_application_icon.Source = new BitmapImage(new Uri("/Resource/Icons/minimize_icon.png", UriKind.Relative));
                maximized_window = true;
            }
        }

        private void close_application_Click( object sender, RoutedEventArgs e ) {
            Close();
        }

        private void Window_SizeChanged( object sender, SizeChangedEventArgs e ) {
            if (this.WindowState == WindowState.Maximized) {
                this.BorderThickness = new System.Windows.Thickness(8);
                resize_application_icon.Source = new BitmapImage(new Uri("/Resource/Icons/minimize_icon.png", UriKind.Relative));
                maximized_window = true;
            } else {
                this.BorderThickness = new System.Windows.Thickness(0);
            }
        }
    }
}
