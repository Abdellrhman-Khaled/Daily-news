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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Newssify;

namespace Newsify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person p = new Person();
        public MainWindow()
        {
            InitializeComponent();
            login_btn.Click += Login_btn_Click;
            signup_lb.MouseLeftButtonDown += Signup_lb_MouseLeftButtonDown;
            signup_btn.Click += Signup_btn_Click;
            //signup_btn.Opacity = 0;
            //signup_btn.Visibility= Visibility.Visible;
            //DoubleAnimation fadeInAnimation = new DoubleAnimation();
            //fadeInAnimation.From = -1;
            //fadeInAnimation.To = 1;
            //fadeInAnimation.Duration = TimeSpan.FromSeconds(0.5);
            //signup_btn.BeginAnimation(Button.OpacityProperty, fadeInAnimation);
           
        }

        private void Signup_btn_Click(object sender, RoutedEventArgs e)
        {
            var x = new Create_Account();
            x.Show();
            this.Close();
        }

        private void Signup_lb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var x = new Create_Account();
            x.Show();
            this.Close();
        }

        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            //Adminn z = new Adminn(null);
            //z.Show();
            //this.Close();
            //return;

            if (user_email_txt.Text.ToString() == ""|| password_txt.Text.ToString()=="")
            {
                MessageBox.Show("Please Enter your Email/Username And Password", "Login", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                if (user_email_txt.Text.Contains("@"))
                {
                    if (p.check_valid_mail(user_email_txt.Text.ToString()))
                    {
                        if (p.Check_valid_Pass(password_txt.Text.ToString()))
                        {
                            int user_admin = p.login(user_email_txt.Text.ToString(), password_txt.Text.ToString());

                            if (user_admin == 1)
                            {
                                Admin admin = p.adminLogin(user_email_txt.Text.ToString());
                                Adminn y = new Adminn(admin);
                                y.Show();
                                this.Close();
                            }
                            else if (user_admin == 2)
                            {
                                User user = p.userLogin(user_email_txt.Text.ToString());
                                Daily_News x = new Daily_News(user);
                                x.Show();
                                this.Close();


                            }
                            else
                            {
                                MessageBox.Show("This Account Doesn't Exist,Please Sign Up", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                            }


                        }
                        else
                        {
                            MessageBox.Show("Invalid Password", "Login", MessageBoxButton.OK, MessageBoxImage.Error);

                        }

                    }
                    else
                    {
                        MessageBox.Show("Invalid Email", "Login", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                else
                {
                    if (p.check_valid_username(user_email_txt.Text.ToString()))
                    {
                        if (p.Check_valid_Pass(password_txt.Text.ToString()))
                        {
                            int user_admin = p.login(user_email_txt.Text.ToString(), password_txt.Text.ToString());

                            if (user_admin == 1)
                            {
                                Admin admin = p.adminLogin(user_email_txt.Text.ToString());
                                Adminn y = new Adminn(admin);
                                y.Show();
                                this.Close();
                            }
                            else if (user_admin == 2)
                            {
                                User user = p.userLogin(user_email_txt.Text.ToString());
                                Daily_News x = new Daily_News(user);
                                x.Show();
                                this.Close();


                            }
                            else
                            {
                                MessageBox.Show("This Account Doesn't Exist,Please Sign Up", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                            }


                        }
                        else
                        {
                            MessageBox.Show("Invalid Password", "Login", MessageBoxButton.OK, MessageBoxImage.Error);

                        }

                    }
                    else
                    {
                        MessageBox.Show("Invalid Email", "Login", MessageBoxButton.OK, MessageBoxImage.Error);

                    }

                }
            }
        }

        private void forget_lb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var x = new Forget_password();
            x.Show();
            this.Close();
        }
    }
}
