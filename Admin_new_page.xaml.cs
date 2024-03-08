using Newssify;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Newsify
{
    /// <summary>
    /// Interaction logic for Admin_new_page.xaml
    /// </summary>
    public partial class Admin_new_page : Window
    {
        News new_data;
        BitmapImage new_photo;
        MemoryStream new_photo_ms;
        Admin admin;
        public Admin_new_page(string id , Admin a)
        {
            InitializeComponent();
            admin = a;
            new_data = News.get_new(id);
            new_photo = new BitmapImage();
            new_photo_ms = new MemoryStream(new_data.get_photo());
            new_photo_ms.Position = 0;
            new_photo.BeginInit();
            new_photo.CacheOption = BitmapCacheOption.OnLoad;
            new_photo.StreamSource = new_photo_ms;
            new_photo.EndInit();

            news_title_lb.Content = new_data.get_title();
            rate_lb.Content = new_data.get_rate().ToString() + "/5";
            new_description_lb.Text = new_data.get_description();
            author_name.Content = new_data.get_author();
            news_img.Source = new_photo;

        }

        private void home_tb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var x = new Adminn(admin);
            x.Show();
            this.Close();
        }
    }
}
