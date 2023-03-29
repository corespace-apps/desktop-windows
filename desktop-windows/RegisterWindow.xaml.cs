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
using System.Windows.Shapes;

namespace Corespace {
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window {

        private bool maximized_window = false;

        public RegisterWindow() {
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
                maximized_window = false;
            } else {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
                maximized_window = true;
            }
        }

        private void close_application_Click( object sender, RoutedEventArgs e ) {
            Close();
        }

        private void Window_SizeChanged( object sender, SizeChangedEventArgs e ) {
            if (this.WindowState == WindowState.Maximized) {
                this.BorderThickness = new System.Windows.Thickness(8);
            } else {
                this.BorderThickness = new System.Windows.Thickness(0);
            }
        }
    }
}
