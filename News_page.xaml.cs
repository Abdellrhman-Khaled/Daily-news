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
    /// Interaction logic for News_page.xaml
    /// </summary>
    public partial class News_page : Window
    {
        News new_data;
        BitmapImage new_photo;
        MemoryStream new_photo_ms;
        User user;
        List<(string, string)> Comments;
        int top = 0;
        int down = 1;
        double rate = 0;
        public News_page(string new_id,User u)
        {
            InitializeComponent();
            user = u;
            Comments = News.GetCommentsData(Convert.ToInt32(new_id));
            new_data = News.get_new(new_id);
            new_photo = new BitmapImage();
            new_photo_ms = new MemoryStream(new_data.get_photo());
            new_photo_ms.Position = 0;
            new_photo.BeginInit();
            new_photo.CacheOption = BitmapCacheOption.OnLoad;
            new_photo.StreamSource = new_photo_ms;
            new_photo.EndInit();

            news_title_lp.Content = new_data.get_title();
            average_reat_lb.Content = new_data.get_rate().ToString() + "/5";
            new_description_lb.Text = new_data.get_description();
            author_name.Content = new_data.get_author();
            news_img.Source = new_photo;

            if (Comments==null)
            {
                up_btn.Visibility = Visibility.Hidden;
                down_btn.Visibility = Visibility.Hidden;
                username1_lp.Visibility = Visibility.Hidden;
                username2_lp.Visibility = Visibility.Hidden;
                user1_cooment_txtb.Visibility = Visibility.Hidden;
                user2_cooment_txtb.Visibility = Visibility.Hidden;
            }
            else if (Comments.Count == 1)
            {
                username1_lp.Visibility = Visibility.Hidden;
                user1_cooment_txtb.Visibility = Visibility.Hidden;
                up_btn.Visibility = Visibility.Hidden;
                down_btn.Visibility = Visibility.Hidden;

                user2_cooment_txtb.Text = Comments[top].Item2;
                username2_lp.Content = Comments[top].Item1;





            }
            else
            {
                up_btn.Visibility = Visibility.Visible;
                down_btn.Visibility = Visibility.Visible;
                user1_cooment_txtb.Text = Comments[top].Item2;
                username1_lp.Content = Comments[top].Item1;
                user2_cooment_txtb.Text = Comments[down].Item2;
                username2_lp.Content = Comments[down].Item1;
            }



        }

        private void Fifth_s_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rate = 5;
            first_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\star.png"));
            sec_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\star.png"));
            third_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\star.png"));
            fourth_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\star.png"));
            fifth_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\star.png"));
        }

        private void Fourth_s_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rate = 4;
            first_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\star.png"));
            sec_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\star.png"));
            third_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\star.png"));
            fourth_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\star.png"));
            fifth_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\white0.png"));

        }

        private void Third_s_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rate = 3;
            first_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\star.png"));
            sec_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\star.png"));
            third_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\star.png"));
            fourth_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\white0.png"));
            fifth_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\white0.png"));

        }

        private void Sec_s_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rate = 2;
            first_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\star.png"));
            sec_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\star.png"));
            third_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\white0.png"));
            fourth_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\white0.png"));
            fifth_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\white0.png"));
        }

        private void First_s_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rate = 1;
            first_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\star.png"));

            sec_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\white0.png"));
            third_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\white0.png"));
            fourth_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\white0.png"));
            fifth_s.Source = new BitmapImage(new Uri(@"E:\Newsify\Resources\white0.png"));


        }

        private void home_tb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var x = new Daily_News(user);
            x.Show();
            this.Close();

        }

        private void up_btn_Click(object sender, RoutedEventArgs e)
        {
            if (top == 0)
            {
                return;
            }
            else
            {
                top--;
                down--;
              
                user1_cooment_txtb.Text = Comments[top].Item2;
                username1_lp.Content = Comments[top].Item1;
                user2_cooment_txtb.Text = Comments[down].Item2;
                username2_lp.Content = Comments[down].Item1;

            }

        }

        private void down_btn_Click(object sender, RoutedEventArgs e)
        {
            if (down==Comments.Count-1)
            {
                return;
            }
            else
            {
                top++;
                down++;

                user1_cooment_txtb.Text = Comments[top].Item2;
                username1_lp.Content = Comments[top].Item1;
                user2_cooment_txtb.Text = Comments[down].Item2;
                username2_lp.Content = Comments[down].Item1;

            }

        }

        private void rate_btn_Click(object sender, RoutedEventArgs e)
        {
            if (rate == 0)
            {
                MessageBox.Show("Please Insert rate", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {

                user.insertRate(new_data.get_id(), rate);
                average_reat_lb.Content = new_data.get_rate().ToString() + "/5";
            }
        }

        private void comment_txt_GotFocus(object sender, RoutedEventArgs e)
        {
            if(comment_txt.Text== "ADD COMMENT...")
            {
                comment_txt.Text = "";
            }
        }

        private void comment_txt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (comment_txt.Text == "")
            {
                comment_txt.Text = "ADD COMMENT...";
            }
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            if(comment_txt.Text == "" || comment_txt.Text == "ADD COMMENT...")
            {
                MessageBox.Show("Please Add Your Comment", "Error");
            }
            else
            {
                user.AddComment(new_data.get_id(), user.get_user_name(), comment_txt.Text);
                Comments = News.GetCommentsData(new_data.get_id());
                down = Comments.Count - 1;
                top = Comments.Count - 2;
                if (Comments.Count == 1)
                {
                    username1_lp.Visibility = Visibility.Hidden;
                    user1_cooment_txtb.Visibility = Visibility.Hidden;
                    up_btn.Visibility = Visibility.Hidden;
                    down_btn.Visibility = Visibility.Hidden;
                    
                    user2_cooment_txtb.Text = Comments[down].Item2;
                    username2_lp.Content = Comments[down].Item1;
                    comment_txt.Text = "ADD COMMENT...";
                    username2_lp.Visibility = Visibility.Visible;
                    user2_cooment_txtb.Visibility = Visibility.Visible;


                }
                else
                {
                    username1_lp.Visibility = Visibility.Visible;
                    user1_cooment_txtb.Visibility = Visibility.Visible;
                    up_btn.Visibility = Visibility.Visible;
                    down_btn.Visibility = Visibility.Visible;
                    user1_cooment_txtb.Text = Comments[top].Item2;
                    username1_lp.Content = Comments[top].Item1;
                    user2_cooment_txtb.Text = Comments[down].Item2;
                    username2_lp.Content = Comments[down].Item1;
                    comment_txt.Text = "ADD COMMENT...";
                }

              

            }
        }

        private void spam_btn_Click(object sender, RoutedEventArgs e)
        {
            user.add_spam(user.get_user_name(), new_data.get_id());
            MessageBox.Show("Successfuly ");
            var x = new Daily_News(user);
            x.Show();
            this.Close();

        }
    }
}
