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
using System.IO;
using System.Globalization;
using Newssify;
using System.Windows.Media.Animation;

namespace Newsify
{
    /// <summary>
    /// Interaction logic for Daily_News.xaml
    /// </summary>
    public partial class Daily_News : Window
    {
        User user;
        List<News> top_rated = new List<News>();
        List<News> latest_new = new List<News>();
        BitmapImage left_top_photo;
        BitmapImage right_top_photo;
        BitmapImage left_down_photo;
        BitmapImage right_down_photo;
        MemoryStream left_top_ms;
        MemoryStream right_top_ms;
        MemoryStream left_down_ms;
        MemoryStream right_down_ms;
        int left = 0;
        int right= 1;
        int down = 0;
        int top = 1;
        DoubleAnimation fadeInAnimation = new DoubleAnimation();
        List<string> category;
       
        public Daily_News(User u)
        {
            InitializeComponent();
            user = u;
            string inputText = u.get_user_name();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string capitalizedText = textInfo.ToTitleCase(inputText.ToLower());
            user_lb.Text = capitalizedText;
            MemoryStream ms = new MemoryStream(u.get_photo());
            ms.Position = 0;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;

            Home_profile_photo.ImageSource = bitmap;
            Home_profile_photo.Stretch = Stretch.Fill;
            bitmap.EndInit();

            category = News.categories;

            //News.deleteSpam();
            //display top rated news
            top_rated = News.GetDataNewss();
            top_rated = News.hide_below_2(top_rated);
            top_rated = News.filterUserSpammed(top_rated, user.get_user_name());
            top_rated = News.Sort_by_Rate_Descendingly(top_rated);
            // prepare image
            
                left_top_photo = new BitmapImage();
                left_top_ms = new MemoryStream(top_rated[left].get_photo());
                left_top_ms.Position = 0;
                left_top_photo.BeginInit();
                left_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                left_top_photo.StreamSource = left_top_ms;
                left_top_photo.EndInit();
                // set properties of news
                left_new_top.Background = new ImageBrush(left_top_photo);
                left_title_top.Text = top_rated[left].get_title().ToUpper(); ;
                left_author_top.Content = top_rated[left].get_author().ToUpper(); ;
                left_new_top.Content = top_rated[left].get_id().ToString();
                left_new_top.FontSize = 0.1;

            
            // prepare left down button
            left_down_photo = new BitmapImage();
            left_down_ms = new MemoryStream(top_rated[right].get_photo());
            left_down_ms.Position = 0;
            left_down_photo.BeginInit();
            left_down_photo.CacheOption = BitmapCacheOption.OnLoad;
            left_down_photo.StreamSource = left_down_ms;
            left_down_photo.EndInit();
            // set properties of news
            left_new_down.Background = new ImageBrush(left_down_photo);
            left_title_down.Text = top_rated[right].get_title().ToUpper();
            left_author_down.Content = top_rated[right].get_author().ToUpper();
            left_new_down.Content = top_rated[right].get_id().ToString();
            left_new_down.FontSize = 0.1;

            fadeInAnimation.From = -1;
            fadeInAnimation.To = 1;
            fadeInAnimation.Duration = TimeSpan.FromSeconds(0.6);

            category = News.exist_cat(top_rated, category);

            // display latest news
            latest_new = News.GetDataNewss();
            latest_new = News.hide_below_2(latest_new);
            latest_new = News.filterUserSpammed(latest_new, user.get_user_name());
            latest_new = News.Display_by_latest_News(latest_new);
            //prepare photo
            right_top_photo = new BitmapImage();
            right_top_ms = new MemoryStream(latest_new[top].get_photo());
            right_top_ms.Position = 0;
            right_top_photo.BeginInit();
            right_top_photo.CacheOption = BitmapCacheOption.OnLoad;
            right_top_photo.StreamSource = right_top_ms;
            right_top_photo.EndInit();
            // set properties of news
            right_new_top.Background = new ImageBrush(right_top_photo);
            right_title_top.Text = latest_new[top].get_title().ToUpper();
            right_author_top.Content = latest_new[top].get_author().ToUpper();
            right_new_top.Content = latest_new[top].get_id().ToString();
            right_new_top.FontSize = 0.1;


            // prepare right down button
            right_down_photo = new BitmapImage();
            right_down_ms = new MemoryStream(latest_new[down].get_photo());
            right_down_ms.Position = 0;
            right_down_photo.BeginInit();
            right_down_photo.CacheOption = BitmapCacheOption.OnLoad;
            right_down_photo.StreamSource = right_down_ms;
            right_down_photo.EndInit();
            // set properties of news
            right_new_down.Background = new ImageBrush(right_down_photo);
            right_title_down.Text = latest_new[down].get_title().ToUpper();
            right_author_down.Content = latest_new[down].get_author().ToUpper();
            right_new_down.Content = latest_new[down].get_id().ToString();
            right_new_down.FontSize = 0.1;

            if (category.Count <= 5)
            {
                next_lb.Visibility = Visibility.Hidden;
                if (category.Count == 1)
                {
                    cat2.Text = category[0].ToUpper();
                    cat2.Visibility = Visibility.Hidden;
                    cat3.Visibility = Visibility.Hidden;
                    cat4.Visibility = Visibility.Hidden;
                    cat5.Visibility = Visibility.Hidden;
                    cat6.Visibility = Visibility.Hidden;

                    cat2.Opacity = 0;
                    cat2.Visibility = Visibility.Visible;
                    cat2.BeginAnimation(Button.OpacityProperty, fadeInAnimation);

                }
                else if(category.Count == 2)
                {
                    //cat1.Text = category[0].ToUpper();
                    cat2.Text = category[0].ToUpper();
                    cat3.Text = category[1].ToUpper();
                    cat4.Visibility = Visibility.Hidden;
                    cat5.Visibility = Visibility.Hidden;
                    cat6.Visibility = Visibility.Hidden;
                    cat2.Opacity = 0;
                    cat2.Visibility = Visibility.Visible;
                    cat2.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    cat3.Opacity = 0;
                    cat3.Visibility = Visibility.Visible;
                    cat3.BeginAnimation(Button.OpacityProperty, fadeInAnimation);


                }
                else if (category.Count == 3)
                {
                    //cat1.Text = category[0].ToUpper();
                    cat2.Text = category[0].ToUpper();
                    cat3.Text = category[1].ToUpper();
                    cat4.Text= category[2].ToUpper();
                    cat5.Visibility = Visibility.Hidden;
                    cat6.Visibility = Visibility.Hidden;
                    cat2.Opacity = 0;
                    cat2.Visibility = Visibility.Visible;
                    cat2.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    cat3.Opacity = 0;
                    cat3.Visibility = Visibility.Visible;
                    cat3.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    cat4.Opacity = 0;
                    cat4.Visibility = Visibility.Visible;
                    cat4.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                }
                else if (category.Count == 4)
                {
                    //cat1.Text = category[0].ToUpper();
                    cat2.Text = category[0].ToUpper();
                    cat3.Text = category[1].ToUpper();
                    cat4.Text = category[2].ToUpper();
                    cat5.Text = category[3].ToUpper();
                    cat6.Visibility = Visibility.Hidden;
                    cat2.Opacity = 0;
                    cat2.Visibility = Visibility.Visible;
                    cat2.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    cat3.Opacity = 0;
                    cat3.Visibility = Visibility.Visible;
                    cat3.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    cat4.Opacity = 0;
                    cat4.Visibility = Visibility.Visible;
                    cat4.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    cat5.Opacity = 0;
                    cat5.Visibility = Visibility.Visible;
                    cat5.BeginAnimation(Button.OpacityProperty, fadeInAnimation);


                }
                else if (category.Count == 5)
                {
                    //cat1.Text = category[0].ToUpper();
                    cat2.Text = category[0].ToUpper();
                    cat3.Text = category[1].ToUpper();
                    cat4.Text = category[2].ToUpper();
                    cat5.Text = category[3].ToUpper();
                    cat6.Text = category[4].ToUpper();

                    cat2.Opacity = 0;
                    cat2.Visibility = Visibility.Visible;
                    cat2.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    cat3.Opacity = 0;
                    cat3.Visibility = Visibility.Visible;
                    cat3.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    cat4.Opacity = 0;
                    cat4.Visibility = Visibility.Visible;
                    cat4.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    cat5.Opacity = 0;
                    cat5.Visibility = Visibility.Visible;
                    cat5.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    cat6.Opacity = 0;
                    cat6.Visibility = Visibility.Visible;
                    cat6.BeginAnimation(Button.OpacityProperty, fadeInAnimation);


                }
               

            }
            else
            {
              


                //cat1.Text = category[0].ToUpper();
                cat2.Text = category[0].ToUpper();
                cat3.Text = category[1].ToUpper();
                cat4.Text = category[2].ToUpper();
                cat5.Text = category[3].ToUpper();
                cat6.Text = category[4].ToUpper();

                //cat1.Opacity = 0;
                //cat1.Visibility = Visibility.Visible;
                cat2.Opacity = 0;
                cat2.Visibility = Visibility.Visible;
                cat3.Opacity = 0;
                cat3.Visibility = Visibility.Visible;
                cat4.Opacity = 0;
                cat4.Visibility = Visibility.Visible;
                cat5.Opacity = 0;
                cat5.Visibility = Visibility.Visible;
                cat6.Opacity = 0;
                cat6.Visibility = Visibility.Visible;
                next_lb.Opacity = 0;
                next_lb.Visibility = Visibility.Visible;


                //cat1.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                cat2.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                cat3.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                cat4.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                cat5.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                cat6.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                next_lb.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);

            }



            left_new_top.Opacity = 0;
            left_new_top.Visibility = Visibility.Visible;
            left_title_top.Opacity = 0;
            left_title_top.Visibility = Visibility.Visible;
            left_author_top.Opacity = 0;
            left_author_top.Visibility = Visibility.Visible;

            left_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
            left_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
            left_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);

            left_new_down.Opacity = 0;
            left_new_down.Visibility = Visibility.Visible;
            left_title_down.Opacity = 0;
            left_title_down.Visibility = Visibility.Visible;
            left_author_down.Opacity = 0;
            left_author_down.Visibility = Visibility.Visible;

            left_new_down.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
            left_title_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
            left_author_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);


            right_new_top.Opacity = 0;
            right_new_top.Visibility = Visibility.Visible;
            right_title_top.Opacity = 0;
            right_title_top.Visibility = Visibility.Visible;
            right_author_top.Opacity = 0;
            right_author_top.Visibility = Visibility.Visible;

            right_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
            right_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
            right_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);


            right_new_down.Opacity = 0;
            right_new_down.Visibility = Visibility.Visible;
            right_title_down.Opacity = 0;
            right_title_down.Visibility = Visibility.Visible;
            right_author_down.Opacity = 0;
            right_author_down.Visibility = Visibility.Visible;

            right_new_down.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
            right_title_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
            right_author_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);




        }

        private void Right_btn_Click(object sender, RoutedEventArgs e)
        {
            if (right == top_rated.Count - 1 || right>= top_rated.Count - 1 )
            {
                return;
            }
            else
            {
                left++;
                right++;

                left_top_photo = new BitmapImage();
                left_top_ms = new MemoryStream(top_rated[left].get_photo());
                left_top_ms.Position = 0;
                left_top_photo.BeginInit();
                left_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                left_top_photo.StreamSource = left_top_ms;
                left_top_photo.EndInit();
                // set properties of news
                left_new_top.Background = new ImageBrush(left_top_photo);
                left_title_top.Text = top_rated[left].get_title().ToUpper();
                left_author_top.Content = top_rated[left].get_author().ToUpper();
                left_new_top.Content = top_rated[left].get_id().ToString();
                left_new_top.FontSize = 0.1;

                left_new_top.Opacity = 0;
                left_new_top.Visibility = Visibility.Visible;
                left_title_top.Opacity = 0;
                left_title_top.Visibility = Visibility.Visible;
                left_author_top.Opacity = 0;
                left_author_top.Visibility = Visibility.Visible;


                left_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                left_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                left_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);





                // prepare left down button
                left_down_photo = new BitmapImage();
                left_down_ms = new MemoryStream(top_rated[right].get_photo());
                left_down_ms.Position = 0;
                left_down_photo.BeginInit();
                left_down_photo.CacheOption = BitmapCacheOption.OnLoad;
                left_down_photo.StreamSource = left_down_ms;
                left_down_photo.EndInit();
                // set properties of news
                left_new_down.Background = new ImageBrush(left_down_photo);
                left_title_down.Text = top_rated[right].get_title().ToUpper();
                left_author_down.Content = top_rated[right].get_author().ToUpper();
                left_new_down.Content = top_rated[right].get_id().ToString();
                left_new_down.FontSize = 0.1;
                left_new_down.Opacity = 0;
                left_new_down.Visibility = Visibility.Visible;
                left_title_down.Opacity = 0;
                left_title_down.Visibility = Visibility.Visible;
                left_author_down.Opacity = 0;
                left_author_down.Visibility = Visibility.Visible;
                left_new_down.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                left_title_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                left_author_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);

       


            }
        }

        private void Left_btn_Click(object sender, RoutedEventArgs e)
        {
            if (left == 0)
            {
                return;
            }
            else
            {
                left--;
                right--;

                left_top_photo = new BitmapImage();
                left_top_ms = new MemoryStream(top_rated[left].get_photo());
                left_top_ms.Position = 0;
                left_top_photo.BeginInit();
                left_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                left_top_photo.StreamSource = left_top_ms;
                left_top_photo.EndInit();
                // set properties of news
                left_new_top.Background = new ImageBrush(left_top_photo);
                left_title_top.Text = top_rated[left].get_title().ToUpper(); ;
                left_author_top.Content = top_rated[left].get_author().ToUpper();
                left_new_top.Content = top_rated[left].get_id().ToString();
                left_new_top.FontSize = 0.1;

                left_new_top.Opacity = 0;
                left_new_top.Visibility = Visibility.Visible;
                left_title_top.Opacity = 0;
                left_title_top.Visibility = Visibility.Visible;
                left_author_top.Opacity = 0;
                left_author_top.Visibility = Visibility.Visible;

                left_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                left_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                left_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);





                // prepare left down button
                left_down_photo = new BitmapImage();
                left_down_ms = new MemoryStream(top_rated[right].get_photo());
                left_down_ms.Position = 0;
                left_down_photo.BeginInit();
                left_down_photo.CacheOption = BitmapCacheOption.OnLoad;
                left_down_photo.StreamSource = left_down_ms;
                left_down_photo.EndInit();
                // set properties of news
                left_new_down.Background = new ImageBrush(left_down_photo);
                left_title_down.Text = top_rated[right].get_title().ToUpper();
                left_author_down.Content = top_rated[right].get_author().ToUpper();
                left_new_down.Content = top_rated[right].get_id().ToString();
                left_new_down.FontSize = 0.1;
                left_new_down.Opacity = 0;
                left_new_down.Visibility = Visibility.Visible;
                left_title_down.Opacity = 0;
                left_title_down.Visibility = Visibility.Visible;
                left_author_down.Opacity = 0;
                left_author_down.Visibility = Visibility.Visible;
                left_new_down.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                left_title_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                left_author_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);




            }

        }



        private void Down_btn_Click(object sender, RoutedEventArgs e)
        {
            if (down==0)
            {
                return;
            }
            else
            {
                top--;
                down--;

                right_top_photo = new BitmapImage();
                right_top_ms = new MemoryStream(latest_new[down].get_photo());
                right_top_ms.Position = 0;
                right_top_photo.BeginInit();
                right_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                right_top_photo.StreamSource = right_top_ms;
                right_top_photo.EndInit();
                // set properties of news
                right_new_top.Background = new ImageBrush(right_top_photo);
                right_title_top.Text = latest_new[down].get_title().ToUpper();
                right_author_top.Content = latest_new[down].get_author().ToUpper();
                right_new_top.Content = latest_new[down].get_id().ToString();
                right_new_top.FontSize = 0.1;

                right_new_top.Opacity = 0;
                right_new_top.Visibility = Visibility.Visible;
                right_title_top.Opacity = 0;
                right_title_top.Visibility = Visibility.Visible;
                right_author_top.Opacity = 0;
                right_author_top.Visibility = Visibility.Visible;

                right_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                right_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                right_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);





                // prepare left down button
                right_down_photo = new BitmapImage();
                right_down_ms = new MemoryStream(latest_new[top].get_photo());
                right_down_ms.Position = 0;
                right_down_photo.BeginInit();
                right_down_photo.CacheOption = BitmapCacheOption.OnLoad;
                right_down_photo.StreamSource = right_down_ms;
                right_down_photo.EndInit();
                // set properties of news
                right_new_down.Background = new ImageBrush(right_down_photo);
                right_title_down.Text = latest_new[top].get_title().ToUpper();
                right_author_down.Content = latest_new[top].get_author().ToUpper();
                right_new_down.Content = latest_new[top].get_id().ToString();
                right_new_down.FontSize = 0.1;
                right_new_down.Opacity = 0;
                right_new_down.Visibility = Visibility.Visible;
                right_title_down.Opacity = 0;
                right_title_down.Visibility = Visibility.Visible;
                right_author_down.Opacity = 0;
                right_author_down.Visibility = Visibility.Visible;
                right_new_down.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                right_title_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                right_author_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);




            }
        }

        private void Up_btn_Click(object sender, RoutedEventArgs e)
        {
            if (top == latest_new.Count - 1 || top>= latest_new.Count - 1)
            {
                return;
            }
            else
            {
                top++;
                down++;

                right_top_photo = new BitmapImage();
                right_top_ms = new MemoryStream(latest_new[down].get_photo());
                right_top_ms.Position = 0;
                right_top_photo.BeginInit();
                right_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                right_top_photo.StreamSource = right_top_ms;
                right_top_photo.EndInit();
                // set properties of news
                right_new_top.Background = new ImageBrush(right_top_photo);
                right_title_top.Text = latest_new[down].get_title().ToUpper();
                right_author_top.Content = latest_new[down].get_author().ToUpper();
                right_new_top.Content = latest_new[down].get_id().ToString();
                right_new_top.FontSize = 0.1;

                right_new_top.Opacity = 0;
                right_new_top.Visibility = Visibility.Visible;
                right_title_top.Opacity = 0;
                right_title_top.Visibility = Visibility.Visible;
                right_author_top.Opacity = 0;
                right_author_top.Visibility = Visibility.Visible;
                
                right_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                right_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                right_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);





                // prepare left down button
                right_down_photo = new BitmapImage();
                right_down_ms = new MemoryStream(latest_new[top].get_photo());
                right_down_ms.Position = 0;
                right_down_photo.BeginInit();
                right_down_photo.CacheOption = BitmapCacheOption.OnLoad;
                right_down_photo.StreamSource = right_down_ms;
                right_down_photo.EndInit();
                // set properties of news
                right_new_down.Background = new ImageBrush(right_down_photo);
                right_title_down.Text = latest_new[top].get_title().ToUpper();
                right_author_down.Content = latest_new[top].get_author().ToUpper();
                right_new_down.Content = latest_new[top].get_id().ToString();
                right_new_down.FontSize = 0.1;
                right_new_down.Opacity = 0;
                right_new_down.Visibility = Visibility.Visible;
                right_title_down.Opacity = 0;
                right_title_down.Visibility = Visibility.Visible;
                right_author_down.Opacity = 0;
                right_author_down.Visibility = Visibility.Visible;
                right_new_down.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                right_title_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                right_author_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);




            }

        }

       

        private void search_txt_GotFocus(object sender, RoutedEventArgs e)
        {
            if(search_txt.Text== "SEARCH...")
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

        private void about_us_lb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var x = new About_us(user);
            x.Show();
            this.Close();
        }

        private void search_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if(search_txt.Text== "SEARCH...")
            {
                return;
            }
            else if (search_txt.Text == "")
            {
                if (e.Key == Key.Enter)
                {

                    Left_btn.Visibility = Visibility.Visible;
                    Right_btn.Visibility = Visibility.Visible;

                    Up_btn.Visibility = Visibility.Visible;
                    Down_btn.Visibility = Visibility.Visible;

                    search_txt.Text = "SEARCH...";
                    left = 0;
                    right = 1;
                    down = 0;
                    top = 1;
                    //display top rated news
                    top_rated = News.GetDataNewss();
                    top_rated = News.hide_below_2(top_rated);
                    //top_rated = News.filterUserSpammed(top_rated, user.get_user_name());
                    top_rated = News.Sort_by_Rate_Descendingly(top_rated);
                    // prepare image
                    left_top_photo = new BitmapImage();
                    left_top_ms = new MemoryStream(top_rated[left].get_photo());
                    left_top_ms.Position = 0;
                    left_top_photo.BeginInit();
                    left_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                    left_top_photo.StreamSource = left_top_ms;
                    left_top_photo.EndInit();
                    // set properties of news
                    left_new_top.Background = new ImageBrush(left_top_photo);
                    left_title_top.Text = top_rated[left].get_title().ToUpper(); ;
                    left_author_top.Content = top_rated[left].get_author().ToUpper(); ;
                    left_new_top.Content = top_rated[left].get_id().ToString();
                    left_new_top.FontSize = 0.1;

                    // prepare left down button
                    left_down_photo = new BitmapImage();
                    left_down_ms = new MemoryStream(top_rated[right].get_photo());
                    left_down_ms.Position = 0;
                    left_down_photo.BeginInit();
                    left_down_photo.CacheOption = BitmapCacheOption.OnLoad;
                    left_down_photo.StreamSource = left_down_ms;
                    left_down_photo.EndInit();
                    // set properties of news
                    left_new_down.Background = new ImageBrush(left_down_photo);
                    left_title_down.Text = top_rated[right].get_title().ToUpper();
                    left_author_down.Content = top_rated[right].get_author().ToUpper();
                    left_new_down.Content = top_rated[right].get_id().ToString();
                    left_new_down.FontSize = 0.1;

                    fadeInAnimation.From = -1;
                    fadeInAnimation.To = 1;
                    fadeInAnimation.Duration = TimeSpan.FromSeconds(0.6);


                    // display latest news
                    latest_new = News.GetDataNewss();
                    latest_new = News.hide_below_2(latest_new);
                    //latest_new = News.filterUserSpammed(lastest_new, user.get_user_name());
                    latest_new = News.Display_by_latest_News(latest_new);
                    //prepare photo
                    right_top_photo = new BitmapImage();
                    right_top_ms = new MemoryStream(latest_new[top].get_photo());
                    right_top_ms.Position = 0;
                    right_top_photo.BeginInit();
                    right_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                    right_top_photo.StreamSource = right_top_ms;
                    right_top_photo.EndInit();
                    // set properties of news
                    right_new_top.Background = new ImageBrush(right_top_photo);
                    right_title_top.Text = latest_new[top].get_title().ToUpper();
                    right_author_top.Content = latest_new[top].get_author().ToUpper();
                    right_new_top.Content = latest_new[top].get_id().ToString();

                    right_new_top.FontSize = 0.1;
                    // prepare right down button
                    right_down_photo = new BitmapImage();
                    right_down_ms = new MemoryStream(latest_new[down].get_photo());
                    right_down_ms.Position = 0;
                    right_down_photo.BeginInit();
                    right_down_photo.CacheOption = BitmapCacheOption.OnLoad;
                    right_down_photo.StreamSource = right_down_ms;
                    right_down_photo.EndInit();
                    // set properties of news
                    right_new_down.Background = new ImageBrush(right_down_photo);
                    right_title_down.Text = latest_new[down].get_title().ToUpper();
                    right_author_down.Content = latest_new[down].get_author().ToUpper();
                    right_new_down.Content = latest_new[down].get_id().ToString();
                    right_new_down.FontSize = 0.1;

                    left_new_top.Opacity = 0;
                    left_new_top.Visibility = Visibility.Visible;
                    left_title_top.Opacity = 0;
                    left_title_top.Visibility = Visibility.Visible;
                    left_author_top.Opacity = 0;
                    left_author_top.Visibility = Visibility.Visible;

                    left_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    left_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                    left_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);

                    left_new_down.Opacity = 0;
                    left_new_down.Visibility = Visibility.Visible;
                    left_title_down.Opacity = 0;
                    left_title_down.Visibility = Visibility.Visible;
                    left_author_down.Opacity = 0;
                    left_author_down.Visibility = Visibility.Visible;

                    left_new_down.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    left_title_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                    left_author_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);


                    right_new_top.Opacity = 0;
                    right_new_top.Visibility = Visibility.Visible;
                    right_title_top.Opacity = 0;
                    right_title_top.Visibility = Visibility.Visible;
                    right_author_top.Opacity = 0;
                    right_author_top.Visibility = Visibility.Visible;
                    
                    right_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    right_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                    right_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);


                    right_new_down.Opacity = 0;
                    right_new_down.Visibility = Visibility.Visible;
                    right_title_down.Opacity = 0;
                    right_title_down.Visibility = Visibility.Visible;
                    right_author_down.Opacity = 0;
                    right_author_down.Visibility = Visibility.Visible;
                    
                    right_new_down.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    right_title_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                    right_author_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);


                }

            }
            else
            {
                if (e.Key == Key.Enter)
                {
                    left = 0;
                    right = 1;
                    top_rated = News.GetDataNewss();
                    top_rated = News.hide_below_2(top_rated);
                    //top_rated = News.filterUserSpammed(top_rated, user.get_user_name());
                    top_rated = News.Display_based_on_specific_title(top_rated, search_txt.Text);
                    top_rated = News.Sort_by_Rate_Descendingly(top_rated);

                    top = 1;
                    down = 0;
                    latest_new = News.GetDataNewss();
                    latest_new = News.hide_below_2(latest_new);
                    //top_rated = News.filterUserSpammed(top_rated, user.get_user_name());
                    latest_new = News.Display_based_on_specific_title(latest_new, search_txt.Text);
                    latest_new = News.Display_by_latest_News(latest_new);

                    if (top_rated.Count == 0 || latest_new.Count==0)
                    {
                        left_new_top.Visibility = Visibility.Hidden;
                        left_new_down.Visibility = Visibility.Hidden;

                        left_title_top.Visibility = Visibility.Hidden;
                        left_title_down.Visibility = Visibility.Hidden;

                        left_author_down.Visibility = Visibility.Hidden;
                        left_author_top.Visibility = Visibility.Hidden;

                        right_new_top.Visibility = Visibility.Hidden;
                        right_new_down.Visibility = Visibility.Hidden;
                        
                        right_title_top.Visibility = Visibility.Hidden;
                        right_title_down.Visibility = Visibility.Hidden;
                        
                        right_author_down.Visibility = Visibility.Hidden;
                        right_author_top.Visibility = Visibility.Hidden;

                        Left_btn.Visibility = Visibility.Hidden;
                        Right_btn.Visibility = Visibility.Hidden;

                        Up_btn.Visibility = Visibility.Hidden;
                        Down_btn.Visibility = Visibility.Hidden;

                        MessageBox.Show("No such News with that name");




                    }
                    else if (top_rated.Count == 1 || latest_new.Count==1)
                    {
                        left_top_photo = new BitmapImage();
                        left_top_ms = new MemoryStream(top_rated[left].get_photo());
                        left_top_ms.Position = 0;
                        left_top_photo.BeginInit();
                        left_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                        left_top_photo.StreamSource = left_top_ms;
                        left_top_photo.EndInit();
                        // set properties of news
                        left_new_top.Background = new ImageBrush(left_top_photo);
                        left_title_top.Text = top_rated[left].get_title().ToUpper();
                        left_author_top.Content = top_rated[left].get_author().ToUpper();
                        left_new_top.Content = top_rated[left].get_id().ToString();
                        left_new_top.FontSize = 0.1;

                        left_new_top.Opacity = 0;
                        left_new_top.Visibility = Visibility.Visible;
                        left_title_top.Opacity = 0;
                        left_title_top.Visibility = Visibility.Visible;
                        left_author_top.Opacity = 0;
                        left_author_top.Visibility = Visibility.Visible;

                        left_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                        left_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                        left_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);


                        right_top_photo = new BitmapImage();
                        right_top_ms = new MemoryStream(latest_new[down].get_photo());
                        right_top_ms.Position = 0;
                        right_top_photo.BeginInit();
                        right_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                        right_top_photo.StreamSource = right_top_ms;
                        right_top_photo.EndInit();
                        // set properties of news
                        right_new_top.Background = new ImageBrush(right_top_photo);
                        right_title_top.Text = latest_new[down].get_title().ToUpper();
                        right_author_top.Content = latest_new[down].get_author().ToUpper();
                        right_new_top.Content = latest_new[down].get_id().ToString();
                        right_new_top.FontSize = 0.1;


                        right_new_top.Opacity = 0;
                        right_new_top.Visibility = Visibility.Visible;
                        right_title_top.Opacity = 0;
                        right_title_top.Visibility = Visibility.Visible;
                        right_author_top.Opacity = 0;
                        right_author_top.Visibility = Visibility.Visible;
                        
                        right_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                        right_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                        right_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);



                        left_new_down.Visibility = Visibility.Hidden;
                        left_title_down.Visibility = Visibility.Hidden;
                        left_author_down.Visibility = Visibility.Hidden;
                        right_new_down.Visibility = Visibility.Hidden;
                        right_title_down.Visibility = Visibility.Hidden;
                        right_author_down.Visibility = Visibility.Hidden;
                        Left_btn.Visibility = Visibility.Hidden;
                        Right_btn.Visibility = Visibility.Hidden;

                        Up_btn.Visibility = Visibility.Hidden;
                        Down_btn.Visibility = Visibility.Hidden;



                    }
                    else
                    {


                        left_top_photo = new BitmapImage();
                        left_top_ms = new MemoryStream(top_rated[left].get_photo());
                        left_top_ms.Position = 0;
                        left_top_photo.BeginInit();
                        left_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                        left_top_photo.StreamSource = left_top_ms;
                        left_top_photo.EndInit();
                        // set properties of news
                        left_new_top.Background = new ImageBrush(left_top_photo);
                        left_title_top.Text = top_rated[left].get_title().ToUpper();
                        left_author_top.Content = top_rated[left].get_author().ToUpper();
                        left_new_top.Content = top_rated[left].get_id().ToString();
                        left_new_top.FontSize = 0.1;

                        left_new_top.Opacity = 0;
                        left_new_top.Visibility = Visibility.Visible;
                        left_title_top.Opacity = 0;
                        left_title_top.Visibility = Visibility.Visible;
                        left_author_top.Opacity = 0;
                        left_author_top.Visibility = Visibility.Visible;

                        left_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                        left_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                        left_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);





                        // prepare left down button
                        left_down_photo = new BitmapImage();
                        left_down_ms = new MemoryStream(top_rated[right].get_photo());
                        left_down_ms.Position = 0;
                        left_down_photo.BeginInit();
                        left_down_photo.CacheOption = BitmapCacheOption.OnLoad;
                        left_down_photo.StreamSource = left_down_ms;
                        left_down_photo.EndInit();
                        // set properties of news
                        left_new_down.Background = new ImageBrush(left_down_photo);
                        left_title_down.Text = top_rated[right].get_title().ToUpper();
                        left_author_down.Content = top_rated[right].get_author().ToUpper();
                        left_new_down.Content = top_rated[right].get_id().ToString();
                        left_new_down.FontSize = 0.1;

                        left_new_down.Opacity = 0;
                        left_new_down.Visibility = Visibility.Visible;
                        left_title_down.Opacity = 0;
                        left_title_down.Visibility = Visibility.Visible;
                        left_author_down.Opacity = 0;
                        left_author_down.Visibility = Visibility.Visible;
                        left_new_down.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                        left_title_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                        left_author_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);

                        //////////////////////////////////////////////////////////////////////////
                        ///
                       

                        right_top_photo = new BitmapImage();
                        right_top_ms = new MemoryStream(latest_new[top].get_photo());
                        right_top_ms.Position = 0;
                        right_top_photo.BeginInit();
                        right_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                        right_top_photo.StreamSource = right_top_ms;
                        right_top_photo.EndInit();
                        // set properties of news
                        right_new_top.Background = new ImageBrush(right_top_photo);
                        right_title_top.Text = latest_new[top].get_title().ToUpper();
                        right_author_top.Content = latest_new[top].get_author().ToUpper();
                        right_new_top.Content = latest_new[top].get_id().ToString();
                        right_new_top.FontSize = 0.1;

                        right_new_top.Opacity = 0;
                        right_new_top.Visibility = Visibility.Visible;
                        right_title_top.Opacity = 0;
                        right_title_top.Visibility = Visibility.Visible;
                        right_author_top.Opacity = 0;
                        right_author_top.Visibility = Visibility.Visible;

                        right_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                        right_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                        right_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);





                        // prepare left down button
                        right_down_photo = new BitmapImage();
                        right_down_ms = new MemoryStream(latest_new[down].get_photo());
                        right_down_ms.Position = 0;
                        right_down_photo.BeginInit();
                        right_down_photo.CacheOption = BitmapCacheOption.OnLoad;
                        right_down_photo.StreamSource = right_down_ms;
                        right_down_photo.EndInit();
                        // set properties of news
                        right_new_down.Background = new ImageBrush(right_down_photo);
                        right_title_down.Text = latest_new[down].get_title().ToUpper();
                        right_author_down.Content = latest_new[down].get_author().ToUpper();
                        right_new_down.Content = latest_new[down].get_id().ToString();
                        right_new_down.FontSize = 0.1;

                        right_new_down.Opacity = 0;
                        right_new_down.Visibility = Visibility.Visible;
                        right_title_down.Opacity = 0;
                        right_title_down.Visibility = Visibility.Visible;
                        right_author_down.Opacity = 0;
                        right_author_down.Visibility = Visibility.Visible;
                        right_new_down.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                        right_title_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                        right_author_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);

                        Left_btn.Visibility = Visibility.Visible;
                        Right_btn.Visibility = Visibility.Visible;

                        Up_btn.Visibility = Visibility.Visible;
                        Down_btn.Visibility = Visibility.Visible;

                    }

                }
            }

        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (search_txt.Text == "SEARCH...")
            {
                return;
            }
            else if (search_txt.Text == "")
            {

                Left_btn.Visibility = Visibility.Visible;
                Right_btn.Visibility = Visibility.Visible;

                Up_btn.Visibility = Visibility.Visible;
                Down_btn.Visibility = Visibility.Visible;

                left = 0;
               right = 1;
               down = 0;
               top = 1;

                search_txt.Text = "SEARCH...";
                //display top rated news
                top_rated = News.GetDataNewss();
                top_rated = News.hide_below_2(top_rated);
                //top_rated = News.filterUserSpammed(top_rated, user.get_user_name());
                top_rated = News.Sort_by_Rate_Descendingly(top_rated);
                // prepare image
                left_top_photo = new BitmapImage();
                left_top_ms = new MemoryStream(top_rated[left].get_photo());
                left_top_ms.Position = 0;
                left_top_photo.BeginInit();
                left_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                left_top_photo.StreamSource = left_top_ms;
                left_top_photo.EndInit();
                // set properties of news
                left_new_top.Background = new ImageBrush(left_top_photo);
                left_title_top.Text = top_rated[left].get_title().ToUpper(); ;
                left_author_top.Content = top_rated[left].get_author().ToUpper(); ;
                left_new_top.Content = top_rated[left].get_id().ToString();
                left_new_top.FontSize = 0.1;

                // prepare left down button
                left_down_photo = new BitmapImage();
                left_down_ms = new MemoryStream(top_rated[right].get_photo());
                left_down_ms.Position = 0;
                left_down_photo.BeginInit();
                left_down_photo.CacheOption = BitmapCacheOption.OnLoad;
                left_down_photo.StreamSource = left_down_ms;
                left_down_photo.EndInit();
                // set properties of news
                left_new_down.Background = new ImageBrush(left_down_photo);
                left_title_down.Text = top_rated[right].get_title().ToUpper();
                left_author_down.Content = top_rated[right].get_author().ToUpper();
                left_new_down.Content = top_rated[right].get_id().ToString();
                left_new_down.FontSize = 0.1;

                fadeInAnimation.From = -1;
                fadeInAnimation.To = 1;
                fadeInAnimation.Duration = TimeSpan.FromSeconds(0.6);


                // display latest news
                latest_new = News.GetDataNewss();
                latest_new = News.hide_below_2(latest_new);
                //latest_new = News.filterUserSpammed(lastest_new, user.get_user_name());
                latest_new = News.Display_by_latest_News(latest_new);
                //prepare photo
                right_top_photo = new BitmapImage();
                right_top_ms = new MemoryStream(latest_new[top].get_photo());
                right_top_ms.Position = 0;
                right_top_photo.BeginInit();
                right_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                right_top_photo.StreamSource = right_top_ms;
                right_top_photo.EndInit();
                // set properties of news
                right_new_top.Background = new ImageBrush(right_top_photo);
                right_title_top.Text = latest_new[top].get_title().ToUpper();
                right_author_top.Content = latest_new[top].get_author().ToUpper();
                right_new_top.Content = latest_new[top].get_id().ToString();
                right_new_top.FontSize = 0.1;


                // prepare right down button
                right_down_photo = new BitmapImage();
                right_down_ms = new MemoryStream(latest_new[down].get_photo());
                right_down_ms.Position = 0;
                right_down_photo.BeginInit();
                right_down_photo.CacheOption = BitmapCacheOption.OnLoad;
                right_down_photo.StreamSource = right_down_ms;
                right_down_photo.EndInit();
                // set properties of news
                right_new_down.Background = new ImageBrush(right_down_photo);
                right_title_down.Text = latest_new[down].get_title().ToUpper();
                right_author_down.Content = latest_new[down].get_author().ToUpper();
                right_new_down.Content = latest_new[down].get_id().ToString();
                right_new_down.FontSize = 0.1;

                left_new_top.Opacity = 0;
                left_new_top.Visibility = Visibility.Visible;
                left_title_top.Opacity = 0;
                left_title_top.Visibility = Visibility.Visible;
                left_author_top.Opacity = 0;
                left_author_top.Visibility = Visibility.Visible;

                left_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                left_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                left_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);

                left_new_down.Opacity = 0;
                left_new_down.Visibility = Visibility.Visible;
                left_title_down.Opacity = 0;
                left_title_down.Visibility = Visibility.Visible;
                left_author_down.Opacity = 0;
                left_author_down.Visibility = Visibility.Visible;

                left_new_down.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                left_title_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                left_author_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);


                right_new_top.Opacity = 0;
                right_new_top.Visibility = Visibility.Visible;
                right_title_top.Opacity = 0;
                right_title_top.Visibility = Visibility.Visible;
                right_author_top.Opacity = 0;
                right_author_top.Visibility = Visibility.Visible;

                right_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                right_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                right_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);


                right_new_down.Opacity = 0;
                right_new_down.Visibility = Visibility.Visible;
                right_title_down.Opacity = 0;
                right_title_down.Visibility = Visibility.Visible;
                right_author_down.Opacity = 0;
                right_author_down.Visibility = Visibility.Visible;

                right_new_down.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                right_title_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                right_author_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);


            }
            else
            {
                left = 0;
                right = 1;
                top_rated = News.GetDataNewss();
                top_rated = News.hide_below_2(top_rated);
                //top_rated = News.filterUserSpammed(top_rated, user.get_user_name());
                top_rated = News.Display_based_on_specific_title(top_rated, search_txt.Text);
                top_rated = News.Sort_by_Rate_Descendingly(top_rated);

                top = 1;
                down = 0;
                latest_new = News.GetDataNewss();
                latest_new = News.hide_below_2(latest_new);
                //top_rated = News.filterUserSpammed(top_rated, user.get_user_name());
                latest_new = News.Display_based_on_specific_title(latest_new, search_txt.Text);
                latest_new = News.Display_by_latest_News(latest_new);

                if (top_rated.Count == 0 || latest_new.Count == 0)
                {
                    left_new_top.Visibility = Visibility.Hidden;
                    left_new_down.Visibility = Visibility.Hidden;

                    left_title_top.Visibility = Visibility.Hidden;
                    left_title_down.Visibility = Visibility.Hidden;

                    left_author_down.Visibility = Visibility.Hidden;
                    left_author_top.Visibility = Visibility.Hidden;

                    right_new_top.Visibility = Visibility.Hidden;
                    right_new_down.Visibility = Visibility.Hidden;

                    right_title_top.Visibility = Visibility.Hidden;
                    right_title_down.Visibility = Visibility.Hidden;

                    right_author_down.Visibility = Visibility.Hidden;
                    right_author_top.Visibility = Visibility.Hidden;

                    Left_btn.Visibility = Visibility.Hidden;
                    Right_btn.Visibility = Visibility.Hidden;

                    Up_btn.Visibility = Visibility.Hidden;
                    Down_btn.Visibility = Visibility.Hidden;

                    MessageBox.Show("No such news with that name");



                }
                else if (top_rated.Count == 1 || latest_new.Count == 1)
                {
                    left_top_photo = new BitmapImage();
                    left_top_ms = new MemoryStream(top_rated[left].get_photo());
                    left_top_ms.Position = 0;
                    left_top_photo.BeginInit();
                    left_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                    left_top_photo.StreamSource = left_top_ms;
                    left_top_photo.EndInit();
                    // set properties of news
                    left_new_top.Background = new ImageBrush(left_top_photo);
                    left_title_top.Text = top_rated[left].get_title().ToUpper();
                    left_author_top.Content = top_rated[left].get_author().ToUpper();
                    left_new_top.Content = top_rated[left].get_id().ToString();
                    left_new_top.FontSize = 0.1;

                    left_new_top.Opacity = 0;
                    left_new_top.Visibility = Visibility.Visible;
                    left_title_top.Opacity = 0;
                    left_title_top.Visibility = Visibility.Visible;
                    left_author_top.Opacity = 0;
                    left_author_top.Visibility = Visibility.Visible;

                    left_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    left_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                    left_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);


                    right_top_photo = new BitmapImage();
                    right_top_ms = new MemoryStream(latest_new[down].get_photo());
                    right_top_ms.Position = 0;
                    right_top_photo.BeginInit();
                    right_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                    right_top_photo.StreamSource = right_top_ms;
                    right_top_photo.EndInit();
                    // set properties of news
                    right_new_top.Background = new ImageBrush(right_top_photo);
                    right_title_top.Text = latest_new[down].get_title().ToUpper();
                    right_author_top.Content = latest_new[down].get_author().ToUpper();
                    right_new_top.Content = latest_new[down].get_id().ToString();
                    right_new_top.FontSize = 0.1;


                    right_new_top.Opacity = 0;
                    right_new_top.Visibility = Visibility.Visible;
                    right_title_top.Opacity = 0;
                    right_title_top.Visibility = Visibility.Visible;
                    right_author_top.Opacity = 0;
                    right_author_top.Visibility = Visibility.Visible;

                    right_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    right_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                    right_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);



                    left_new_down.Visibility = Visibility.Hidden;
                    left_title_down.Visibility = Visibility.Hidden;
                    left_author_down.Visibility = Visibility.Hidden;
                    right_new_down.Visibility = Visibility.Hidden;
                    right_title_down.Visibility = Visibility.Hidden;
                    right_author_down.Visibility = Visibility.Hidden;
                    Left_btn.Visibility = Visibility.Hidden;
                    Right_btn.Visibility = Visibility.Hidden;

                    Up_btn.Visibility = Visibility.Hidden;
                    Down_btn.Visibility = Visibility.Hidden;



                }
                else
                {


                    left_top_photo = new BitmapImage();
                    left_top_ms = new MemoryStream(top_rated[left].get_photo());
                    left_top_ms.Position = 0;
                    left_top_photo.BeginInit();
                    left_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                    left_top_photo.StreamSource = left_top_ms;
                    left_top_photo.EndInit();
                    // set properties of news
                    left_new_top.Background = new ImageBrush(left_top_photo);
                    left_title_top.Text = top_rated[left].get_title().ToUpper();
                    left_author_top.Content = top_rated[left].get_author().ToUpper();
                    left_new_top.Content = top_rated[left].get_id().ToString();
                    left_new_top.FontSize = 0.1;

                    left_new_top.Content = Visibility.Hidden ;

                    left_new_top.Opacity = 0;
                    left_new_top.Visibility = Visibility.Visible;
                    left_title_top.Opacity = 0;
                    left_title_top.Visibility = Visibility.Visible;
                    left_author_top.Opacity = 0;
                    left_author_top.Visibility = Visibility.Visible;

                    left_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    left_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                    left_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);





                    // prepare left down button
                    left_down_photo = new BitmapImage();
                    left_down_ms = new MemoryStream(top_rated[right].get_photo());
                    left_down_ms.Position = 0;
                    left_down_photo.BeginInit();
                    left_down_photo.CacheOption = BitmapCacheOption.OnLoad;
                    left_down_photo.StreamSource = left_down_ms;
                    left_down_photo.EndInit();
                    // set properties of news
                    left_new_down.Background = new ImageBrush(left_down_photo);
                    left_title_down.Text = top_rated[right].get_title().ToUpper();
                    left_author_down.Content = top_rated[right].get_author().ToUpper();
                    left_new_down.Content = top_rated[right].get_id().ToString();
                    left_new_down.FontSize = 0.1;

                    left_new_down.Opacity = 0;
                    left_new_down.Visibility = Visibility.Visible;
                    left_title_down.Opacity = 0;
                    left_title_down.Visibility = Visibility.Visible;
                    left_author_down.Opacity = 0;
                    left_author_down.Visibility = Visibility.Visible;
                    left_new_down.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    left_title_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                    left_author_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);

                    //////////////////////////////////////////////////////////////////////////
                    ///


                    right_top_photo = new BitmapImage();
                    right_top_ms = new MemoryStream(latest_new[top].get_photo());
                    right_top_ms.Position = 0;
                    right_top_photo.BeginInit();
                    right_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                    right_top_photo.StreamSource = right_top_ms;
                    right_top_photo.EndInit();
                    // set properties of news
                    right_new_top.Background = new ImageBrush(right_top_photo);
                    right_title_top.Text = latest_new[top].get_title().ToUpper();
                    right_author_top.Content = latest_new[top].get_author().ToUpper();
                    right_new_top.Content = latest_new[top].get_id().ToString();
                    right_new_top.FontSize = 0.1;

                    right_new_top.Opacity = 0;
                    right_new_top.Visibility = Visibility.Visible;
                    right_title_top.Opacity = 0;
                    right_title_top.Visibility = Visibility.Visible;
                    right_author_top.Opacity = 0;
                    right_author_top.Visibility = Visibility.Visible;

                    right_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    right_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                    right_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);





                    // prepare left down button
                    right_down_photo = new BitmapImage();
                    right_down_ms = new MemoryStream(latest_new[down].get_photo());
                    right_down_ms.Position = 0;
                    right_down_photo.BeginInit();
                    right_down_photo.CacheOption = BitmapCacheOption.OnLoad;
                    right_down_photo.StreamSource = right_down_ms;
                    right_down_photo.EndInit();
                    // set properties of news
                    right_new_down.Background = new ImageBrush(right_down_photo);
                    right_title_down.Text = latest_new[down].get_title().ToUpper();
                    right_author_down.Content = latest_new[down].get_author().ToUpper();
                    right_new_down.Content = latest_new[down].get_id().ToString();
                    right_new_down.FontSize = 0.1;
                    right_new_down.Opacity = 0;
                    right_new_down.Visibility = Visibility.Visible;
                    right_title_down.Opacity = 0;
                    right_title_down.Visibility = Visibility.Visible;
                    right_author_down.Opacity = 0;
                    right_author_down.Visibility = Visibility.Visible;
                    right_new_down.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    right_title_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                    right_author_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);

                    Left_btn.Visibility = Visibility.Visible;
                    Right_btn.Visibility = Visibility.Visible;

                    Up_btn.Visibility = Visibility.Visible;
                    Down_btn.Visibility = Visibility.Visible;

                }


            }


        }



       
        private void left_new_top_Click(object sender, RoutedEventArgs e)
        {
            var x = new News_page((sender as Button).Content.ToString() ,user);
            x.Show();
            this.Close();
        }

        private void cat1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            top_rated = News.GetDataNewss();
            top_rated = News.hide_below_2(top_rated);
            top_rated = News.filterUserSpammed(top_rated, user.get_user_name());
            top_rated = News.Sort_by_Rate_Descendingly(top_rated);
            top_rated = News.Filter_and_Sort_by_Category(top_rated, (sender as TextBlock).Text.ToString().ToLower());

            latest_new = News.GetDataNewss();
            latest_new = News.hide_below_2(latest_new);
            latest_new = News.filterUserSpammed(latest_new, user.get_user_name());
            latest_new = News.Display_by_latest_News(latest_new);
            latest_new = News.Filter_and_Sort_by_Category(latest_new, (sender as TextBlock).Text.ToString().ToLower());
            left = 0;
            right = 1;
            down = 0;
            top = 1;
            if (latest_new.Count == 1 || top_rated.Count == 1)
            {
                left_top_photo = new BitmapImage();
                left_top_ms = new MemoryStream(top_rated[left].get_photo());
                left_top_ms.Position = 0;
                left_top_photo.BeginInit();
                left_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                left_top_photo.StreamSource = left_top_ms;
                left_top_photo.EndInit();
                // set properties of news
                left_new_top.Background = new ImageBrush(left_top_photo);
                left_title_top.Text = top_rated[left].get_title().ToUpper();
                left_author_top.Content = top_rated[left].get_author().ToUpper();
                left_new_top.Content = top_rated[left].get_id().ToString();
                left_new_top.FontSize = 0.1;

                left_new_top.Opacity = 0;
                left_new_top.Visibility = Visibility.Visible;
                left_title_top.Opacity = 0;
                left_title_top.Visibility = Visibility.Visible;
                left_author_top.Opacity = 0;
                left_author_top.Visibility = Visibility.Visible;

                left_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                left_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                left_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);


                right_top_photo = new BitmapImage();
                right_top_ms = new MemoryStream(latest_new[down].get_photo());
                right_top_ms.Position = 0;
                right_top_photo.BeginInit();
                right_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                right_top_photo.StreamSource = right_top_ms;
                right_top_photo.EndInit();
                // set properties of news
                right_new_top.Background = new ImageBrush(right_top_photo);
                right_title_top.Text = latest_new[down].get_title().ToUpper();
                right_author_top.Content = latest_new[down].get_author().ToUpper();
                right_new_top.Content = latest_new[down].get_id().ToString();
                right_new_top.FontSize = 0.1;


                right_new_top.Opacity = 0;
                right_new_top.Visibility = Visibility.Visible;
                right_title_top.Opacity = 0;
                right_title_top.Visibility = Visibility.Visible;
                right_author_top.Opacity = 0;
                right_author_top.Visibility = Visibility.Visible;

                right_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                right_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                right_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);



                left_new_down.Visibility = Visibility.Hidden;
                left_title_down.Visibility = Visibility.Hidden;
                left_author_down.Visibility = Visibility.Hidden;
                right_new_down.Visibility = Visibility.Hidden;
                right_title_down.Visibility = Visibility.Hidden;
                right_author_down.Visibility = Visibility.Hidden;
                Left_btn.Visibility = Visibility.Hidden;
                Right_btn.Visibility = Visibility.Hidden;

                Up_btn.Visibility = Visibility.Hidden;
                Down_btn.Visibility = Visibility.Hidden;

            }
            else
            {
                left_top_photo = new BitmapImage();
                left_top_ms = new MemoryStream(top_rated[left].get_photo());
                left_top_ms.Position = 0;
                left_top_photo.BeginInit();
                left_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                left_top_photo.StreamSource = left_top_ms;
                left_top_photo.EndInit();
                // set properties of news
                left_new_top.Background = new ImageBrush(left_top_photo);
                left_title_top.Text = top_rated[left].get_title().ToUpper();
                left_author_top.Content = top_rated[left].get_author().ToUpper();
                left_new_top.Content = top_rated[left].get_id().ToString();
                left_new_top.FontSize = 0.1;

                left_new_top.Content = Visibility.Hidden;

                left_new_top.Opacity = 0;
                left_new_top.Visibility = Visibility.Visible;
                left_title_top.Opacity = 0;
                left_title_top.Visibility = Visibility.Visible;
                left_author_top.Opacity = 0;
                left_author_top.Visibility = Visibility.Visible;

                left_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                left_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                left_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);





                // prepare left down button
                left_down_photo = new BitmapImage();
                left_down_ms = new MemoryStream(top_rated[right].get_photo());
                left_down_ms.Position = 0;
                left_down_photo.BeginInit();
                left_down_photo.CacheOption = BitmapCacheOption.OnLoad;
                left_down_photo.StreamSource = left_down_ms;
                left_down_photo.EndInit();
                // set properties of news
                left_new_down.Background = new ImageBrush(left_down_photo);
                left_title_down.Text = top_rated[right].get_title().ToUpper();
                left_author_down.Content = top_rated[right].get_author().ToUpper();
                left_new_down.Content = top_rated[right].get_id().ToString();
                left_new_down.FontSize = 0.1;

                left_new_down.Opacity = 0;
                left_new_down.Visibility = Visibility.Visible;
                left_title_down.Opacity = 0;
                left_title_down.Visibility = Visibility.Visible;
                left_author_down.Opacity = 0;
                left_author_down.Visibility = Visibility.Visible;
                left_new_down.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                left_title_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                left_author_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);

                //////////////////////////////////////////////////////////////////////////
                ///


                right_top_photo = new BitmapImage();
                right_top_ms = new MemoryStream(latest_new[top].get_photo());
                right_top_ms.Position = 0;
                right_top_photo.BeginInit();
                right_top_photo.CacheOption = BitmapCacheOption.OnLoad;
                right_top_photo.StreamSource = right_top_ms;
                right_top_photo.EndInit();
                // set properties of news
                right_new_top.Background = new ImageBrush(right_top_photo);
                right_title_top.Text = latest_new[top].get_title().ToUpper();
                right_author_top.Content = latest_new[top].get_author().ToUpper();
                right_new_top.Content = latest_new[top].get_id().ToString();
                right_new_top.FontSize = 0.1;

                right_new_top.Opacity = 0;
                right_new_top.Visibility = Visibility.Visible;
                right_title_top.Opacity = 0;
                right_title_top.Visibility = Visibility.Visible;
                right_author_top.Opacity = 0;
                right_author_top.Visibility = Visibility.Visible;

                right_new_top.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                right_title_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                right_author_top.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);





                // prepare right down button
                right_down_photo = new BitmapImage();
                right_down_ms = new MemoryStream(latest_new[down].get_photo());
                right_down_ms.Position = 0;
                right_down_photo.BeginInit();
                right_down_photo.CacheOption = BitmapCacheOption.OnLoad;
                right_down_photo.StreamSource = right_down_ms;
                right_down_photo.EndInit();
                // set properties of news
                right_new_down.Background = new ImageBrush(right_down_photo);
                right_title_down.Text = latest_new[down].get_title().ToUpper();
                right_author_down.Content = latest_new[down].get_author().ToUpper();
                right_new_down.Content = latest_new[down].get_id().ToString();
                right_new_down.FontSize = 0.1;
                right_new_down.Opacity = 0;
                right_new_down.Visibility = Visibility.Visible;
                right_title_down.Opacity = 0;
                right_title_down.Visibility = Visibility.Visible;
                right_author_down.Opacity = 0;
                right_author_down.Visibility = Visibility.Visible;
                right_new_down.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                right_title_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                right_author_down.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);

                Left_btn.Visibility = Visibility.Visible;
                Right_btn.Visibility = Visibility.Visible;

                Up_btn.Visibility = Visibility.Visible;
                Down_btn.Visibility = Visibility.Visible;

            }



        }

        private void next_lb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((sender as TextBlock).Text.ToLower()=="next")
            {
                next_lb.Text = "previous".ToUpper();
                next_lb.Opacity = 0;
                next_lb.Visibility = Visibility.Visible;
                next_lb.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);


                if (category.Count == 6)
                {
                    cat2.Text = category[5].ToUpper();
                    //cat2.Visibility = Visibility.Hidden;
                    cat3.Visibility = Visibility.Hidden;
                    cat4.Visibility = Visibility.Hidden;
                    cat5.Visibility = Visibility.Hidden;
                    cat6.Visibility = Visibility.Hidden;
                    cat2.Opacity = 0;
                    cat2.Visibility = Visibility.Visible;    
                    cat2.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                   

                }
                else if (category.Count == 7)
                {
                    //cat1.Text = category[6].ToUpper();
                    cat2.Text = category[5].ToUpper();
                    cat3.Text = category[6].ToUpper();
                    cat4.Visibility = Visibility.Hidden;
                    cat5.Visibility = Visibility.Hidden;
                    cat6.Visibility = Visibility.Hidden;
                    cat2.Opacity = 0;
                    cat2.Visibility = Visibility.Visible;
                    cat3.Opacity = 0;
                    cat3.Visibility = Visibility.Visible;
                    

                    cat2.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    cat3.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);

                }
                else if (category.Count == 8)
                {
                    //cat1.Text = category[6].ToUpper();
                    cat2.Text = category[5].ToUpper();
                    cat3.Text = category[6].ToUpper();
                    cat4.Text = category[7].ToUpper();
                    cat5.Visibility = Visibility.Hidden;
                    cat6.Visibility = Visibility.Hidden;
                    cat2.Opacity = 0;
                    cat2.Visibility = Visibility.Visible;
                    cat3.Opacity = 0;
                    cat3.Visibility = Visibility.Visible;
                    cat4.Opacity = 0;
                    cat4.Visibility = Visibility.Visible;


                    cat2.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    cat3.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                    cat4.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);


                }
                else if (category.Count == 9)
                {
                    //cat1.Text = category[6].ToUpper();
                    cat2.Text = category[5].ToUpper();
                    cat3.Text = category[6].ToUpper();
                    cat4.Text = category[7].ToUpper();
                    cat5.Text = category[8].ToUpper();
                    cat6.Visibility = Visibility.Hidden;

                    cat2.Opacity = 0;
                    cat2.Visibility = Visibility.Visible;
                    cat3.Opacity = 0;
                    cat3.Visibility = Visibility.Visible;
                    cat4.Opacity = 0;
                    cat4.Visibility = Visibility.Visible;
                    cat5.Opacity = 0;
                    cat5.Visibility = Visibility.Visible;


                    cat2.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    cat3.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                    cat4.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                    cat5.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);


                }
                else if (category.Count ==10)
                {
                    //cat1.Text = category[6].ToUpper();
                    cat2.Text = category[5].ToUpper();
                    cat3.Text = category[6].ToUpper();
                    cat4.Text = category[7].ToUpper();
                    cat5.Text = category[8].ToUpper();
                    cat6.Text = category[9].ToUpper();
                    cat2.Opacity = 0;
                    cat2.Visibility = Visibility.Visible;
                    cat3.Opacity = 0;
                    cat3.Visibility = Visibility.Visible;
                    cat4.Opacity = 0;
                    cat4.Visibility = Visibility.Visible;
                    cat5.Opacity = 0;
                    cat5.Visibility = Visibility.Visible;
                    cat5.Opacity = 0;
                    cat5.Visibility = Visibility.Visible;


                    cat2.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                    cat3.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                    cat4.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                    cat5.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                    cat6.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);

                }
                

            }
            else
            {
                next_lb.Text = "next".ToUpper();
               

                //cat1.Text = category[0].ToUpper();
                cat2.Text = category[0].ToUpper();
                cat3.Text = category[1].ToUpper();
                cat4.Text = category[2].ToUpper();
                cat5.Text = category[3].ToUpper();
                cat6.Text = category[4].ToUpper();
                //cat1.Opacity = 0;
                //cat1.Visibility = Visibility.Visible;
                cat2.Opacity = 0;
                cat2.Visibility = Visibility.Visible;
                cat3.Opacity = 0;
                cat3.Visibility = Visibility.Visible;
                cat4.Opacity = 0;
                cat4.Visibility = Visibility.Visible;
                cat5.Opacity = 0;
                cat5.Visibility = Visibility.Visible;
                cat6.Opacity = 0;
                cat6.Visibility = Visibility.Visible;
                next_lb.Opacity = 0;
                next_lb.Visibility = Visibility.Visible;

                //cat1.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
                cat2.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                cat3.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                cat4.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                cat5.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                cat6.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
                next_lb.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);


            }

        }

        private void Profile_lb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var x = new profile(user);
            x.Show();
            this.Close();
        }

        private void Logout_lb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Person.save_persons();
            News.save_spam_to_database();
            News.save_comments_to_database();

            var x = new MainWindow();
            x.Show();
            this.Close();
        }
    }
}
