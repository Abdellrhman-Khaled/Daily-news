using Microsoft.Win32;
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
    /// Interaction logic for Adminn.xaml
    /// </summary>
    public partial class Adminn : Window
    {
        BitmapImage update_news_photo;
        BitmapImage new_news_photo;
        BitmapImage user_photo;
        BitmapImage admin_photo;
        BitmapImage all_news1;
        BitmapImage all_news2;
        BitmapImage all_news3;
        BitmapImage all_news4;
        BitmapImage all_news5;
        BitmapImage all_news6;
        int news1;
        int news2;
        int news3;
        int news4;
        int news5;
        int news6;
        MemoryStream all_news1ms;
        MemoryStream all_news2ms;
        MemoryStream all_news3ms;
        MemoryStream all_news4ms;
        MemoryStream all_news5ms;
        MemoryStream all_news6ms;



        News upnew;
        Admin Ad;
        List<News> all_news = News.GetDataNewss();
        List<string> categories = News.categories;

        public Adminn(Admin a)
        {
            Ad = a;
            InitializeComponent();
            ShowAllNews_Tb.MouseLeftButtonDown += ShowAllNews_Tb_MouseLeftButtonDown;
            AddNews_Tb.MouseLeftButtonDown += AddNews_Tb_MouseLeftButtonDown;
            Addcatagory_Tb.MouseLeftButtonDown += Addcatagory_Tb_MouseLeftButtonDown;
            updateNews_Tb.MouseLeftButtonDown += UpdateNews_Tb_MouseLeftButtonDown;
            AddUser_Tb.MouseLeftButtonDown += AddUser_Tb_MouseLeftButtonDown;
            removeUser_Tb.MouseLeftButtonDown += RemoveUser_Tb_MouseLeftButtonDown;
            AddAdmin_Tb.MouseLeftButtonDown += AddAdmin_Tb_MouseLeftButtonDown;
            backHome_Tb.MouseLeftButtonDown += BackHome_Tb_MouseLeftButtonDown;
            backtosearchtoUpdate_tb.MouseLeftButtonDown += BacktosearchtoUpdate_tb_MouseLeftButtonDown;



            AdminProfileName.Text = Ad.get_fname().ToString() + " " + Ad.get_lname().ToString();
            AdminProfileEmail.Text = Ad.get_email();

            BitmapImage bitmapImage = new BitmapImage();
            MemoryStream stream = new MemoryStream(Ad.get_photo());

            bitmapImage = new BitmapImage();
            
            stream.Position = 0;
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();
            Home_profile_photSo.ImageSource = bitmapImage;

        }

        private void Addcatagory_Tb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddCatagory_panel.Visibility = Visibility.Visible;

            AddUser_panel.Visibility = Visibility.Collapsed;

            RemoveUser_panel.Visibility = Visibility.Collapsed;
            AddAdmin_panel.Visibility = Visibility.Collapsed;
            showAllNews_panel.Visibility = Visibility.Collapsed;
            AddNews_panel.Visibility = Visibility.Collapsed;
            UpdateNews_panel.Visibility = Visibility.Collapsed;


        }
        private void BacktosearchtoUpdate_tb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NEWStoUpdatepanel.Visibility = Visibility.Collapsed;
            UpdateNewsEditeBorder.Visibility = Visibility.Collapsed;
            searchstackpanel.Visibility = Visibility.Visible;

        }
        private void BackHome_Tb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var x = new MainWindow();
            x.Show();
            this.Close();
        }

        private void AddAdmin_Tb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddAdmin_panel.Visibility = Visibility.Visible;

            AddNews_panel.Visibility = Visibility.Collapsed;
            UpdateNews_panel.Visibility = Visibility.Collapsed;
            AddCatagory_panel.Visibility = Visibility.Collapsed;
            AddUser_panel.Visibility = Visibility.Collapsed;
            RemoveUser_panel.Visibility = Visibility.Collapsed;
            showAllNews_panel.Visibility = Visibility.Collapsed;
        }
        private void RemoveUser_Tb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RemoveUser_panel.Visibility = Visibility.Visible;

            UpdateNews_panel.Visibility = Visibility.Collapsed;
            AddCatagory_panel.Visibility = Visibility.Collapsed;
            AddAdmin_panel.Visibility = Visibility.Collapsed;
            showAllNews_panel.Visibility = Visibility.Collapsed;
            AddNews_panel.Visibility = Visibility.Collapsed;
            AddUser_panel.Visibility = Visibility.Collapsed;

        }

        private void AddUser_Tb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddUser_panel.Visibility = Visibility.Visible;

            RemoveUser_panel.Visibility = Visibility.Collapsed;
            AddAdmin_panel.Visibility = Visibility.Collapsed;
            showAllNews_panel.Visibility = Visibility.Collapsed;
            AddNews_panel.Visibility = Visibility.Collapsed;
            UpdateNews_panel.Visibility = Visibility.Collapsed;
            AddCatagory_panel.Visibility = Visibility.Collapsed;
        }
        private void UpdateNews_Tb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UpdateNews_panel.Visibility = Visibility.Visible;
            searchstackpanel.Visibility = Visibility.Visible;

            updatNewsEditPanel.Visibility = Visibility.Collapsed;
            AddUser_panel.Visibility = Visibility.Collapsed;
            RemoveUser_panel.Visibility = Visibility.Collapsed;
            AddAdmin_panel.Visibility = Visibility.Collapsed;
            showAllNews_panel.Visibility = Visibility.Collapsed;
            AddNews_panel.Visibility = Visibility.Collapsed;
            AddCatagory_panel.Visibility = Visibility.Collapsed;
            NEWStoUpdatepanel.Visibility = Visibility.Collapsed;
            UpdateNewsEditeBorder.Visibility = Visibility.Collapsed;

        }
        private void AddNews_Tb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddNews_panel.Visibility = Visibility.Visible;
            categories = News.categories;
            catagory_Combobox.Items.Clear();

            for (int i = 0; i < categories.Count; i++)
            {
                catagory_Combobox.Items.Add(categories[i]);
            }

            showAllNews_panel.Visibility = Visibility.Collapsed;
            UpdateNews_panel.Visibility = Visibility.Collapsed;
            AddCatagory_panel.Visibility = Visibility.Collapsed;
            AddUser_panel.Visibility = Visibility.Collapsed;
            RemoveUser_panel.Visibility = Visibility.Collapsed;
            AddAdmin_panel.Visibility = Visibility.Collapsed;
        }
        private void ShowAllNews_Tb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            showAllNews_panel.Visibility = Visibility.Visible;

            AddNews_panel.Visibility = Visibility.Collapsed;
            UpdateNews_panel.Visibility = Visibility.Collapsed;
            AddUser_panel.Visibility = Visibility.Collapsed;
            RemoveUser_panel.Visibility = Visibility.Collapsed;
            AddAdmin_panel.Visibility = Visibility.Collapsed;
            AddCatagory_panel.Visibility = Visibility.Collapsed;


        }
        private void LogOut_btn_Click(object sender, RoutedEventArgs e)
        {
            News.save_categories_to_database();
            News.save_news_to_database();
            Person.save_persons();


            var x = new MainWindow();
            x.Show();
            this.Close();
        }
        private void search_bt_Click(object sender, RoutedEventArgs e)
        {
           
            if (searchUpdatenews_txt.Text == "")
            {
                MessageBox.Show("Please Write the title");
            }
            else {
                all_news = News.GetDataNewss();
                all_news = News.Display_based_on_specific_title(all_news, searchUpdatenews_txt.Text);
                if (all_news.Count == 0)
                {
                    Updatenew1.Visibility = Visibility.Hidden;
                    Updatenew2.Visibility = Visibility.Hidden;
                    Updatenew3.Visibility = Visibility.Hidden;
                    Updatenew4.Visibility = Visibility.Hidden;
                    Updatenew5.Visibility = Visibility.Hidden;
                    Updatenew6.Visibility = Visibility.Hidden;
                    MessageBox.Show("No News With that title");

                }
                else
                {
                    NEWStoUpdatepanel.Visibility = Visibility.Visible;
                    AddCatagory_panel.Visibility = Visibility.Collapsed;
                    if (all_news.Count == 1)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        Updatenew1.Background = new ImageBrush(all_news1);
                        Updatenew1.Content = all_news[news1].get_id().ToString();
                        Updatenew1.FontSize = 0.1;

                        /////////////////////////////
                        ///
                        Updatenew1.Visibility = Visibility.Visible;
                        Updatenew2.Visibility = Visibility.Hidden;
                        Updatenew3.Visibility = Visibility.Hidden;
                        Updatenew4.Visibility = Visibility.Hidden;
                        Updatenew5.Visibility = Visibility.Hidden;
                        Updatenew6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 2)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        Updatenew1.Background = new ImageBrush(all_news1);
                        Updatenew1.Content = all_news[news1].get_id().ToString();
                        Updatenew1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        Updatenew2.Background = new ImageBrush(all_news2);
                        Updatenew2.Content = all_news[news2].get_id().ToString();
                        Updatenew2.FontSize = 0.1;

                        /////////////////////////////
                        ///
                        Updatenew1.Visibility = Visibility.Visible;
                        Updatenew2.Visibility = Visibility.Visible;

                        Updatenew3.Visibility = Visibility.Hidden;
                        Updatenew4.Visibility = Visibility.Hidden;
                        Updatenew5.Visibility = Visibility.Hidden;
                        Updatenew6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 3)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        Updatenew1.Background = new ImageBrush(all_news1);
                        Updatenew1.Content = all_news[news1].get_id().ToString();
                        Updatenew1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        Updatenew2.Background = new ImageBrush(all_news2);
                        Updatenew2.Content = all_news[news2].get_id().ToString();
                        Updatenew2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        Updatenew3.Background = new ImageBrush(all_news3);
                        Updatenew3.Content = all_news[news3].get_id().ToString();
                        Updatenew3.FontSize = 0.1;

                        /////////////////////////////
                        Updatenew1.Visibility = Visibility.Visible;
                        Updatenew2.Visibility = Visibility.Visible;
                        Updatenew3.Visibility = Visibility.Visible;

                        Updatenew4.Visibility = Visibility.Hidden;
                        Updatenew5.Visibility = Visibility.Hidden;
                        Updatenew6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 4)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        Updatenew1.Background = new ImageBrush(all_news1);
                        Updatenew1.Content = all_news[news1].get_id().ToString();
                        Updatenew1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        Updatenew2.Background = new ImageBrush(all_news2);
                        Updatenew2.Content = all_news[news2].get_id().ToString();
                        Updatenew2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        Updatenew3.Background = new ImageBrush(all_news3);
                        Updatenew3.Content = all_news[news3].get_id().ToString();
                        Updatenew3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        Updatenew4.Background = new ImageBrush(all_news4);
                        Updatenew4.Content = all_news[news4].get_id().ToString();
                        Updatenew4.FontSize = 0.1;

                        /////////////////////////////
                        Updatenew1.Visibility = Visibility.Visible;
                        Updatenew2.Visibility = Visibility.Visible;
                        Updatenew3.Visibility = Visibility.Visible;
                        Updatenew4.Visibility = Visibility.Visible;

                        Updatenew5.Visibility = Visibility.Hidden;
                        Updatenew6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 5)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        Updatenew1.Background = new ImageBrush(all_news1);
                        Updatenew1.Content = all_news[news1].get_id().ToString();
                        Updatenew1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        Updatenew2.Background = new ImageBrush(all_news2);
                        Updatenew2.Content = all_news[news2].get_id().ToString();
                        Updatenew2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        Updatenew3.Background = new ImageBrush(all_news3);
                        Updatenew3.Content = all_news[news3].get_id().ToString();
                        Updatenew3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        Updatenew4.Background = new ImageBrush(all_news4);
                        Updatenew4.Content = all_news[news4].get_id().ToString();
                        Updatenew4.FontSize = 0.1;

                        /////////////////////////////
                        news5 = 4;
                        all_news5 = new BitmapImage();
                        all_news5ms = new MemoryStream(all_news[news5].get_photo());
                        all_news5ms.Position = 0;
                        all_news5.BeginInit();
                        all_news5.CacheOption = BitmapCacheOption.OnLoad;
                        all_news5.StreamSource = all_news5ms;
                        all_news5.EndInit();
                        // set properties of news
                        Updatenew5.Background = new ImageBrush(all_news5);
                        Updatenew5.Content = all_news[news5].get_id().ToString();
                        Updatenew5.FontSize = 0.1;

                        /////////////////////////////
                        Updatenew1.Visibility = Visibility.Visible;
                        Updatenew2.Visibility = Visibility.Visible;
                        Updatenew3.Visibility = Visibility.Visible;
                        Updatenew4.Visibility = Visibility.Visible;
                        Updatenew5.Visibility = Visibility.Visible;

                        Updatenew6.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        Updatenew1.Background = new ImageBrush(all_news1);
                        Updatenew1.Content = all_news[news1].get_id().ToString();
                        Updatenew1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        Updatenew2.Background = new ImageBrush(all_news2);
                        Updatenew2.Content = all_news[news2].get_id().ToString();
                        Updatenew2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        Updatenew3.Background = new ImageBrush(all_news3);
                        Updatenew3.Content = all_news[news3].get_id().ToString();
                        Updatenew3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        Updatenew4.Background = new ImageBrush(all_news4);
                        Updatenew4.Content = all_news[news4].get_id().ToString();
                        Updatenew4.FontSize = 0.1;

                        /////////////////////////////
                        news5 = 4;
                        all_news5 = new BitmapImage();
                        all_news5ms = new MemoryStream(all_news[news5].get_photo());
                        all_news5ms.Position = 0;
                        all_news5.BeginInit();
                        all_news5.CacheOption = BitmapCacheOption.OnLoad;
                        all_news5.StreamSource = all_news5ms;
                        all_news5.EndInit();
                        // set properties of news
                        Updatenew5.Background = new ImageBrush(all_news5);
                        Updatenew5.Content = all_news[news5].get_id().ToString();
                        Updatenew5.FontSize = 0.1;

                        /////////////////////////////
                        news6 = 5;
                        all_news6 = new BitmapImage();
                        all_news6ms = new MemoryStream(all_news[news6].get_photo());
                        all_news6ms.Position = 0;
                        all_news6.BeginInit();
                        all_news6.CacheOption = BitmapCacheOption.OnLoad;
                        all_news6.StreamSource = all_news6ms;
                        all_news6.EndInit();
                        // set properties of news
                        Updatenew6.Background = new ImageBrush(all_news6);
                        Updatenew6.Content = all_news[news6].get_id().ToString();
                        Updatenew6.FontSize = 0.1;

                        Updatenew1.Visibility = Visibility.Visible;
                        Updatenew2.Visibility = Visibility.Visible;
                        Updatenew3.Visibility = Visibility.Visible;
                        Updatenew4.Visibility = Visibility.Visible;
                        Updatenew5.Visibility = Visibility.Visible;
                        Updatenew6.Visibility = Visibility.Visible;
                    }


                }
            }

        }

        private void Updatenew1_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage photo;
            MemoryStream ms;
            photo = new BitmapImage();
            //profilephoto.Source = photo;
            NEWStoUpdatepanel.Visibility = Visibility.Collapsed;
            UpdateNewsEditeBorder.Visibility = Visibility.Visible;
            searchstackpanel.Visibility = Visibility.Collapsed;
            updatNewsEditPanel.Visibility = Visibility.Visible;
            string id = (sender as Button).Content.ToString();
            upnew = News.get_new(id);
            authorUpdate_txt.Text = upnew.get_author();
            new_titleUpdate_txt.Text = upnew.get_title();
            TextRange txt = new TextRange(new_descri_update_tb.Document.ContentStart, new_descri_update_tb.Document.ContentEnd);
            //  new_descri_update_tb.DataContext=upnew.get_description();
            txt.Text = upnew.get_description();
            Updatedatepicker.Text = upnew.get_time().ToString();
            //catagoryUpdate_ComboBox.Text = upnew.get_category();
            //catagorycombox.Text = upnew.get_category();
            ms = new MemoryStream(upnew.get_photo());
            photo.BeginInit();
            ms.Position = 0;
            //photo.BeginInit();
            photo.CacheOption = BitmapCacheOption.OnLoad;
            photo.StreamSource = ms;
            photo.EndInit();
            //// set properties of news
            newUpdatesphoto.Source = photo;
            update_news_photo = photo;

            categories = News.categories;
            catagoryUpdate_ComboBox.Items.Clear();
            for (int i = 0; i < categories.Count; i++)
            {
                catagoryUpdate_ComboBox.Items.Add(categories[i]);

            }
            catagoryUpdate_ComboBox.Text = upnew.get_category();


        }
        private void changeUpdatephoto_bt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                update_news_photo = new BitmapImage();
                update_news_photo.BeginInit();
                update_news_photo.UriSource = new Uri(selectedFilePath);
                update_news_photo.DecodePixelWidth = 400;
                update_news_photo.DecodePixelHeight = 500;
                update_news_photo.EndInit();
               
                newUpdatesphoto.Source = update_news_photo;
                newUpdatesphoto.Width = 320;
                newUpdatesphoto.Height = 226;
                newUpdatesphoto.Stretch = Stretch.Fill;
                newUpdatesphoto.HorizontalAlignment = HorizontalAlignment.Left;
                newUpdatesphoto.VerticalAlignment = VerticalAlignment.Top;
                //Width = "260" Height = "226"


            }
        }
        private void Updatenews_bt_Click(object sender, RoutedEventArgs e)
        {
            int id = upnew.get_id();
            TextRange textRange = new TextRange(
        // TextPointer to the start of content in the RichTextBox.
            new_descri_update_tb.Document.ContentStart,
        // TextPointer to the end of content in the RichTextBox.
            new_descri_update_tb.Document.ContentEnd);

            Ad.Updat_existing_news(id, new_titleUpdate_txt.Text, textRange.Text, catagoryUpdate_ComboBox.Text, authorUpdate_txt.Text, update_news_photo, Convert.ToDateTime(Updatedatepicker.Text));

            MessageBox.Show("Successfully Updated");
        }

        private void Addnuser_bt_Click(object sender, RoutedEventArgs e)

        {
            byte[] defaultphoto = File.ReadAllBytes(@"E:\Newsify\Resources\user.png");
            MemoryStream ms = new MemoryStream(defaultphoto);
            user_photo = new BitmapImage();
            user_photo.BeginInit();
            user_photo.CacheOption = BitmapCacheOption.OnLoad;
            user_photo.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            user_photo.StreamSource = ms;
            user_photo.EndInit();
            var parent = (FrameworkElement)password_tb.Template.FindName("PART_PasswordBox", password_tb);
            var passwordBox = (PasswordBox)parent.FindName("PART_PasswordBox");
            var password = passwordBox.Password;
            password_tb.Text = password;

            if (Ad.check_valid_name(firstname_tb.Text))
            {
                if (!Ad.usernameExist(username_tb.Text))
                {
                    if (Ad.check_valid_username(username_tb.Text))
                    {
                        if (!Ad.emailExist(Email_tb.Text))
                        {
                            if (Ad.check_valid_mail(Email_tb.Text))
                            {
                                if (Ad.Check_valid_Pass(password_tb.Text))
                                {
                                    if (Ad.Check_valid_PhoneNo(phonenumber_tb.Text))
                                    {
                                        if (Ad.check_valid_age(Convert.ToDateTime(datepickeradduser.Text)))
                                        {
                                            Ad.AddPerson(firstname_tb.Text, lastname_tb.Text, username_tb.Text, Email_tb.Text, password_tb.Text, Convert.ToDateTime(datepickeradduser.Text), phonenumber_tb.Text, user_photo ,"u");
                                            MessageBox.Show("Successfully Added" ,"Add User",MessageBoxButton.OK,MessageBoxImage.Information);
                                            firstname_tb.Text = "";
                                            lastname_tb.Text = "";
                                            username_tb.Text = "";
                                            Email_tb.Clear();
                                            passwordBox.Clear();
                                            password_tb.Text = "";
                                            phonenumber_tb.Text = "";
                                            datepickeradduser.SelectedDate = null;

                                        }
                                        else
                                        {
                                            MessageBox.Show("Invalid Age", "Add User", MessageBoxButton.OK, MessageBoxImage.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid Phone Number", "Add User", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Password Must be 8 Characters Doesn't Contain Special Characters", "Add User", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Email", "Add User", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email is already Exist", "Add User", MessageBoxButton.OK, MessageBoxImage.Warning);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username", "Add User", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Usename is already Exist", "Add User", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Write Your Name Correctly", "Add User", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void removeUser_bt_Click(object sender, RoutedEventArgs e)
        {
            if (Ad.usernameExist(removeUser_tb.Text))
            {
                Ad.remove_user(removeUser_tb.Text);
                MessageBox.Show("Removed Successfully");
                removeUser_tb.Clear();
                TextRange txt = new TextRange(CommentremoveUser_tb.Document.ContentStart, CommentremoveUser_tb.Document.ContentEnd);
                txt.Text = "";
            }
            else
            {
                MessageBox.Show("Username Doesn't Exist");
            }
        }

        private void addcatagory_bt_Click(object sender, RoutedEventArgs e)
        {
            if (AddCategory_txt.Text == "")
            {
                MessageBox.Show("Please write the category");
                return;
            }
            if (Ad.add_new_category(AddCategory_txt.Text))
            {
                MessageBox.Show("Added Successfully :)");
                AddCategory_txt.Text = "";

            }
            else
            {
                MessageBox.Show("Category is already exist");
            }
        }
        private void Addnews_bt_Click(object sender, RoutedEventArgs e)
        {

            string newsTitle = new_title_txt.Text;
            string newsContent = new TextRange(new_descri_tb.Document.ContentStart, new_descri_tb.Document.ContentEnd).Text;
            string newsCategory = catagory_Combobox.Text;
            string newsAuthor = author_txt.Text;
            DateTime newsDate = Convert.ToDateTime(datepicker.Text);


            Ad.AddNew(newsTitle, newsContent, newsCategory, newsAuthor, new_news_photo, newsDate);

            MessageBox.Show("Successfully added");
            new_title_txt.Clear();
            author_txt.Clear();
            datepicker.SelectedDate = null;
            catagory_Combobox.Text = "";
            TextRange txt = new TextRange(new_descri_tb.Document.ContentStart, new_descri_tb.Document.ContentEnd);
            txt.Text = "";
        }

        private void savephoto_bt_Click(object sender, RoutedEventArgs e)
        {


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.bmp;*.gif)|*.png;*.jpeg;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                new_news_photo = new BitmapImage();
                new_news_photo.BeginInit();
                new_news_photo.UriSource = new Uri(selectedFilePath);
                new_news_photo.DecodePixelWidth = 400;
                new_news_photo.DecodePixelHeight = 500;
                new_news_photo.EndInit();
                newsphoto.Source = new_news_photo;
                newsphoto.Width = 300;
                newsphoto.Height = 226;
                newsphoto.Stretch = Stretch.Fill;
                //selectprofile_image.Stretch = Stretch.Uniform;
                newsphoto.HorizontalAlignment = HorizontalAlignment.Center;
                newsphoto.VerticalAlignment = VerticalAlignment.Top;

            }
        }
        private void Addadmin_bt_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                string firstname = firstnameADMIN_tb.Text;
                string lastname = lastnameADMIN_tb.Text;
                string username = usernameADMIN_tb.Text;
                string email = EmailADMIN_tb.Text;
                string phoneumber = phonenumberADMIN_tb.Text;
                DateTime birthdate = Convert.ToDateTime(datepickeraddADMIN.Text);
               
                var parent = (FrameworkElement)passwordADMIN_tb.Template.FindName("PART_PasswordBox", passwordADMIN_tb);
                var passwordBox = (PasswordBox)parent.FindName("PART_PasswordBox");
                var passwordd = passwordBox.Password;
                passwordADMIN_tb.Text = passwordd;

                /*string password=passwordADMIN_tb.Text;*/





                byte[] defaultphoto = File.ReadAllBytes(@"E:\Newsify\Resources\user.png");
                MemoryStream ms = new MemoryStream(defaultphoto);
                admin_photo = new BitmapImage();
                admin_photo.BeginInit();
                admin_photo.CacheOption = BitmapCacheOption.OnLoad;
                admin_photo.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                admin_photo.StreamSource = ms;
                admin_photo.EndInit();

                if (Ad.check_valid_name(firstname))
                {
                    if (Ad.check_valid_name(lastname))
                    {
                        if (Ad.check_valid_username(username))
                        {
                            if (Ad.check_valid_mail(email))
                            {
                                if (Ad.check_valid_age(birthdate))
                                {
                                    if (Ad.Check_valid_PhoneNo(phoneumber))
                                    {
                                        if (Ad.Check_valid_Pass(passwordADMIN_tb.Text))
                                        {

                                            Ad.AddPerson(firstname, lastname, username, email, passwordADMIN_tb.Text, birthdate, phoneumber, admin_photo, "a");
                                            MessageBox.Show("Added Successfully");

                                            firstnameADMIN_tb.Clear();

                                            lastnameADMIN_tb.Clear();

                                            passwordADMIN_tb.Clear();

                                            phonenumberADMIN_tb.Clear();
                                            passwordBox.Clear();

                                            EmailADMIN_tb.Clear();

                                            datepickeraddADMIN.SelectedDate = null;

                                            usernameADMIN_tb.Clear();

                                        }
                                        else
                                            MessageBox.Show("Invalid Password");
                                    }
                                    else
                                        MessageBox.Show("Invalid Phonenumber");
                                }
                                else
                                    MessageBox.Show("Invalid Birthdate");
                            }
                            else
                                MessageBox.Show("Invalid Email");
                        }
                        else
                            MessageBox.Show("Invalid Username");
                    }
                    else
                        MessageBox.Show("Invalid Last Name");

                }
                else
                    MessageBox.Show("Invalid First Name");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

       

        private void ShowAllNews_Tb_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            catagorycombox.Items.Clear();
            ratecombox.Items.Clear();
            all_news = News.GetDataNewss();

            categories = News.exist_cat(all_news, categories);

            for (int i = 0; i < categories.Count; i++)
            {
                    catagorycombox.Items.Add(categories[i]);
            }
            
            
             ratecombox.Items.Add("Top Rated");
             ratecombox.Items.Add("Least Rated");
            

           



            if (all_news.Count == 1)
            {
                news1 = 0;
                all_news1 = new BitmapImage();
                all_news1ms = new MemoryStream(all_news[news1].get_photo());
                all_news1ms.Position = 0;
                all_news1.BeginInit();
                all_news1.CacheOption = BitmapCacheOption.OnLoad;
                all_news1.StreamSource = all_news1ms;
                all_news1.EndInit();
                // set properties of news
                new1.Background = new ImageBrush(all_news1);
                new1.Content = all_news[news1].get_id().ToString();
                new1.FontSize = 0.1;

                /////////////////////////////
                ///
                new1.Visibility = Visibility.Visible;
                new2.Visibility = Visibility.Hidden;
                new3.Visibility = Visibility.Hidden;
                new4.Visibility = Visibility.Hidden;
                new5.Visibility = Visibility.Hidden;
                new6.Visibility = Visibility.Hidden;
            }
            else if (all_news.Count == 2)
            {
                news1 = 0;
                all_news1 = new BitmapImage();
                all_news1ms = new MemoryStream(all_news[news1].get_photo());
                all_news1ms.Position = 0;
                all_news1.BeginInit();
                all_news1.CacheOption = BitmapCacheOption.OnLoad;
                all_news1.StreamSource = all_news1ms;
                all_news1.EndInit();
                // set properties of news
                new1.Background = new ImageBrush(all_news1);
                new1.Content = all_news[news1].get_id().ToString();
                new1.FontSize = 0.1;

                /////////////////////////////
                news2 = 1;
                all_news2 = new BitmapImage();
                all_news2ms = new MemoryStream(all_news[news2].get_photo());
                all_news2ms.Position = 0;
                all_news2.BeginInit();
                all_news2.CacheOption = BitmapCacheOption.OnLoad;
                all_news2.StreamSource = all_news2ms;
                all_news2.EndInit();
                // set properties of news
                new2.Background = new ImageBrush(all_news2);
                new2.Content = all_news[news2].get_id().ToString();
                new2.FontSize = 0.1;

                /////////////////////////////
                ///
                new1.Visibility = Visibility.Visible;
                new2.Visibility = Visibility.Visible;

                new3.Visibility = Visibility.Hidden;
                new4.Visibility = Visibility.Hidden;
                new5.Visibility = Visibility.Hidden;
                new6.Visibility = Visibility.Hidden;
            }
            else if (all_news.Count == 3)
            {
                news1 = 0;
                all_news1 = new BitmapImage();
                all_news1ms = new MemoryStream(all_news[news1].get_photo());
                all_news1ms.Position = 0;
                all_news1.BeginInit();
                all_news1.CacheOption = BitmapCacheOption.OnLoad;
                all_news1.StreamSource = all_news1ms;
                all_news1.EndInit();
                // set properties of news
                new1.Background = new ImageBrush(all_news1);
                new1.Content = all_news[news1].get_id().ToString();
                new1.FontSize = 0.1;

                /////////////////////////////
                news2 = 1;
                all_news2 = new BitmapImage();
                all_news2ms = new MemoryStream(all_news[news2].get_photo());
                all_news2ms.Position = 0;
                all_news2.BeginInit();
                all_news2.CacheOption = BitmapCacheOption.OnLoad;
                all_news2.StreamSource = all_news2ms;
                all_news2.EndInit();
                // set properties of news
                new2.Background = new ImageBrush(all_news2);
                new2.Content = all_news[news2].get_id().ToString();
                new2.FontSize = 0.1;

                /////////////////////////////
                news3 = 2;
                all_news3 = new BitmapImage();
                all_news3ms = new MemoryStream(all_news[news3].get_photo());
                all_news3ms.Position = 0;
                all_news3.BeginInit();
                all_news3.CacheOption = BitmapCacheOption.OnLoad;
                all_news3.StreamSource = all_news3ms;
                all_news3.EndInit();
                // set properties of news
                new3.Background = new ImageBrush(all_news3);
                new3.Content = all_news[news3].get_id().ToString();
                new3.FontSize = 0.1;

                /////////////////////////////
                new1.Visibility = Visibility.Visible;
                new2.Visibility = Visibility.Visible;
                new3.Visibility = Visibility.Visible;

                new4.Visibility = Visibility.Hidden;
                new5.Visibility = Visibility.Hidden;
                new6.Visibility = Visibility.Hidden;
            }
            else if (all_news.Count == 4)
            {
                news1 = 0;
                all_news1 = new BitmapImage();
                all_news1ms = new MemoryStream(all_news[news1].get_photo());
                all_news1ms.Position = 0;
                all_news1.BeginInit();
                all_news1.CacheOption = BitmapCacheOption.OnLoad;
                all_news1.StreamSource = all_news1ms;
                all_news1.EndInit();
                // set properties of news
                new1.Background = new ImageBrush(all_news1);
                new1.Content = all_news[news1].get_id().ToString();
                new1.FontSize = 0.1;

                /////////////////////////////
                news2 = 1;
                all_news2 = new BitmapImage();
                all_news2ms = new MemoryStream(all_news[news2].get_photo());
                all_news2ms.Position = 0;
                all_news2.BeginInit();
                all_news2.CacheOption = BitmapCacheOption.OnLoad;
                all_news2.StreamSource = all_news2ms;
                all_news2.EndInit();
                // set properties of news
                new2.Background = new ImageBrush(all_news2);
                new2.Content = all_news[news2].get_id().ToString();
                new2.FontSize = 0.1;

                /////////////////////////////
                news3 = 2;
                all_news3 = new BitmapImage();
                all_news3ms = new MemoryStream(all_news[news3].get_photo());
                all_news3ms.Position = 0;
                all_news3.BeginInit();
                all_news3.CacheOption = BitmapCacheOption.OnLoad;
                all_news3.StreamSource = all_news3ms;
                all_news3.EndInit();
                // set properties of news
                new3.Background = new ImageBrush(all_news3);
                new3.Content = all_news[news3].get_id().ToString();
                new3.FontSize = 0.1;

                /////////////////////////////
                news4 = 3;
                all_news4 = new BitmapImage();
                all_news4ms = new MemoryStream(all_news[news4].get_photo());
                all_news4ms.Position = 0;
                all_news4.BeginInit();
                all_news4.CacheOption = BitmapCacheOption.OnLoad;
                all_news4.StreamSource = all_news4ms;
                all_news4.EndInit();
                // set properties of news
                new4.Background = new ImageBrush(all_news4);
                new4.Content = all_news[news4].get_id().ToString();
                new4.FontSize = 0.1;

                /////////////////////////////
                new1.Visibility = Visibility.Visible;
                new2.Visibility = Visibility.Visible;
                new3.Visibility = Visibility.Visible;
                new4.Visibility = Visibility.Visible;

                new5.Visibility = Visibility.Hidden;
                new6.Visibility = Visibility.Hidden;
            }
            else if (all_news.Count == 5)
            {
                news1 = 0;
                all_news1 = new BitmapImage();
                all_news1ms = new MemoryStream(all_news[news1].get_photo());
                all_news1ms.Position = 0;
                all_news1.BeginInit();
                all_news1.CacheOption = BitmapCacheOption.OnLoad;
                all_news1.StreamSource = all_news1ms;
                all_news1.EndInit();
                // set properties of news
                new1.Background = new ImageBrush(all_news1);
                new1.Content = all_news[news1].get_id().ToString();
                new1.FontSize = 0.1;

                /////////////////////////////
                news2 = 1;
                all_news2 = new BitmapImage();
                all_news2ms = new MemoryStream(all_news[news2].get_photo());
                all_news2ms.Position = 0;
                all_news2.BeginInit();
                all_news2.CacheOption = BitmapCacheOption.OnLoad;
                all_news2.StreamSource = all_news2ms;
                all_news2.EndInit();
                // set properties of news
                new2.Background = new ImageBrush(all_news2);
                new2.Content = all_news[news2].get_id().ToString();
                new2.FontSize = 0.1;

                /////////////////////////////
                news3 = 2;
                all_news3 = new BitmapImage();
                all_news3ms = new MemoryStream(all_news[news3].get_photo());
                all_news3ms.Position = 0;
                all_news3.BeginInit();
                all_news3.CacheOption = BitmapCacheOption.OnLoad;
                all_news3.StreamSource = all_news3ms;
                all_news3.EndInit();
                // set properties of news
                new3.Background = new ImageBrush(all_news3);
                new3.Content = all_news[news3].get_id().ToString();
                new3.FontSize = 0.1;

                /////////////////////////////
                news4 = 3;
                all_news4 = new BitmapImage();
                all_news4ms = new MemoryStream(all_news[news4].get_photo());
                all_news4ms.Position = 0;
                all_news4.BeginInit();
                all_news4.CacheOption = BitmapCacheOption.OnLoad;
                all_news4.StreamSource = all_news4ms;
                all_news4.EndInit();
                // set properties of news
                new4.Background = new ImageBrush(all_news4);
                new4.Content = all_news[news4].get_id().ToString();
                new4.FontSize = 0.1;

                /////////////////////////////
                news5 = 4;
                all_news5 = new BitmapImage();
                all_news5ms = new MemoryStream(all_news[news5].get_photo());
                all_news5ms.Position = 0;
                all_news5.BeginInit();
                all_news5.CacheOption = BitmapCacheOption.OnLoad;
                all_news5.StreamSource = all_news5ms;
                all_news5.EndInit();
                // set properties of news
                new5.Background = new ImageBrush(all_news5);
                new5.Content = all_news[news5].get_id().ToString();
                new5.FontSize = 0.1;

                /////////////////////////////
                new1.Visibility = Visibility.Visible;
                new2.Visibility = Visibility.Visible;
                new3.Visibility = Visibility.Visible;
                new4.Visibility = Visibility.Visible;
                new5.Visibility = Visibility.Visible;

                new6.Visibility = Visibility.Hidden;
            }
            else
            {
                news1 = 0;
                all_news1 = new BitmapImage();
                all_news1ms = new MemoryStream(all_news[news1].get_photo());
                all_news1ms.Position = 0;
                all_news1.BeginInit();
                all_news1.CacheOption = BitmapCacheOption.OnLoad;
                all_news1.StreamSource = all_news1ms;
                all_news1.EndInit();
                // set properties of news
                new1.Background = new ImageBrush(all_news1);
                new1.Content = all_news[news1].get_id().ToString();
                new1.FontSize = 0.1;

                /////////////////////////////
                news2 = 1;
                all_news2 = new BitmapImage();
                all_news2ms = new MemoryStream(all_news[news2].get_photo());
                all_news2ms.Position = 0;
                all_news2.BeginInit();
                all_news2.CacheOption = BitmapCacheOption.OnLoad;
                all_news2.StreamSource = all_news2ms;
                all_news2.EndInit();
                // set properties of news
                new2.Background = new ImageBrush(all_news2);
                new2.Content = all_news[news2].get_id().ToString();
                new2.FontSize = 0.1;

                /////////////////////////////
                news3 = 2;
                all_news3 = new BitmapImage();
                all_news3ms = new MemoryStream(all_news[news3].get_photo());
                all_news3ms.Position = 0;
                all_news3.BeginInit();
                all_news3.CacheOption = BitmapCacheOption.OnLoad;
                all_news3.StreamSource = all_news3ms;
                all_news3.EndInit();
                // set properties of news
                new3.Background = new ImageBrush(all_news3);
                new3.Content = all_news[news3].get_id().ToString();
                new3.FontSize = 0.1;

                /////////////////////////////
                news4 = 3;
                all_news4 = new BitmapImage();
                all_news4ms = new MemoryStream(all_news[news4].get_photo());
                all_news4ms.Position = 0;
                all_news4.BeginInit();
                all_news4.CacheOption = BitmapCacheOption.OnLoad;
                all_news4.StreamSource = all_news4ms;
                all_news4.EndInit();
                // set properties of news
                new4.Background = new ImageBrush(all_news4);
                new4.Content = all_news[news4].get_id().ToString();
                new4.FontSize = 0.1;

                /////////////////////////////
                news5 = 4;
                all_news5 = new BitmapImage();
                all_news5ms = new MemoryStream(all_news[news5].get_photo());
                all_news5ms.Position = 0;
                all_news5.BeginInit();
                all_news5.CacheOption = BitmapCacheOption.OnLoad;
                all_news5.StreamSource = all_news5ms;
                all_news5.EndInit();
                // set properties of news
                new5.Background = new ImageBrush(all_news5);
                new5.Content = all_news[news5].get_id().ToString();
                new5.FontSize = 0.1;

                /////////////////////////////
                news6 = 5;
                all_news6 = new BitmapImage();
                all_news6ms = new MemoryStream(all_news[news6].get_photo());
                all_news6ms.Position = 0;
                all_news6.BeginInit();
                all_news6.CacheOption = BitmapCacheOption.OnLoad;
                all_news6.StreamSource = all_news6ms;
                all_news6.EndInit();
                // set properties of news
                new6.Background = new ImageBrush(all_news6);
                new6.Content = all_news[news6].get_id().ToString();
                new6.FontSize = 0.1;

                new1.Visibility = Visibility.Visible;
                new2.Visibility = Visibility.Visible;
                new3.Visibility = Visibility.Visible;
                new4.Visibility = Visibility.Visible;
                new5.Visibility = Visibility.Visible;
                new6.Visibility = Visibility.Visible;
            }



        }

        private void search_txt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (search_txt.Text == "SEARCH...")
            {
                search_txt.Text = "";
            }
        }

        private void search_txt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (search_txt.Text == "")
            {
                search_txt.Text = "SEARCH...";
            }

        }

        private void Right_btn_Click(object sender, RoutedEventArgs e)
        {

            if (news1 >= all_news.Count - 1|| news2 >= all_news.Count - 1|| news3 >= all_news.Count - 1|| news4 >= all_news.Count - 1|| news5 >= all_news.Count - 1|| news6 >= all_news.Count - 1)
            {
                return;
            }
            else
            {
                news1 += 6;
                news2 += 6;
                news3 += 6;
                news4 += 6;
                news5 += 6;
                news6 += 6;

                if (news6 < all_news.Count)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    new2.Background = new ImageBrush(all_news2);
                    new2.Content = all_news[news2].get_id().ToString();
                    new2.FontSize = 0.1;

                    /////////////////////////////
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    new3.Background = new ImageBrush(all_news3);
                    new3.Content = all_news[news3].get_id().ToString();
                    new3.FontSize = 0.1;

                    /////////////////////////////
                    all_news4 = new BitmapImage();
                    all_news4ms = new MemoryStream(all_news[news4].get_photo());
                    all_news4ms.Position = 0;
                    all_news4.BeginInit();
                    all_news4.CacheOption = BitmapCacheOption.OnLoad;
                    all_news4.StreamSource = all_news4ms;
                    all_news4.EndInit();
                    // set properties of news
                    new4.Background = new ImageBrush(all_news4);
                    new4.Content = all_news[news4].get_id().ToString();
                    new4.FontSize = 0.1;

                    /////////////////////////////
                    all_news5 = new BitmapImage();
                    all_news5ms = new MemoryStream(all_news[news5].get_photo());
                    all_news5ms.Position = 0;
                    all_news5.BeginInit();
                    all_news5.CacheOption = BitmapCacheOption.OnLoad;
                    all_news5.StreamSource = all_news5ms;
                    all_news5.EndInit();
                    // set properties of news
                    new5.Background = new ImageBrush(all_news5);
                    new5.Content = all_news[news5].get_id().ToString();
                    new5.FontSize = 0.1;

                    /////////////////////////////
                    all_news6 = new BitmapImage();
                    all_news6ms = new MemoryStream(all_news[news6].get_photo());
                    all_news6ms.Position = 0;
                    all_news6.BeginInit();
                    all_news6.CacheOption = BitmapCacheOption.OnLoad;
                    all_news6.StreamSource = all_news6ms;
                    all_news6.EndInit();
                    // set properties of news
                    new6.Background = new ImageBrush(all_news6);
                    new6.Content = all_news[news6].get_id().ToString();
                    new6.FontSize = 0.1;

                }
                else if (news5 < all_news.Count )
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    new2.Background = new ImageBrush(all_news2);
                    new2.Content = all_news[news2].get_id().ToString();
                    new2.FontSize = 0.1;

                    /////////////////////////////
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    new3.Background = new ImageBrush(all_news3);
                    new3.Content = all_news[news3].get_id().ToString();
                    new3.FontSize = 0.1;

                    /////////////////////////////
                    all_news4 = new BitmapImage();
                    all_news4ms = new MemoryStream(all_news[news4].get_photo());
                    all_news4ms.Position = 0;
                    all_news4.BeginInit();
                    all_news4.CacheOption = BitmapCacheOption.OnLoad;
                    all_news4.StreamSource = all_news4ms;
                    all_news4.EndInit();
                    // set properties of news
                    new4.Background = new ImageBrush(all_news4);
                    new4.Content = all_news[news4].get_id().ToString();
                    new4.FontSize = 0.1;

                    /////////////////////////////
                    all_news5 = new BitmapImage();
                    all_news5ms = new MemoryStream(all_news[news5].get_photo());
                    all_news5ms.Position = 0;
                    all_news5.BeginInit();
                    all_news5.CacheOption = BitmapCacheOption.OnLoad;
                    all_news5.StreamSource = all_news5ms;
                    all_news5.EndInit();
                    // set properties of news
                    new5.Background = new ImageBrush(all_news5);
                    new5.Content = all_news[news5].get_id().ToString();
                    new5.FontSize = 0.1;

                    new6.Visibility = Visibility.Hidden;


                }
                else if (news4 < all_news.Count )
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    new2.Background = new ImageBrush(all_news2);
                    new2.Content = all_news[news2].get_id().ToString();
                    new2.FontSize = 0.1;

                    /////////////////////////////
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    new3.Background = new ImageBrush(all_news3);
                    new3.Content = all_news[news3].get_id().ToString();
                    new3.FontSize = 0.1;

                    /////////////////////////////
                    all_news4 = new BitmapImage();
                    all_news4ms = new MemoryStream(all_news[news4].get_photo());
                    all_news4ms.Position = 0;
                    all_news4.BeginInit();
                    all_news4.CacheOption = BitmapCacheOption.OnLoad;
                    all_news4.StreamSource = all_news4ms;
                    all_news4.EndInit();
                    // set properties of news
                    new4.Background = new ImageBrush(all_news4);
                    new4.Content = all_news[news4].get_id().ToString();
                    new4.FontSize = 0.1;

                    /////////////////////////////
                    ///
                    new5.Visibility = Visibility.Hidden;
                    new6.Visibility = Visibility.Hidden;

                }
                else if(news3 < all_news.Count )
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    new2.Background = new ImageBrush(all_news2);
                    new2.Content = all_news[news2].get_id().ToString();
                    new2.FontSize = 0.1;

                    /////////////////////////////
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    new3.Background = new ImageBrush(all_news3);
                    new3.Content = all_news[news3].get_id().ToString();
                    new3.FontSize = 0.1;

                    /////////////////////////////
                    ///
                    new4.Visibility = Visibility.Hidden;
                    new5.Visibility = Visibility.Hidden;
                    new6.Visibility = Visibility.Hidden;

                }
                else if (news2 < all_news.Count )
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    new2.Background = new ImageBrush(all_news2);
                    new2.Content = all_news[news2].get_id().ToString();
                    new2.FontSize = 0.1;

                    /////////////////////////////
                    ///
                    new3.Visibility = Visibility.Hidden;
                    new4.Visibility = Visibility.Hidden;
                    new5.Visibility = Visibility.Hidden;
                    new6.Visibility = Visibility.Hidden;
                }
                else if (news1 < all_news.Count )
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    new2.Visibility = Visibility.Hidden;
                    new3.Visibility = Visibility.Hidden;
                    new4.Visibility = Visibility.Hidden;
                    new5.Visibility = Visibility.Hidden;
                    new6.Visibility = Visibility.Hidden;

                }
                else
                {
                    return;
                }

            }



        }

        private void Left_btn_Click(object sender, RoutedEventArgs e)
        {
            if (news1 <= 0|| news2 <= 0 || news3 <= 0 || news4 <= 0 || news5 <= 0 || news6 <= 0)
            {
                return;
            }
            else
            {
                news1 -= 6;
                news2 -= 6;
                news3 -= 6;
                news4 -= 6;
                news5 -= 6;
                news6 -= 6;


                if (news1 >= 0)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    new2.Background = new ImageBrush(all_news2);
                    new2.Content = all_news[news2].get_id().ToString();
                    new2.FontSize = 0.1;

                    /////////////////////////////
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    new3.Background = new ImageBrush(all_news3);
                    new3.Content = all_news[news3].get_id().ToString();
                    new3.FontSize = 0.1;

                    /////////////////////////////
                    all_news4 = new BitmapImage();
                    all_news4ms = new MemoryStream(all_news[news4].get_photo());
                    all_news4ms.Position = 0;
                    all_news4.BeginInit();
                    all_news4.CacheOption = BitmapCacheOption.OnLoad;
                    all_news4.StreamSource = all_news4ms;
                    all_news4.EndInit();
                    // set properties of news
                    new4.Background = new ImageBrush(all_news4);
                    new4.Content = all_news[news4].get_id().ToString();
                    new4.FontSize = 0.1;

                    /////////////////////////////
                    all_news5 = new BitmapImage();
                    all_news5ms = new MemoryStream(all_news[news5].get_photo());
                    all_news5ms.Position = 0;
                    all_news5.BeginInit();
                    all_news5.CacheOption = BitmapCacheOption.OnLoad;
                    all_news5.StreamSource = all_news5ms;
                    all_news5.EndInit();
                    // set properties of news
                    new5.Background = new ImageBrush(all_news5);
                    new5.Content = all_news[news5].get_id().ToString();
                    new5.FontSize = 0.1;

                    /////////////////////////////
                    all_news6 = new BitmapImage();
                    all_news6ms = new MemoryStream(all_news[news6].get_photo());
                    all_news6ms.Position = 0;
                    all_news6.BeginInit();
                    all_news6.CacheOption = BitmapCacheOption.OnLoad;
                    all_news6.StreamSource = all_news6ms;
                    all_news6.EndInit();
                    // set properties of news
                    new6.Background = new ImageBrush(all_news6);
                    new6.Content = all_news[news6].get_id().ToString();
                    new6.FontSize = 0.1;

                    new1.Visibility = Visibility.Visible;
                    new2.Visibility = Visibility.Visible;
                    new3.Visibility = Visibility.Visible;
                    new4.Visibility = Visibility.Visible;
                    new5.Visibility = Visibility.Visible;
                    new6.Visibility = Visibility.Visible;


                }
                else if (news2 >= 0)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    new2.Background = new ImageBrush(all_news2);
                    new2.Content = all_news[news2].get_id().ToString();
                    new2.FontSize = 0.1;

                    /////////////////////////////
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    new3.Background = new ImageBrush(all_news3);
                    new3.Content = all_news[news3].get_id().ToString();
                    new3.FontSize = 0.1;

                    /////////////////////////////
                    all_news4 = new BitmapImage();
                    all_news4ms = new MemoryStream(all_news[news4].get_photo());
                    all_news4ms.Position = 0;
                    all_news4.BeginInit();
                    all_news4.CacheOption = BitmapCacheOption.OnLoad;
                    all_news4.StreamSource = all_news4ms;
                    all_news4.EndInit();
                    // set properties of news
                    new4.Background = new ImageBrush(all_news4);
                    new4.Content = all_news[news4].get_id().ToString();
                    new4.FontSize = 0.1;

                    /////////////////////////////
                    all_news5 = new BitmapImage();
                    all_news5ms = new MemoryStream(all_news[news5].get_photo());
                    all_news5ms.Position = 0;
                    all_news5.BeginInit();
                    all_news5.CacheOption = BitmapCacheOption.OnLoad;
                    all_news5.StreamSource = all_news5ms;
                    all_news5.EndInit();
                    // set properties of news
                    new5.Background = new ImageBrush(all_news5);
                    new5.Content = all_news[news5].get_id().ToString();
                    new5.FontSize = 0.1;

                    new1.Visibility = Visibility.Visible;
                    new2.Visibility = Visibility.Visible;

                    new3.Visibility = Visibility.Visible;
                    new4.Visibility = Visibility.Visible;
                    new5.Visibility = Visibility.Visible;

                    new6.Visibility = Visibility.Hidden;


                }
                else if (news3 >= 0)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    new2.Background = new ImageBrush(all_news2);
                    new2.Content = all_news[news2].get_id().ToString();
                    new2.FontSize = 0.1;

                    /////////////////////////////
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    new3.Background = new ImageBrush(all_news3);
                    new3.Content = all_news[news3].get_id().ToString();
                    new3.FontSize = 0.1;

                    /////////////////////////////
                    all_news4 = new BitmapImage();
                    all_news4ms = new MemoryStream(all_news[news4].get_photo());
                    all_news4ms.Position = 0;
                    all_news4.BeginInit();
                    all_news4.CacheOption = BitmapCacheOption.OnLoad;
                    all_news4.StreamSource = all_news4ms;
                    all_news4.EndInit();
                    // set properties of news
                    new4.Background = new ImageBrush(all_news4);
                    new4.Content = all_news[news4].get_id().ToString();
                    new4.FontSize = 0.1;

                    /////////////////////////////
                    ///
                    new1.Visibility = Visibility.Visible;
                    new2.Visibility = Visibility.Visible;
                    new3.Visibility = Visibility.Visible;

                    new4.Visibility = Visibility.Hidden;
                    new5.Visibility = Visibility.Hidden;
                    new6.Visibility = Visibility.Hidden;

                }
                else if (news4 >= 0)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    new2.Background = new ImageBrush(all_news2);
                    new2.Content = all_news[news2].get_id().ToString();
                    new2.FontSize = 0.1;

                    /////////////////////////////
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    new3.Background = new ImageBrush(all_news3);
                    new3.Content = all_news[news3].get_id().ToString();
                    new3.FontSize = 0.1;

                    /////////////////////////////
                    ///
                    new1.Visibility = Visibility.Visible;
                    new2.Visibility = Visibility.Visible;
                    new3.Visibility = Visibility.Hidden;
                    new4.Visibility = Visibility.Hidden;

                    new5.Visibility = Visibility.Hidden;
                    new6.Visibility = Visibility.Hidden;

                }
                else if (news5 >= 0)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    new2.Background = new ImageBrush(all_news2);
                    new2.Content = all_news[news2].get_id().ToString();
                    new2.FontSize = 0.1;

                    /////////////////////////////
                    ///
                    new1.Visibility = Visibility.Visible;
                    new2.Visibility = Visibility.Visible;
                    new3.Visibility = Visibility.Hidden;
                    new4.Visibility = Visibility.Hidden;
                    new5.Visibility = Visibility.Hidden;
                    new6.Visibility = Visibility.Hidden;
                }
                else if (news6 >= 0)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    new1.Visibility = Visibility.Visible;
                    new2.Visibility = Visibility.Hidden;
                    new3.Visibility = Visibility.Hidden;
                    new4.Visibility = Visibility.Hidden;
                    new5.Visibility = Visibility.Hidden;
                    new6.Visibility = Visibility.Hidden;

                }
                else
                {
                    return;
                }
            }

     }

        private void catagorycombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            all_news = News.GetDataNewss();

            if (catagorycombox.SelectedItem == null)
            {
                return;
            }

             all_news = News.Filter_and_Sort_by_Category(all_news, catagorycombox.SelectedItem.ToString());
           
            if (ratecombox.Text == "")
            {

                if (all_news.Count == 1)
                {
                    news1 = 0;
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    /////////////////////////////
                    ///
                    new1.Visibility = Visibility.Visible;
                    new2.Visibility = Visibility.Hidden;
                    new3.Visibility = Visibility.Hidden;
                    new4.Visibility = Visibility.Hidden;
                    new5.Visibility = Visibility.Hidden;
                    new6.Visibility = Visibility.Hidden;
                }
                else if (all_news.Count == 2)
                {
                    news1 = 0;
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    /////////////////////////////
                    news2 = 1;
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    new2.Background = new ImageBrush(all_news2);
                    new2.Content = all_news[news2].get_id().ToString();
                    new2.FontSize = 0.1;

                    /////////////////////////////
                    ///
                    new1.Visibility = Visibility.Visible;
                    new2.Visibility = Visibility.Visible;

                    new3.Visibility = Visibility.Hidden;
                    new4.Visibility = Visibility.Hidden;
                    new5.Visibility = Visibility.Hidden;
                    new6.Visibility = Visibility.Hidden;
                }
                else if (all_news.Count == 3)
                {
                    news1 = 0;
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    /////////////////////////////
                    news2 = 1;
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    new2.Background = new ImageBrush(all_news2);
                    new2.Content = all_news[news2].get_id().ToString();
                    new2.FontSize = 0.1;

                    /////////////////////////////
                    news3 = 2;
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    new3.Background = new ImageBrush(all_news3);
                    new3.Content = all_news[news3].get_id().ToString();
                    new3.FontSize = 0.1;

                    /////////////////////////////
                    new1.Visibility = Visibility.Visible;
                    new2.Visibility = Visibility.Visible;
                    new3.Visibility = Visibility.Visible;

                    new4.Visibility = Visibility.Hidden;
                    new5.Visibility = Visibility.Hidden;
                    new6.Visibility = Visibility.Hidden;
                }
                else if (all_news.Count == 4)
                {
                    news1 = 0;
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    /////////////////////////////
                    news2 = 1;
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    new2.Background = new ImageBrush(all_news2);
                    new2.Content = all_news[news2].get_id().ToString();
                    new2.FontSize = 0.1;

                    /////////////////////////////
                    news3 = 2;
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    new3.Background = new ImageBrush(all_news3);
                    new3.Content = all_news[news3].get_id().ToString();
                    new3.FontSize = 0.1;

                    /////////////////////////////
                    news4 = 3;
                    all_news4 = new BitmapImage();
                    all_news4ms = new MemoryStream(all_news[news4].get_photo());
                    all_news4ms.Position = 0;
                    all_news4.BeginInit();
                    all_news4.CacheOption = BitmapCacheOption.OnLoad;
                    all_news4.StreamSource = all_news4ms;
                    all_news4.EndInit();
                    // set properties of news
                    new4.Background = new ImageBrush(all_news4);
                    new4.Content = all_news[news4].get_id().ToString();
                    new4.FontSize = 0.1;

                    /////////////////////////////
                    new1.Visibility = Visibility.Visible;
                    new2.Visibility = Visibility.Visible;
                    new3.Visibility = Visibility.Visible;
                    new4.Visibility = Visibility.Visible;

                    new5.Visibility = Visibility.Hidden;
                    new6.Visibility = Visibility.Hidden;
                }
                else if (all_news.Count == 5)
                {
                    news1 = 0;
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    /////////////////////////////
                    news2 = 1;
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    new2.Background = new ImageBrush(all_news2);
                    new2.Content = all_news[news2].get_id().ToString();
                    new2.FontSize = 0.1;

                    /////////////////////////////
                    news3 = 2;
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    new3.Background = new ImageBrush(all_news3);
                    new3.Content = all_news[news3].get_id().ToString();
                    new3.FontSize = 0.1;

                    /////////////////////////////
                    news4 = 3;
                    all_news4 = new BitmapImage();
                    all_news4ms = new MemoryStream(all_news[news4].get_photo());
                    all_news4ms.Position = 0;
                    all_news4.BeginInit();
                    all_news4.CacheOption = BitmapCacheOption.OnLoad;
                    all_news4.StreamSource = all_news4ms;
                    all_news4.EndInit();
                    // set properties of news
                    new4.Background = new ImageBrush(all_news4);
                    new4.Content = all_news[news4].get_id().ToString();
                    new4.FontSize = 0.1;

                    /////////////////////////////
                    news5 = 4;
                    all_news5 = new BitmapImage();
                    all_news5ms = new MemoryStream(all_news[news5].get_photo());
                    all_news5ms.Position = 0;
                    all_news5.BeginInit();
                    all_news5.CacheOption = BitmapCacheOption.OnLoad;
                    all_news5.StreamSource = all_news5ms;
                    all_news5.EndInit();
                    // set properties of news
                    new5.Background = new ImageBrush(all_news5);
                    new5.Content = all_news[news5].get_id().ToString();
                    new5.FontSize = 0.1;

                    /////////////////////////////
                    new1.Visibility = Visibility.Visible;
                    new2.Visibility = Visibility.Visible;
                    new3.Visibility = Visibility.Visible;
                    new4.Visibility = Visibility.Visible;
                    new5.Visibility = Visibility.Visible;

                    new6.Visibility = Visibility.Hidden;
                }
                else
                {
                    news1 = 0;
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    new1.Background = new ImageBrush(all_news1);
                    new1.Content = all_news[news1].get_id().ToString();
                    new1.FontSize = 0.1;

                    /////////////////////////////
                    news2 = 1;
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    new2.Background = new ImageBrush(all_news2);
                    new2.Content = all_news[news2].get_id().ToString();
                    new2.FontSize = 0.1;

                    /////////////////////////////
                    news3 = 2;
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    new3.Background = new ImageBrush(all_news3);
                    new3.Content = all_news[news3].get_id().ToString();
                    new3.FontSize = 0.1;

                    /////////////////////////////
                    news4 = 3;
                    all_news4 = new BitmapImage();
                    all_news4ms = new MemoryStream(all_news[news4].get_photo());
                    all_news4ms.Position = 0;
                    all_news4.BeginInit();
                    all_news4.CacheOption = BitmapCacheOption.OnLoad;
                    all_news4.StreamSource = all_news4ms;
                    all_news4.EndInit();
                    // set properties of news
                    new4.Background = new ImageBrush(all_news4);
                    new4.Content = all_news[news4].get_id().ToString();
                    new4.FontSize = 0.1;

                    /////////////////////////////
                    news5 = 4;
                    all_news5 = new BitmapImage();
                    all_news5ms = new MemoryStream(all_news[news5].get_photo());
                    all_news5ms.Position = 0;
                    all_news5.BeginInit();
                    all_news5.CacheOption = BitmapCacheOption.OnLoad;
                    all_news5.StreamSource = all_news5ms;
                    all_news5.EndInit();
                    // set properties of news
                    new5.Background = new ImageBrush(all_news5);
                    new5.Content = all_news[news5].get_id().ToString();
                    new5.FontSize = 0.1;

                    /////////////////////////////
                    news6 = 5;
                    all_news6 = new BitmapImage();
                    all_news6ms = new MemoryStream(all_news[news6].get_photo());
                    all_news6ms.Position = 0;
                    all_news6.BeginInit();
                    all_news6.CacheOption = BitmapCacheOption.OnLoad;
                    all_news6.StreamSource = all_news6ms;
                    all_news6.EndInit();
                    // set properties of news
                    new6.Background = new ImageBrush(all_news6);
                    new6.Content = all_news[news6].get_id().ToString();
                    new6.FontSize = 0.1;

                    new1.Visibility = Visibility.Visible;
                    new2.Visibility = Visibility.Visible;
                    new3.Visibility = Visibility.Visible;
                    new4.Visibility = Visibility.Visible;
                    new5.Visibility = Visibility.Visible;
                    new6.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (ratecombox.SelectedItem.ToString() == "Top Rated")
                {
                    all_news = News.Sort_by_Rate_Descendingly(all_news);
                    if (all_news.Count == 1)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        ///
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Hidden;
                        new3.Visibility = Visibility.Hidden;
                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 2)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        ///
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;

                        new3.Visibility = Visibility.Hidden;
                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 3)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;

                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 4)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;

                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 5)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        news5 = 4;
                        all_news5 = new BitmapImage();
                        all_news5ms = new MemoryStream(all_news[news5].get_photo());
                        all_news5ms.Position = 0;
                        all_news5.BeginInit();
                        all_news5.CacheOption = BitmapCacheOption.OnLoad;
                        all_news5.StreamSource = all_news5ms;
                        all_news5.EndInit();
                        // set properties of news
                        new5.Background = new ImageBrush(all_news5);
                        new5.Content = all_news[news5].get_id().ToString();
                        new5.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;
                        new5.Visibility = Visibility.Visible;

                        new6.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        news5 = 4;
                        all_news5 = new BitmapImage();
                        all_news5ms = new MemoryStream(all_news[news5].get_photo());
                        all_news5ms.Position = 0;
                        all_news5.BeginInit();
                        all_news5.CacheOption = BitmapCacheOption.OnLoad;
                        all_news5.StreamSource = all_news5ms;
                        all_news5.EndInit();
                        // set properties of news
                        new5.Background = new ImageBrush(all_news5);
                        new5.Content = all_news[news5].get_id().ToString();
                        new5.FontSize = 0.1;

                        /////////////////////////////
                        news6 = 5;
                        all_news6 = new BitmapImage();
                        all_news6ms = new MemoryStream(all_news[news6].get_photo());
                        all_news6ms.Position = 0;
                        all_news6.BeginInit();
                        all_news6.CacheOption = BitmapCacheOption.OnLoad;
                        all_news6.StreamSource = all_news6ms;
                        all_news6.EndInit();
                        // set properties of news
                        new6.Background = new ImageBrush(all_news6);
                        new6.Content = all_news[news6].get_id().ToString();
                        new6.FontSize = 0.1;

                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;
                        new5.Visibility = Visibility.Visible;
                        new6.Visibility = Visibility.Visible;
                    }



                }
                else
                {
                    all_news = News.sort_rate_ascendingly(all_news);
                    if (all_news.Count == 1)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        ///
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Hidden;
                        new3.Visibility = Visibility.Hidden;
                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 2)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        ///
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;

                        new3.Visibility = Visibility.Hidden;
                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 3)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;

                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 4)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;

                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 5)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        news5 = 4;
                        all_news5 = new BitmapImage();
                        all_news5ms = new MemoryStream(all_news[news5].get_photo());
                        all_news5ms.Position = 0;
                        all_news5.BeginInit();
                        all_news5.CacheOption = BitmapCacheOption.OnLoad;
                        all_news5.StreamSource = all_news5ms;
                        all_news5.EndInit();
                        // set properties of news
                        new5.Background = new ImageBrush(all_news5);
                        new5.Content = all_news[news5].get_id().ToString();
                        new5.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;
                        new5.Visibility = Visibility.Visible;

                        new6.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        news5 = 4;
                        all_news5 = new BitmapImage();
                        all_news5ms = new MemoryStream(all_news[news5].get_photo());
                        all_news5ms.Position = 0;
                        all_news5.BeginInit();
                        all_news5.CacheOption = BitmapCacheOption.OnLoad;
                        all_news5.StreamSource = all_news5ms;
                        all_news5.EndInit();
                        // set properties of news
                        new5.Background = new ImageBrush(all_news5);
                        new5.Content = all_news[news5].get_id().ToString();
                        new5.FontSize = 0.1;

                        /////////////////////////////
                        news6 = 5;
                        all_news6 = new BitmapImage();
                        all_news6ms = new MemoryStream(all_news[news6].get_photo());
                        all_news6ms.Position = 0;
                        all_news6.BeginInit();
                        all_news6.CacheOption = BitmapCacheOption.OnLoad;
                        all_news6.StreamSource = all_news6ms;
                        all_news6.EndInit();
                        // set properties of news
                        new6.Background = new ImageBrush(all_news6);
                        new6.Content = all_news[news6].get_id().ToString();
                        new6.FontSize = 0.1;

                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;
                        new5.Visibility = Visibility.Visible;
                        new6.Visibility = Visibility.Visible;
                    }
                }

            }


        }

        private void ratecombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            all_news = News.GetDataNewss();
            if (catagorycombox.Text == "" || catagorycombox.Text == "All" )
            {
                if (ratecombox.SelectedItem == null)
                {
                    return;
                }
                if(ratecombox.SelectedItem.ToString()== "Top Rated")
                {
                    all_news = News.Sort_by_Rate_Descendingly(all_news);
                    if (all_news.Count == 1)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        ///
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Hidden;
                        new3.Visibility = Visibility.Hidden;
                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 2)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        ///
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;

                        new3.Visibility = Visibility.Hidden;
                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 3)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;

                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 4)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;

                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 5)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        news5 = 4;
                        all_news5 = new BitmapImage();
                        all_news5ms = new MemoryStream(all_news[news5].get_photo());
                        all_news5ms.Position = 0;
                        all_news5.BeginInit();
                        all_news5.CacheOption = BitmapCacheOption.OnLoad;
                        all_news5.StreamSource = all_news5ms;
                        all_news5.EndInit();
                        // set properties of news
                        new5.Background = new ImageBrush(all_news5);
                        new5.Content = all_news[news5].get_id().ToString();
                        new5.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;
                        new5.Visibility = Visibility.Visible;

                        new6.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        news5 = 4;
                        all_news5 = new BitmapImage();
                        all_news5ms = new MemoryStream(all_news[news5].get_photo());
                        all_news5ms.Position = 0;
                        all_news5.BeginInit();
                        all_news5.CacheOption = BitmapCacheOption.OnLoad;
                        all_news5.StreamSource = all_news5ms;
                        all_news5.EndInit();
                        // set properties of news
                        new5.Background = new ImageBrush(all_news5);
                        new5.Content = all_news[news5].get_id().ToString();
                        new5.FontSize = 0.1;

                        /////////////////////////////
                        news6 = 5;
                        all_news6 = new BitmapImage();
                        all_news6ms = new MemoryStream(all_news[news6].get_photo());
                        all_news6ms.Position = 0;
                        all_news6.BeginInit();
                        all_news6.CacheOption = BitmapCacheOption.OnLoad;
                        all_news6.StreamSource = all_news6ms;
                        all_news6.EndInit();
                        // set properties of news
                        new6.Background = new ImageBrush(all_news6);
                        new6.Content = all_news[news6].get_id().ToString();
                        new6.FontSize = 0.1;

                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;
                        new5.Visibility = Visibility.Visible;
                        new6.Visibility = Visibility.Visible;
                    }



                }
                else
                {
                    all_news = News.sort_rate_ascendingly(all_news);
                    if (all_news.Count == 1)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        ///
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Hidden;
                        new3.Visibility = Visibility.Hidden;
                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 2)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        ///
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;

                        new3.Visibility = Visibility.Hidden;
                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 3)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;

                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 4)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;

                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 5)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        news5 = 4;
                        all_news5 = new BitmapImage();
                        all_news5ms = new MemoryStream(all_news[news5].get_photo());
                        all_news5ms.Position = 0;
                        all_news5.BeginInit();
                        all_news5.CacheOption = BitmapCacheOption.OnLoad;
                        all_news5.StreamSource = all_news5ms;
                        all_news5.EndInit();
                        // set properties of news
                        new5.Background = new ImageBrush(all_news5);
                        new5.Content = all_news[news5].get_id().ToString();
                        new5.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;
                        new5.Visibility = Visibility.Visible;

                        new6.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        news5 = 4;
                        all_news5 = new BitmapImage();
                        all_news5ms = new MemoryStream(all_news[news5].get_photo());
                        all_news5ms.Position = 0;
                        all_news5.BeginInit();
                        all_news5.CacheOption = BitmapCacheOption.OnLoad;
                        all_news5.StreamSource = all_news5ms;
                        all_news5.EndInit();
                        // set properties of news
                        new5.Background = new ImageBrush(all_news5);
                        new5.Content = all_news[news5].get_id().ToString();
                        new5.FontSize = 0.1;

                        /////////////////////////////
                        news6 = 5;
                        all_news6 = new BitmapImage();
                        all_news6ms = new MemoryStream(all_news[news6].get_photo());
                        all_news6ms.Position = 0;
                        all_news6.BeginInit();
                        all_news6.CacheOption = BitmapCacheOption.OnLoad;
                        all_news6.StreamSource = all_news6ms;
                        all_news6.EndInit();
                        // set properties of news
                        new6.Background = new ImageBrush(all_news6);
                        new6.Content = all_news[news6].get_id().ToString();
                        new6.FontSize = 0.1;

                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;
                        new5.Visibility = Visibility.Visible;
                        new6.Visibility = Visibility.Visible;
                    }
                }

            }
            else
            {
                all_news = News.Filter_and_Sort_by_Category(all_news, catagorycombox.Text);

                if (ratecombox.SelectedItem.ToString() == "Top Rated")
                {
                    all_news = News.Sort_by_Rate_Descendingly(all_news);
                    if (all_news.Count == 1)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        ///
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Hidden;
                        new3.Visibility = Visibility.Hidden;
                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 2)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        ///
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;

                        new3.Visibility = Visibility.Hidden;
                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 3)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;

                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 4)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;

                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 5)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        news5 = 4;
                        all_news5 = new BitmapImage();
                        all_news5ms = new MemoryStream(all_news[news5].get_photo());
                        all_news5ms.Position = 0;
                        all_news5.BeginInit();
                        all_news5.CacheOption = BitmapCacheOption.OnLoad;
                        all_news5.StreamSource = all_news5ms;
                        all_news5.EndInit();
                        // set properties of news
                        new5.Background = new ImageBrush(all_news5);
                        new5.Content = all_news[news5].get_id().ToString();
                        new5.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;
                        new5.Visibility = Visibility.Visible;

                        new6.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        news5 = 4;
                        all_news5 = new BitmapImage();
                        all_news5ms = new MemoryStream(all_news[news5].get_photo());
                        all_news5ms.Position = 0;
                        all_news5.BeginInit();
                        all_news5.CacheOption = BitmapCacheOption.OnLoad;
                        all_news5.StreamSource = all_news5ms;
                        all_news5.EndInit();
                        // set properties of news
                        new5.Background = new ImageBrush(all_news5);
                        new5.Content = all_news[news5].get_id().ToString();
                        new5.FontSize = 0.1;

                        /////////////////////////////
                        news6 = 5;
                        all_news6 = new BitmapImage();
                        all_news6ms = new MemoryStream(all_news[news6].get_photo());
                        all_news6ms.Position = 0;
                        all_news6.BeginInit();
                        all_news6.CacheOption = BitmapCacheOption.OnLoad;
                        all_news6.StreamSource = all_news6ms;
                        all_news6.EndInit();
                        // set properties of news
                        new6.Background = new ImageBrush(all_news6);
                        new6.Content = all_news[news6].get_id().ToString();
                        new6.FontSize = 0.1;

                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;
                        new5.Visibility = Visibility.Visible;
                        new6.Visibility = Visibility.Visible;
                    }

                }
                else
                {
                    all_news = News.sort_rate_ascendingly(all_news);
                    if (all_news.Count == 1)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        ///
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Hidden;
                        new3.Visibility = Visibility.Hidden;
                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 2)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        ///
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;

                        new3.Visibility = Visibility.Hidden;
                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 3)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;

                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 4)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;

                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 5)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        news5 = 4;
                        all_news5 = new BitmapImage();
                        all_news5ms = new MemoryStream(all_news[news5].get_photo());
                        all_news5ms.Position = 0;
                        all_news5.BeginInit();
                        all_news5.CacheOption = BitmapCacheOption.OnLoad;
                        all_news5.StreamSource = all_news5ms;
                        all_news5.EndInit();
                        // set properties of news
                        new5.Background = new ImageBrush(all_news5);
                        new5.Content = all_news[news5].get_id().ToString();
                        new5.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;
                        new5.Visibility = Visibility.Visible;

                        new6.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        news5 = 4;
                        all_news5 = new BitmapImage();
                        all_news5ms = new MemoryStream(all_news[news5].get_photo());
                        all_news5ms.Position = 0;
                        all_news5.BeginInit();
                        all_news5.CacheOption = BitmapCacheOption.OnLoad;
                        all_news5.StreamSource = all_news5ms;
                        all_news5.EndInit();
                        // set properties of news
                        new5.Background = new ImageBrush(all_news5);
                        new5.Content = all_news[news5].get_id().ToString();
                        new5.FontSize = 0.1;

                        /////////////////////////////
                        news6 = 5;
                        all_news6 = new BitmapImage();
                        all_news6ms = new MemoryStream(all_news[news6].get_photo());
                        all_news6ms.Position = 0;
                        all_news6.BeginInit();
                        all_news6.CacheOption = BitmapCacheOption.OnLoad;
                        all_news6.StreamSource = all_news6ms;
                        all_news6.EndInit();
                        // set properties of news
                        new6.Background = new ImageBrush(all_news6);
                        new6.Content = all_news[news6].get_id().ToString();
                        new6.FontSize = 0.1;

                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;
                        new5.Visibility = Visibility.Visible;
                        new6.Visibility = Visibility.Visible;
                    }

                }

            }

           

        }

        private void search_txt_KeyDown(object sender, KeyEventArgs e)
        {

            if (search_txt.Text == "SEARCH...")
            {
                return;
            }
            else if (search_txt.Text == "")
            {
                if (e.Key == Key.Enter)
                {
                    catagorycombox.Text = "";
                    ratecombox.Text = "";
                    all_news = News.GetDataNewss();
                    if (all_news.Count == 1)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        ///
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Hidden;
                        new3.Visibility = Visibility.Hidden;
                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 2)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        ///
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;

                        new3.Visibility = Visibility.Hidden;
                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 3)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;

                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 4)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;

                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                    }
                    else if (all_news.Count == 5)
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        news5 = 4;
                        all_news5 = new BitmapImage();
                        all_news5ms = new MemoryStream(all_news[news5].get_photo());
                        all_news5ms.Position = 0;
                        all_news5.BeginInit();
                        all_news5.CacheOption = BitmapCacheOption.OnLoad;
                        all_news5.StreamSource = all_news5ms;
                        all_news5.EndInit();
                        // set properties of news
                        new5.Background = new ImageBrush(all_news5);
                        new5.Content = all_news[news5].get_id().ToString();
                        new5.FontSize = 0.1;

                        /////////////////////////////
                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;
                        new5.Visibility = Visibility.Visible;

                        new6.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        news1 = 0;
                        all_news1 = new BitmapImage();
                        all_news1ms = new MemoryStream(all_news[news1].get_photo());
                        all_news1ms.Position = 0;
                        all_news1.BeginInit();
                        all_news1.CacheOption = BitmapCacheOption.OnLoad;
                        all_news1.StreamSource = all_news1ms;
                        all_news1.EndInit();
                        // set properties of news
                        new1.Background = new ImageBrush(all_news1);
                        new1.Content = all_news[news1].get_id().ToString();
                        new1.FontSize = 0.1;

                        /////////////////////////////
                        news2 = 1;
                        all_news2 = new BitmapImage();
                        all_news2ms = new MemoryStream(all_news[news2].get_photo());
                        all_news2ms.Position = 0;
                        all_news2.BeginInit();
                        all_news2.CacheOption = BitmapCacheOption.OnLoad;
                        all_news2.StreamSource = all_news2ms;
                        all_news2.EndInit();
                        // set properties of news
                        new2.Background = new ImageBrush(all_news2);
                        new2.Content = all_news[news2].get_id().ToString();
                        new2.FontSize = 0.1;

                        /////////////////////////////
                        news3 = 2;
                        all_news3 = new BitmapImage();
                        all_news3ms = new MemoryStream(all_news[news3].get_photo());
                        all_news3ms.Position = 0;
                        all_news3.BeginInit();
                        all_news3.CacheOption = BitmapCacheOption.OnLoad;
                        all_news3.StreamSource = all_news3ms;
                        all_news3.EndInit();
                        // set properties of news
                        new3.Background = new ImageBrush(all_news3);
                        new3.Content = all_news[news3].get_id().ToString();
                        new3.FontSize = 0.1;

                        /////////////////////////////
                        news4 = 3;
                        all_news4 = new BitmapImage();
                        all_news4ms = new MemoryStream(all_news[news4].get_photo());
                        all_news4ms.Position = 0;
                        all_news4.BeginInit();
                        all_news4.CacheOption = BitmapCacheOption.OnLoad;
                        all_news4.StreamSource = all_news4ms;
                        all_news4.EndInit();
                        // set properties of news
                        new4.Background = new ImageBrush(all_news4);
                        new4.Content = all_news[news4].get_id().ToString();
                        new4.FontSize = 0.1;

                        /////////////////////////////
                        news5 = 4;
                        all_news5 = new BitmapImage();
                        all_news5ms = new MemoryStream(all_news[news5].get_photo());
                        all_news5ms.Position = 0;
                        all_news5.BeginInit();
                        all_news5.CacheOption = BitmapCacheOption.OnLoad;
                        all_news5.StreamSource = all_news5ms;
                        all_news5.EndInit();
                        // set properties of news
                        new5.Background = new ImageBrush(all_news5);
                        new5.Content = all_news[news5].get_id().ToString();
                        new5.FontSize = 0.1;

                        /////////////////////////////
                        news6 = 5;
                        all_news6 = new BitmapImage();
                        all_news6ms = new MemoryStream(all_news[news6].get_photo());
                        all_news6ms.Position = 0;
                        all_news6.BeginInit();
                        all_news6.CacheOption = BitmapCacheOption.OnLoad;
                        all_news6.StreamSource = all_news6ms;
                        all_news6.EndInit();
                        // set properties of news
                        new6.Background = new ImageBrush(all_news6);
                        new6.Content = all_news[news6].get_id().ToString();
                        new6.FontSize = 0.1;

                        new1.Visibility = Visibility.Visible;
                        new2.Visibility = Visibility.Visible;
                        new3.Visibility = Visibility.Visible;
                        new4.Visibility = Visibility.Visible;
                        new5.Visibility = Visibility.Visible;
                        new6.Visibility = Visibility.Visible;
                    }



                }
            }
            else
            {

                catagorycombox.Text = "";
                ratecombox.Text = "";
                if (e.Key == Key.Enter)
                {
                    all_news = News.GetDataNewss();
                    all_news = News.Display_based_on_specific_title(all_news, search_txt.Text);
                    if (all_news.Count == 0)
                    {
                        new1.Visibility = Visibility.Hidden;
                        new2.Visibility = Visibility.Hidden;
                        new3.Visibility = Visibility.Hidden;
                        new4.Visibility = Visibility.Hidden;
                        new5.Visibility = Visibility.Hidden;
                        new6.Visibility = Visibility.Hidden;
                        MessageBox.Show("No News With that title");

                    }
                    else
                    {
                        if (all_news.Count == 1)
                        {
                            news1 = 0;
                            all_news1 = new BitmapImage();
                            all_news1ms = new MemoryStream(all_news[news1].get_photo());
                            all_news1ms.Position = 0;
                            all_news1.BeginInit();
                            all_news1.CacheOption = BitmapCacheOption.OnLoad;
                            all_news1.StreamSource = all_news1ms;
                            all_news1.EndInit();
                            // set properties of news
                            new1.Background = new ImageBrush(all_news1);
                            new1.Content = all_news[news1].get_id().ToString();
                            new1.FontSize = 0.1;

                            /////////////////////////////
                            ///
                            new1.Visibility = Visibility.Visible;
                            new2.Visibility = Visibility.Hidden;
                            new3.Visibility = Visibility.Hidden;
                            new4.Visibility = Visibility.Hidden;
                            new5.Visibility = Visibility.Hidden;
                            new6.Visibility = Visibility.Hidden;
                        }
                        else if (all_news.Count == 2)
                        {
                            news1 = 0;
                            all_news1 = new BitmapImage();
                            all_news1ms = new MemoryStream(all_news[news1].get_photo());
                            all_news1ms.Position = 0;
                            all_news1.BeginInit();
                            all_news1.CacheOption = BitmapCacheOption.OnLoad;
                            all_news1.StreamSource = all_news1ms;
                            all_news1.EndInit();
                            // set properties of news
                            new1.Background = new ImageBrush(all_news1);
                            new1.Content = all_news[news1].get_id().ToString();
                            new1.FontSize = 0.1;

                            /////////////////////////////
                            news2 = 1;
                            all_news2 = new BitmapImage();
                            all_news2ms = new MemoryStream(all_news[news2].get_photo());
                            all_news2ms.Position = 0;
                            all_news2.BeginInit();
                            all_news2.CacheOption = BitmapCacheOption.OnLoad;
                            all_news2.StreamSource = all_news2ms;
                            all_news2.EndInit();
                            // set properties of news
                            new2.Background = new ImageBrush(all_news2);
                            new2.Content = all_news[news2].get_id().ToString();
                            new2.FontSize = 0.1;

                            /////////////////////////////
                            ///
                            new1.Visibility = Visibility.Visible;
                            new2.Visibility = Visibility.Visible;

                            new3.Visibility = Visibility.Hidden;
                            new4.Visibility = Visibility.Hidden;
                            new5.Visibility = Visibility.Hidden;
                            new6.Visibility = Visibility.Hidden;
                        }
                        else if (all_news.Count == 3)
                        {
                            news1 = 0;
                            all_news1 = new BitmapImage();
                            all_news1ms = new MemoryStream(all_news[news1].get_photo());
                            all_news1ms.Position = 0;
                            all_news1.BeginInit();
                            all_news1.CacheOption = BitmapCacheOption.OnLoad;
                            all_news1.StreamSource = all_news1ms;
                            all_news1.EndInit();
                            // set properties of news
                            new1.Background = new ImageBrush(all_news1);
                            new1.Content = all_news[news1].get_id().ToString();
                            new1.FontSize = 0.1;

                            /////////////////////////////
                            news2 = 1;
                            all_news2 = new BitmapImage();
                            all_news2ms = new MemoryStream(all_news[news2].get_photo());
                            all_news2ms.Position = 0;
                            all_news2.BeginInit();
                            all_news2.CacheOption = BitmapCacheOption.OnLoad;
                            all_news2.StreamSource = all_news2ms;
                            all_news2.EndInit();
                            // set properties of news
                            new2.Background = new ImageBrush(all_news2);
                            new2.Content = all_news[news2].get_id().ToString();
                            new2.FontSize = 0.1;

                            /////////////////////////////
                            news3 = 2;
                            all_news3 = new BitmapImage();
                            all_news3ms = new MemoryStream(all_news[news3].get_photo());
                            all_news3ms.Position = 0;
                            all_news3.BeginInit();
                            all_news3.CacheOption = BitmapCacheOption.OnLoad;
                            all_news3.StreamSource = all_news3ms;
                            all_news3.EndInit();
                            // set properties of news
                            new3.Background = new ImageBrush(all_news3);
                            new3.Content = all_news[news3].get_id().ToString();
                            new3.FontSize = 0.1;

                            /////////////////////////////
                            new1.Visibility = Visibility.Visible;
                            new2.Visibility = Visibility.Visible;
                            new3.Visibility = Visibility.Visible;

                            new4.Visibility = Visibility.Hidden;
                            new5.Visibility = Visibility.Hidden;
                            new6.Visibility = Visibility.Hidden;
                        }
                        else if (all_news.Count == 4)
                        {
                            news1 = 0;
                            all_news1 = new BitmapImage();
                            all_news1ms = new MemoryStream(all_news[news1].get_photo());
                            all_news1ms.Position = 0;
                            all_news1.BeginInit();
                            all_news1.CacheOption = BitmapCacheOption.OnLoad;
                            all_news1.StreamSource = all_news1ms;
                            all_news1.EndInit();
                            // set properties of news
                            new1.Background = new ImageBrush(all_news1);
                            new1.Content = all_news[news1].get_id().ToString();
                            new1.FontSize = 0.1;

                            /////////////////////////////
                            news2 = 1;
                            all_news2 = new BitmapImage();
                            all_news2ms = new MemoryStream(all_news[news2].get_photo());
                            all_news2ms.Position = 0;
                            all_news2.BeginInit();
                            all_news2.CacheOption = BitmapCacheOption.OnLoad;
                            all_news2.StreamSource = all_news2ms;
                            all_news2.EndInit();
                            // set properties of news
                            new2.Background = new ImageBrush(all_news2);
                            new2.Content = all_news[news2].get_id().ToString();
                            new2.FontSize = 0.1;

                            /////////////////////////////
                            news3 = 2;
                            all_news3 = new BitmapImage();
                            all_news3ms = new MemoryStream(all_news[news3].get_photo());
                            all_news3ms.Position = 0;
                            all_news3.BeginInit();
                            all_news3.CacheOption = BitmapCacheOption.OnLoad;
                            all_news3.StreamSource = all_news3ms;
                            all_news3.EndInit();
                            // set properties of news
                            new3.Background = new ImageBrush(all_news3);
                            new3.Content = all_news[news3].get_id().ToString();
                            new3.FontSize = 0.1;

                            /////////////////////////////
                            news4 = 3;
                            all_news4 = new BitmapImage();
                            all_news4ms = new MemoryStream(all_news[news4].get_photo());
                            all_news4ms.Position = 0;
                            all_news4.BeginInit();
                            all_news4.CacheOption = BitmapCacheOption.OnLoad;
                            all_news4.StreamSource = all_news4ms;
                            all_news4.EndInit();
                            // set properties of news
                            new4.Background = new ImageBrush(all_news4);
                            new4.Content = all_news[news4].get_id().ToString();
                            new4.FontSize = 0.1;

                            /////////////////////////////
                            new1.Visibility = Visibility.Visible;
                            new2.Visibility = Visibility.Visible;
                            new3.Visibility = Visibility.Visible;
                            new4.Visibility = Visibility.Visible;

                            new5.Visibility = Visibility.Hidden;
                            new6.Visibility = Visibility.Hidden;
                        }
                        else if (all_news.Count == 5)
                        {
                            news1 = 0;
                            all_news1 = new BitmapImage();
                            all_news1ms = new MemoryStream(all_news[news1].get_photo());
                            all_news1ms.Position = 0;
                            all_news1.BeginInit();
                            all_news1.CacheOption = BitmapCacheOption.OnLoad;
                            all_news1.StreamSource = all_news1ms;
                            all_news1.EndInit();
                            // set properties of news
                            new1.Background = new ImageBrush(all_news1);
                            new1.Content = all_news[news1].get_id().ToString();
                            new1.FontSize = 0.1;

                            /////////////////////////////
                            news2 = 1;
                            all_news2 = new BitmapImage();
                            all_news2ms = new MemoryStream(all_news[news2].get_photo());
                            all_news2ms.Position = 0;
                            all_news2.BeginInit();
                            all_news2.CacheOption = BitmapCacheOption.OnLoad;
                            all_news2.StreamSource = all_news2ms;
                            all_news2.EndInit();
                            // set properties of news
                            new2.Background = new ImageBrush(all_news2);
                            new2.Content = all_news[news2].get_id().ToString();
                            new2.FontSize = 0.1;

                            /////////////////////////////
                            news3 = 2;
                            all_news3 = new BitmapImage();
                            all_news3ms = new MemoryStream(all_news[news3].get_photo());
                            all_news3ms.Position = 0;
                            all_news3.BeginInit();
                            all_news3.CacheOption = BitmapCacheOption.OnLoad;
                            all_news3.StreamSource = all_news3ms;
                            all_news3.EndInit();
                            // set properties of news
                            new3.Background = new ImageBrush(all_news3);
                            new3.Content = all_news[news3].get_id().ToString();
                            new3.FontSize = 0.1;

                            /////////////////////////////
                            news4 = 3;
                            all_news4 = new BitmapImage();
                            all_news4ms = new MemoryStream(all_news[news4].get_photo());
                            all_news4ms.Position = 0;
                            all_news4.BeginInit();
                            all_news4.CacheOption = BitmapCacheOption.OnLoad;
                            all_news4.StreamSource = all_news4ms;
                            all_news4.EndInit();
                            // set properties of news
                            new4.Background = new ImageBrush(all_news4);
                            new4.Content = all_news[news4].get_id().ToString();
                            new4.FontSize = 0.1;

                            /////////////////////////////
                            news5 = 4;
                            all_news5 = new BitmapImage();
                            all_news5ms = new MemoryStream(all_news[news5].get_photo());
                            all_news5ms.Position = 0;
                            all_news5.BeginInit();
                            all_news5.CacheOption = BitmapCacheOption.OnLoad;
                            all_news5.StreamSource = all_news5ms;
                            all_news5.EndInit();
                            // set properties of news
                            new5.Background = new ImageBrush(all_news5);
                            new5.Content = all_news[news5].get_id().ToString();
                            new5.FontSize = 0.1;

                            /////////////////////////////
                            new1.Visibility = Visibility.Visible;
                            new2.Visibility = Visibility.Visible;
                            new3.Visibility = Visibility.Visible;
                            new4.Visibility = Visibility.Visible;
                            new5.Visibility = Visibility.Visible;

                            new6.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            news1 = 0;
                            all_news1 = new BitmapImage();
                            all_news1ms = new MemoryStream(all_news[news1].get_photo());
                            all_news1ms.Position = 0;
                            all_news1.BeginInit();
                            all_news1.CacheOption = BitmapCacheOption.OnLoad;
                            all_news1.StreamSource = all_news1ms;
                            all_news1.EndInit();
                            // set properties of news
                            new1.Background = new ImageBrush(all_news1);
                            new1.Content = all_news[news1].get_id().ToString();
                            new1.FontSize = 0.1;

                            /////////////////////////////
                            news2 = 1;
                            all_news2 = new BitmapImage();
                            all_news2ms = new MemoryStream(all_news[news2].get_photo());
                            all_news2ms.Position = 0;
                            all_news2.BeginInit();
                            all_news2.CacheOption = BitmapCacheOption.OnLoad;
                            all_news2.StreamSource = all_news2ms;
                            all_news2.EndInit();
                            // set properties of news
                            new2.Background = new ImageBrush(all_news2);
                            new2.Content = all_news[news2].get_id().ToString();
                            new2.FontSize = 0.1;

                            /////////////////////////////
                            news3 = 2;
                            all_news3 = new BitmapImage();
                            all_news3ms = new MemoryStream(all_news[news3].get_photo());
                            all_news3ms.Position = 0;
                            all_news3.BeginInit();
                            all_news3.CacheOption = BitmapCacheOption.OnLoad;
                            all_news3.StreamSource = all_news3ms;
                            all_news3.EndInit();
                            // set properties of news
                            new3.Background = new ImageBrush(all_news3);
                            new3.Content = all_news[news3].get_id().ToString();
                            new3.FontSize = 0.1;

                            /////////////////////////////
                            news4 = 3;
                            all_news4 = new BitmapImage();
                            all_news4ms = new MemoryStream(all_news[news4].get_photo());
                            all_news4ms.Position = 0;
                            all_news4.BeginInit();
                            all_news4.CacheOption = BitmapCacheOption.OnLoad;
                            all_news4.StreamSource = all_news4ms;
                            all_news4.EndInit();
                            // set properties of news
                            new4.Background = new ImageBrush(all_news4);
                            new4.Content = all_news[news4].get_id().ToString();
                            new4.FontSize = 0.1;

                            /////////////////////////////
                            news5 = 4;
                            all_news5 = new BitmapImage();
                            all_news5ms = new MemoryStream(all_news[news5].get_photo());
                            all_news5ms.Position = 0;
                            all_news5.BeginInit();
                            all_news5.CacheOption = BitmapCacheOption.OnLoad;
                            all_news5.StreamSource = all_news5ms;
                            all_news5.EndInit();
                            // set properties of news
                            new5.Background = new ImageBrush(all_news5);
                            new5.Content = all_news[news5].get_id().ToString();
                            new5.FontSize = 0.1;

                            /////////////////////////////
                            news6 = 5;
                            all_news6 = new BitmapImage();
                            all_news6ms = new MemoryStream(all_news[news6].get_photo());
                            all_news6ms.Position = 0;
                            all_news6.BeginInit();
                            all_news6.CacheOption = BitmapCacheOption.OnLoad;
                            all_news6.StreamSource = all_news6ms;
                            all_news6.EndInit();
                            // set properties of news
                            new6.Background = new ImageBrush(all_news6);
                            new6.Content = all_news[news6].get_id().ToString();
                            new6.FontSize = 0.1;

                            new1.Visibility = Visibility.Visible;
                            new2.Visibility = Visibility.Visible;
                            new3.Visibility = Visibility.Visible;
                            new4.Visibility = Visibility.Visible;
                            new5.Visibility = Visibility.Visible;
                            new6.Visibility = Visibility.Visible;
                        }


                    }
                }
            }

            }

        private void UpdateRight_btn_Click(object sender, RoutedEventArgs e)
        {
            if (news1 >= all_news.Count - 1 || news2 >= all_news.Count - 1 || news3 >= all_news.Count - 1 || news4 >= all_news.Count - 1 || news5 >= all_news.Count - 1 || news6 >= all_news.Count - 1)
            {
                return;
            }
            else
            {
                news1 += 6;
                news2 += 6;
                news3 += 6;
                news4 += 6;
                news5 += 6;
                news6 += 6;

                if (news6 < all_news.Count)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    Updatenew1.Background = new ImageBrush(all_news1);
                    Updatenew1.Content = all_news[news1].get_id().ToString();
                    Updatenew1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    Updatenew2.Background = new ImageBrush(all_news2);
                    Updatenew2.Content = all_news[news2].get_id().ToString();
                    Updatenew2.FontSize = 0.1;

                    /////////////////////////////
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    Updatenew3.Background = new ImageBrush(all_news3);
                    Updatenew3.Content = all_news[news3].get_id().ToString();
                    Updatenew3.FontSize = 0.1;

                    /////////////////////////////
                    all_news4 = new BitmapImage();
                    all_news4ms = new MemoryStream(all_news[news4].get_photo());
                    all_news4ms.Position = 0;
                    all_news4.BeginInit();
                    all_news4.CacheOption = BitmapCacheOption.OnLoad;
                    all_news4.StreamSource = all_news4ms;
                    all_news4.EndInit();
                    // set properties of news
                    Updatenew4.Background = new ImageBrush(all_news4);
                    Updatenew4.Content = all_news[news4].get_id().ToString();
                    Updatenew4.FontSize = 0.1;

                    /////////////////////////////
                    all_news5 = new BitmapImage();
                    all_news5ms = new MemoryStream(all_news[news5].get_photo());
                    all_news5ms.Position = 0;
                    all_news5.BeginInit();
                    all_news5.CacheOption = BitmapCacheOption.OnLoad;
                    all_news5.StreamSource = all_news5ms;
                    all_news5.EndInit();
                    // set properties of news
                    Updatenew5.Background = new ImageBrush(all_news5);
                    Updatenew5.Content = all_news[news5].get_id().ToString();
                    Updatenew5.FontSize = 0.1;

                    /////////////////////////////
                    all_news6 = new BitmapImage();
                    all_news6ms = new MemoryStream(all_news[news6].get_photo());
                    all_news6ms.Position = 0;
                    all_news6.BeginInit();
                    all_news6.CacheOption = BitmapCacheOption.OnLoad;
                    all_news6.StreamSource = all_news6ms;
                    all_news6.EndInit();
                    // set properties of news
                    Updatenew6.Background = new ImageBrush(all_news6);
                    Updatenew6.Content = all_news[news6].get_id().ToString();
                    Updatenew6.FontSize = 0.1;

                    Updatenew1.Visibility=Visibility.Visible;
                    Updatenew2.Visibility=Visibility.Visible;
                    Updatenew3.Visibility=Visibility.Visible;
                    Updatenew4.Visibility=Visibility.Visible;
                    Updatenew5.Visibility=Visibility.Visible;
                    Updatenew6.Visibility = Visibility.Visible;

                }
                else if (news5 < all_news.Count)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    Updatenew1.Background = new ImageBrush(all_news1);
                    Updatenew1.Content = all_news[news1].get_id().ToString();
                    Updatenew1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    Updatenew2.Background = new ImageBrush(all_news2);
                    Updatenew2.Content = all_news[news2].get_id().ToString();
                    Updatenew2.FontSize = 0.1;

                    /////////////////////////////
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    Updatenew3.Background = new ImageBrush(all_news3);
                    Updatenew3.Content = all_news[news3].get_id().ToString();
                    Updatenew3.FontSize = 0.1;

                    /////////////////////////////
                    all_news4 = new BitmapImage();
                    all_news4ms = new MemoryStream(all_news[news4].get_photo());
                    all_news4ms.Position = 0;
                    all_news4.BeginInit();
                    all_news4.CacheOption = BitmapCacheOption.OnLoad;
                    all_news4.StreamSource = all_news4ms;
                    all_news4.EndInit();
                    // set properties of news
                    Updatenew4.Background = new ImageBrush(all_news4);
                    Updatenew4.Content = all_news[news4].get_id().ToString();
                    Updatenew4.FontSize = 0.1;

                    /////////////////////////////
                    all_news5 = new BitmapImage();
                    all_news5ms = new MemoryStream(all_news[news5].get_photo());
                    all_news5ms.Position = 0;
                    all_news5.BeginInit();
                    all_news5.CacheOption = BitmapCacheOption.OnLoad;
                    all_news5.StreamSource = all_news5ms;
                    all_news5.EndInit();
                    // set properties of news
                    Updatenew5.Background = new ImageBrush(all_news5);
                    Updatenew5.Content = all_news[news5].get_id().ToString();
                    Updatenew5.FontSize = 0.1;
                    Updatenew1.Visibility = Visibility.Visible;
                    Updatenew2.Visibility = Visibility.Visible;
                    Updatenew3.Visibility = Visibility.Visible;
                    Updatenew4.Visibility = Visibility.Visible;
                    Updatenew5.Visibility = Visibility.Visible;
                
                    Updatenew6.Visibility = Visibility.Hidden;
                    
                }
                else if (news4 < all_news.Count)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    Updatenew1.Background = new ImageBrush(all_news1);
                    Updatenew1.Content = all_news[news1].get_id().ToString();
                    Updatenew1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    Updatenew2.Background = new ImageBrush(all_news2);
                    Updatenew2.Content = all_news[news2].get_id().ToString();
                    Updatenew2.FontSize = 0.1;

                    /////////////////////////////
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    Updatenew3.Background = new ImageBrush(all_news3);
                    Updatenew3.Content = all_news[news3].get_id().ToString();
                    Updatenew3.FontSize = 0.1;

                    /////////////////////////////
                    all_news4 = new BitmapImage();
                    all_news4ms = new MemoryStream(all_news[news4].get_photo());
                    all_news4ms.Position = 0;
                    all_news4.BeginInit();
                    all_news4.CacheOption = BitmapCacheOption.OnLoad;
                    all_news4.StreamSource = all_news4ms;
                    all_news4.EndInit();
                    // set properties of news
                    Updatenew4.Background = new ImageBrush(all_news4);
                    Updatenew4.Content = all_news[news4].get_id().ToString();
                    Updatenew4.FontSize = 0.1;

                    /////////////////////////////
                    ///
                    Updatenew1.Visibility = Visibility.Visible;
                    Updatenew2.Visibility = Visibility.Visible;
                    Updatenew3.Visibility = Visibility.Visible;
                    Updatenew4.Visibility = Visibility.Visible;
                  
                    Updatenew5.Visibility = Visibility.Hidden;
                    Updatenew6.Visibility = Visibility.Hidden;
                    
                }
                else if (news3 < all_news.Count)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    Updatenew1.Background = new ImageBrush(all_news1);
                    Updatenew1.Content = all_news[news1].get_id().ToString();
                    Updatenew1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    Updatenew2.Background = new ImageBrush(all_news2);
                    Updatenew2.Content = all_news[news2].get_id().ToString();
                    Updatenew2.FontSize = 0.1;

                    /////////////////////////////
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    Updatenew3.Background = new ImageBrush(all_news3);
                    Updatenew3.Content = all_news[news3].get_id().ToString();
                    Updatenew3.FontSize = 0.1;

                    /////////////////////////////
                    ///
                    Updatenew1.Visibility = Visibility.Visible;
                    Updatenew2.Visibility = Visibility.Visible;
                    Updatenew3.Visibility = Visibility.Visible;
                  
                    Updatenew4.Visibility = Visibility.Hidden;
                    Updatenew5.Visibility = Visibility.Hidden;
                    Updatenew6.Visibility = Visibility.Hidden;

                }
                else if (news2 < all_news.Count)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    Updatenew1.Background = new ImageBrush(all_news1);
                    Updatenew1.Content = all_news[news1].get_id().ToString();
                    Updatenew1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    Updatenew2.Background = new ImageBrush(all_news2);
                    Updatenew2.Content = all_news[news2].get_id().ToString();
                    Updatenew2.FontSize = 0.1;

                    /////////////////////////////
                    ///
                    Updatenew1.Visibility = Visibility.Visible;
                    Updatenew2.Visibility = Visibility.Visible;
                
                    Updatenew3.Visibility = Visibility.Hidden;
                    Updatenew4.Visibility = Visibility.Hidden;
                    Updatenew5.Visibility = Visibility.Hidden;
                    Updatenew6.Visibility = Visibility.Hidden;
                }   
                else if (news1 < all_news.Count)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    Updatenew1.Background = new ImageBrush(all_news1);
                    Updatenew1.Content = all_news[news1].get_id().ToString();
                    Updatenew1.FontSize = 0.1;
                    Updatenew1.Visibility = Visibility.Visible;
            
                    Updatenew2.Visibility = Visibility.Hidden;
                    Updatenew3.Visibility = Visibility.Hidden;
                    Updatenew4.Visibility = Visibility.Hidden;
                    Updatenew5.Visibility = Visibility.Hidden;
                    Updatenew6.Visibility = Visibility.Hidden;
                    
                }
                else
                {
                    return;
                }

            }

        }

        private void UpdateLeft_btn_Click(object sender, RoutedEventArgs e)
        {
            if (news1 <= 0 || news2 <= 0 || news3 <= 0 || news4 <= 0 || news5 <= 0 || news6 <= 0)
            {
                return;
            }
            else
            {
                news1 -= 6;
                news2 -= 6;
                news3 -= 6;
                news4 -= 6;
                news5 -= 6;
                news6 -= 6;


                if (news1 >= 0)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    Updatenew1.Background = new ImageBrush(all_news1);
                    Updatenew1.Content = all_news[news1].get_id().ToString();
                    Updatenew1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    Updatenew2.Background = new ImageBrush(all_news2);
                    Updatenew2.Content = all_news[news2].get_id().ToString();
                    Updatenew2.FontSize = 0.1;

                    /////////////////////////////
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    Updatenew3.Background = new ImageBrush(all_news3);
                    Updatenew3.Content = all_news[news3].get_id().ToString();
                    Updatenew3.FontSize = 0.1;

                    /////////////////////////////
                    all_news4 = new BitmapImage();
                    all_news4ms = new MemoryStream(all_news[news4].get_photo());
                    all_news4ms.Position = 0;
                    all_news4.BeginInit();
                    all_news4.CacheOption = BitmapCacheOption.OnLoad;
                    all_news4.StreamSource = all_news4ms;
                    all_news4.EndInit();
                    // set properties of news
                    Updatenew4.Background = new ImageBrush(all_news4);
                    Updatenew4.Content = all_news[news4].get_id().ToString();
                    Updatenew4.FontSize = 0.1;

                    /////////////////////////////
                    all_news5 = new BitmapImage();
                    all_news5ms = new MemoryStream(all_news[news5].get_photo());
                    all_news5ms.Position = 0;
                    all_news5.BeginInit();
                    all_news5.CacheOption = BitmapCacheOption.OnLoad;
                    all_news5.StreamSource = all_news5ms;
                    all_news5.EndInit();
                    // set properties of news
                    Updatenew5.Background = new ImageBrush(all_news5);
                    Updatenew5.Content = all_news[news5].get_id().ToString();
                    Updatenew5.FontSize = 0.1;

                    /////////////////////////////
                    all_news6 = new BitmapImage();
                    all_news6ms = new MemoryStream(all_news[news6].get_photo());
                    all_news6ms.Position = 0;
                    all_news6.BeginInit();
                    all_news6.CacheOption = BitmapCacheOption.OnLoad;
                    all_news6.StreamSource = all_news6ms;
                    all_news6.EndInit();
                    // set properties of news
                    Updatenew6.Background = new ImageBrush(all_news6);
                    Updatenew6.Content = all_news[news6].get_id().ToString();
                    Updatenew6.FontSize = 0.1;

                    Updatenew1.Visibility = Visibility.Visible;
                    Updatenew2.Visibility = Visibility.Visible;
                    Updatenew3.Visibility = Visibility.Visible;
                    Updatenew4.Visibility = Visibility.Visible;
                    Updatenew5.Visibility = Visibility.Visible;
                    Updatenew6.Visibility = Visibility.Visible;


                }
                else if (news2 >= 0)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    Updatenew1.Background = new ImageBrush(all_news1);
                    Updatenew1.Content = all_news[news1].get_id().ToString();
                    Updatenew1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    Updatenew2.Background = new ImageBrush(all_news2);
                    Updatenew2.Content = all_news[news2].get_id().ToString();
                    Updatenew2.FontSize = 0.1;

                    /////////////////////////////
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    Updatenew3.Background = new ImageBrush(all_news3);
                    Updatenew3.Content = all_news[news3].get_id().ToString();
                    Updatenew3.FontSize = 0.1;

                    /////////////////////////////
                    all_news4 = new BitmapImage();
                    all_news4ms = new MemoryStream(all_news[news4].get_photo());
                    all_news4ms.Position = 0;
                    all_news4.BeginInit();
                    all_news4.CacheOption = BitmapCacheOption.OnLoad;
                    all_news4.StreamSource = all_news4ms;
                    all_news4.EndInit();
                    // set properties of news
                    Updatenew4.Background = new ImageBrush(all_news4);
                    Updatenew4.Content = all_news[news4].get_id().ToString();
                    Updatenew4.FontSize = 0.1;

                    /////////////////////////////
                    all_news5 = new BitmapImage();
                    all_news5ms = new MemoryStream(all_news[news5].get_photo());
                    all_news5ms.Position = 0;
                    all_news5.BeginInit();
                    all_news5.CacheOption = BitmapCacheOption.OnLoad;
                    all_news5.StreamSource = all_news5ms;
                    all_news5.EndInit();
                    // set properties of news
                    Updatenew5.Background = new ImageBrush(all_news5);
                    Updatenew5.Content = all_news[news5].get_id().ToString();
                    Updatenew5.FontSize = 0.1;

                    Updatenew1.Visibility = Visibility.Visible;
                    Updatenew2.Visibility = Visibility.Visible;

                    Updatenew3.Visibility = Visibility.Visible;
                    Updatenew4.Visibility = Visibility.Visible;
                    Updatenew5.Visibility = Visibility.Visible;

                    Updatenew6.Visibility = Visibility.Hidden;


                }
                else if (news3 >= 0)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    Updatenew1.Background = new ImageBrush(all_news1);
                    Updatenew1.Content = all_news[news1].get_id().ToString();
                    Updatenew1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    Updatenew2.Background = new ImageBrush(all_news2);
                    Updatenew2.Content = all_news[news2].get_id().ToString();
                    Updatenew2.FontSize = 0.1;

                    /////////////////////////////
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    Updatenew3.Background = new ImageBrush(all_news3);
                    Updatenew3.Content = all_news[news3].get_id().ToString();
                    Updatenew3.FontSize = 0.1;

                    /////////////////////////////
                    all_news4 = new BitmapImage();
                    all_news4ms = new MemoryStream(all_news[news4].get_photo());
                    all_news4ms.Position = 0;
                    all_news4.BeginInit();
                    all_news4.CacheOption = BitmapCacheOption.OnLoad;
                    all_news4.StreamSource = all_news4ms;
                    all_news4.EndInit();
                    // set properties of news
                    Updatenew4.Background = new ImageBrush(all_news4);
                    Updatenew4.Content = all_news[news4].get_id().ToString();
                    Updatenew4.FontSize = 0.1;

                    /////////////////////////////
                    ///
                    Updatenew1.Visibility = Visibility.Visible;
                    Updatenew2.Visibility = Visibility.Visible;
                    Updatenew3.Visibility = Visibility.Visible;

                    Updatenew4.Visibility = Visibility.Visible;
                    Updatenew5.Visibility = Visibility.Hidden;
                    Updatenew6.Visibility = Visibility.Hidden;

                }
                else if (news4 >= 0)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    Updatenew1.Background = new ImageBrush(all_news1);
                    Updatenew1.Content = all_news[news1].get_id().ToString();
                    Updatenew1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    Updatenew2.Background = new ImageBrush(all_news2);
                    Updatenew2.Content = all_news[news2].get_id().ToString();
                    Updatenew2.FontSize = 0.1;

                    /////////////////////////////
                    all_news3 = new BitmapImage();
                    all_news3ms = new MemoryStream(all_news[news3].get_photo());
                    all_news3ms.Position = 0;
                    all_news3.BeginInit();
                    all_news3.CacheOption = BitmapCacheOption.OnLoad;
                    all_news3.StreamSource = all_news3ms;
                    all_news3.EndInit();
                    // set properties of news
                    Updatenew3.Background = new ImageBrush(all_news3);
                    Updatenew3.Content = all_news[news3].get_id().ToString();
                    Updatenew3.FontSize = 0.1;

                    /////////////////////////////
                    ///
                    Updatenew1.Visibility = Visibility.Visible;
                    Updatenew2.Visibility = Visibility.Visible;
                    Updatenew3.Visibility = Visibility.Visible;
                    Updatenew4.Visibility = Visibility.Hidden;

                    Updatenew5.Visibility = Visibility.Hidden;
                    Updatenew6.Visibility = Visibility.Hidden;

                }
                else if (news5 >= 0)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    Updatenew1.Background = new ImageBrush(all_news1);
                    Updatenew1.Content = all_news[news1].get_id().ToString();
                    Updatenew1.FontSize = 0.1;

                    /////////////////////////////
                    all_news2 = new BitmapImage();
                    all_news2ms = new MemoryStream(all_news[news2].get_photo());
                    all_news2ms.Position = 0;
                    all_news2.BeginInit();
                    all_news2.CacheOption = BitmapCacheOption.OnLoad;
                    all_news2.StreamSource = all_news2ms;
                    all_news2.EndInit();
                    // set properties of news
                    Updatenew2.Background = new ImageBrush(all_news2);
                    Updatenew2.Content = all_news[news2].get_id().ToString();
                    Updatenew2.FontSize = 0.1;

                    /////////////////////////////
                    ///
                    Updatenew1.Visibility = Visibility.Visible;
                    Updatenew2.Visibility = Visibility.Visible;
                    Updatenew3.Visibility = Visibility.Hidden;
                    Updatenew4.Visibility = Visibility.Hidden;
                    Updatenew5.Visibility = Visibility.Hidden;
                    Updatenew6.Visibility = Visibility.Hidden;
                }
                else if (news6 >= 0)
                {
                    all_news1 = new BitmapImage();
                    all_news1ms = new MemoryStream(all_news[news1].get_photo());
                    all_news1ms.Position = 0;
                    all_news1.BeginInit();
                    all_news1.CacheOption = BitmapCacheOption.OnLoad;
                    all_news1.StreamSource = all_news1ms;
                    all_news1.EndInit();
                    // set properties of news
                    Updatenew1.Background = new ImageBrush(all_news1);
                    Updatenew1.Content = all_news[news1].get_id().ToString();
                    Updatenew1.FontSize = 0.1;

                    Updatenew1.Visibility = Visibility.Visible;
                    Updatenew2.Visibility = Visibility.Hidden;
                    Updatenew3.Visibility = Visibility.Hidden;
                    Updatenew4.Visibility = Visibility.Hidden;
                    Updatenew5.Visibility = Visibility.Hidden;
                    Updatenew6.Visibility = Visibility.Hidden;

                }
                else
                {
                    return;
                }
            }
        }

        private void Removenews_bt_Click(object sender, RoutedEventArgs e)
        {
            Ad.RemoveNew(upnew.get_id());
            MessageBox.Show("successfully Removed");
            UpdateNews_panel.Visibility = Visibility.Visible;
            searchstackpanel.Visibility = Visibility.Visible;

            updatNewsEditPanel.Visibility = Visibility.Collapsed;
            AddUser_panel.Visibility = Visibility.Collapsed;
            RemoveUser_panel.Visibility = Visibility.Collapsed;
            AddAdmin_panel.Visibility = Visibility.Collapsed;
            showAllNews_panel.Visibility = Visibility.Collapsed;
            AddNews_panel.Visibility = Visibility.Collapsed;
            AddCatagory_panel.Visibility = Visibility.Collapsed;
            NEWStoUpdatepanel.Visibility = Visibility.Collapsed;
            UpdateNewsEditeBorder.Visibility = Visibility.Collapsed;

        }

        private void new1_Click(object sender, RoutedEventArgs e)
        {
            var x = new Admin_new_page((sender as Button).Content.ToString(), Ad);
            x.Show();
            this.Close();

        }
    }
    }
  
