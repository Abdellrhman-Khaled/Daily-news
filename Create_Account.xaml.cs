using Microsoft.Win32;
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
using System.IO;

namespace Newsify
{
    /// <summary>
    /// Interaction logic for Create_Account.xaml
    /// </summary>
    public partial class Create_Account : Window
    {
        BitmapImage bitmap;
       
        Person p;
       
        public Create_Account()
        {
            byte[] defaultphoto = File.ReadAllBytes(@"E:\Newsify\Resources\user3.png");
            MemoryStream ms = new MemoryStream(defaultphoto);
            bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
           bitmap.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            bitmap.StreamSource = ms;

            bitmap.EndInit();
            //signup_bt.Click += Signup_bt_Click;
            //selectprofile_image_bt.Click += Selectprofile_image_bt_Click;
            InitializeComponent();

        }

       



        //private void Selectprofile_image_bt_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void selectprofile_image_bt_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                 bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFilePath);
                bitmap.DecodePixelWidth = 400;
                bitmap.DecodePixelHeight = 500;
                bitmap.EndInit();
                selectprofile_image.Source = bitmap;
                selectprofile_image.Width = 170;
                selectprofile_image.Height = 190;
                selectprofile_image.Stretch = Stretch.Uniform;
                //selectprofile_image.Stretch = Stretch.Uniform;
                selectprofile_image.HorizontalAlignment = HorizontalAlignment.Center;
                selectprofile_image.VerticalAlignment = VerticalAlignment.Center;

            }
            else
            {
                bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@"E:\Newsify\Resources\user.png");
                bitmap.EndInit();

            }

        }

        private void signup_bt_Click_1(object sender, RoutedEventArgs e)
        {
            p = new Person();
            if (p.check_valid_name(firstname_tb.Text.ToString()))
            {
                if (p.check_valid_name(lastname_tb.Text.ToString()))
                {
                    if (!p.usernameExist(username_tb.Text.ToString()))
                    {
                        if (p.check_valid_username(username_tb.Text.ToString()))
                        {
                            if (!p.emailExist(Email_tb.Text.ToString()))
                            {
                                if (p.check_valid_mail(Email_tb.Text.ToString()))
                                {
                                    if (p.Check_valid_PhoneNo(phonenumber_tb.Text.ToString()))
                                    {
                                        if (p.check_valid_age(Convert.ToDateTime(datepicker.Text)))
                                        {
                                            var parent = (FrameworkElement)password_tb.Template.FindName("PART_PasswordBox", password_tb);
                                            var passwordBox = (PasswordBox)parent.FindName("PART_PasswordBox");
                                            var password = passwordBox.Password;
                                            password_tb.Text = password;
                                            if (p.Check_valid_Pass(password_tb.Text.ToString()))
                                            {
                                                var paren = (FrameworkElement)confrimpassword_tb.Template.FindName("PART_conf_PasswordBox", confrimpassword_tb);
                                                var passwordBo = (PasswordBox)paren.FindName("PART_conf_PasswordBox");
                                                var passwor = passwordBo.Password;
                                                confrimpassword_tb.Text = passwor;
                                                if (password_tb.Text == confrimpassword_tb.Text)
                                                {
                                                    //byte[] imagebyte;
                                                    //MemoryStream ms = new MemoryStream();
                                                    //BitmapEncoder encoder = new JpegBitmapEncoder();
                                                    //encoder.Frames.Add(BitmapFrame.Create(bitmap));
                                                    //encoder.Save(ms);
                                                    //imagebyte = ms.ToArray();

                                                    p.AddPerson(firstname_tb.Text.ToString().ToLower(), lastname_tb.Text.ToString().ToLower(), username_tb.Text.ToString().ToLower(), Email_tb.Text.ToString().ToLower(), password_tb.Text.ToString(), Convert.ToDateTime(datepicker.Text), phonenumber_tb.Text.ToString(), bitmap,"u");

                                                    MessageBox.Show("Account Create Successful", "Registration", MessageBoxButton.OK, MessageBoxImage.Information);
                                                    var x = new MainWindow();
                                                    x.Show();
                                                    this.Close();


                                                }
                                                else
                                                {
                                                    MessageBox.Show("Password Mismatch", "Registration", MessageBoxButton.OK, MessageBoxImage.Warning);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Invalid Password\nMust be 8 Characters Doesn't Contain Special Characters", "Registration", MessageBoxButton.OK, MessageBoxImage.Information);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Invalid Date", "Registration", MessageBoxButton.OK, MessageBoxImage.Information);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Enter a Valid Phone Number", "Registration", MessageBoxButton.OK, MessageBoxImage.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Email", "Registration", MessageBoxButton.OK, MessageBoxImage.Information);
                                }

                            }
                            else
                            {
                                MessageBox.Show("This Email Is Already Exist", "Registration", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username", "Registration", MessageBoxButton.OK, MessageBoxImage.Information);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Username Is Already Exist", "Registration", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Right Lastname ", "Registration", MessageBoxButton.OK, MessageBoxImage.Information);

                }

            }
            else
            {
                MessageBox.Show("Please Enter Right Firstname", "Registration", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        }

        private void alreadyhaveaccount_lb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var x = new MainWindow();
            x.Show();
            this.Close();

        }
    }
}
