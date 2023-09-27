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

namespace PROG7312_AthenaeumGuru_ST10082074.Pages
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Window
    {
        private ReOrderBooks reOrderB;

        public StartPage()
        {
            InitializeComponent();
            reOrderB = new ReOrderBooks();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ReOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            reOrderB.Show();
            this.Close();
        }
    }
}
