using System;
using System.Collections.Generic;
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

namespace ProgPartOne
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }
        private void ReplBookText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            next();
        }

        private void idAreaText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            area();
        }

        private void findNumText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            unavailable();
        }

        private void ReplBookImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            next();
        }

        private void idAreaImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            area();
        }

        private void findNumImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            unavailable();
        }

        private void unavailable()
        {
            //unavailable message
            MessageBox.Show("This feature is not available yet... Coming Soon!!!", "Unavailable", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void next() // method to move to next page
        {
            MainWindow mw = new MainWindow();
            mw.Show();

            // Close the current window (MainWindow)
            this.Close();
        }

        private void area()
        {
            Area area = new Area();
            area.Show();
            this.Close();
        }

        private void exitImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
