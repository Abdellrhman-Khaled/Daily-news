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

namespace Newsify
{
    /// <summary>
    /// Interaction logic for About_us.xaml
    /// </summary>
    public partial class About_us : Window
    {
        User user;
        public About_us(User u)
        {
            user = u;
            
            InitializeComponent();
        }
        private void Hyperlink_RequestNavigate_s(object sender, RequestNavigateEventArgs e)

        {

            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));

            e.Handled = true;

        }

        private void home_tb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var x = new Daily_News(user);
            x.Show();
            this.Close();
        }
    }
}
