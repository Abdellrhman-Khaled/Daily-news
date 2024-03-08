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

namespace Newsify
{
    /// <summary>
    /// Interaction logic for Forget_password.xaml
    /// </summary>
    public partial class Forget_password : Window
    {
        User user= new User();
        public Forget_password()
        {
            InitializeComponent();
        }

        private void back_tb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var x = new MainWindow();
            x.Show();
            this.Close();

        }

        private void confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            if (user.check_valid_mail(for_email_txt.Text.ToLower()))
            {
                if (user.emailExist(for_email_txt.Text.ToLower()))
                {
                    if (user.Check_valid_PhoneNo(for_phone_txt.Text))
                    {
                        var parent = (FrameworkElement)new_password_txt.Template.FindName("PART_new_PasswordBox", new_password_txt);
                        var passwordBox = (PasswordBox)parent.FindName("PART_new_PasswordBox");
                        var password = passwordBox.Password;
                        new_password_txt.Text = password;

                        if (user.Check_valid_Pass(new_password_txt.Text))
                        {
                            var paren = (FrameworkElement)Cnew_password_txt.Template.FindName("PART_Cnew_PasswordBox", Cnew_password_txt);
                            var passwordBo = (PasswordBox)paren.FindName("PART_Cnew_PasswordBox");
                            var passwor = passwordBo.Password;
                            Cnew_password_txt.Text = passwor;
                            if (new_password_txt.Text == Cnew_password_txt.Text)
                            {
                                user.forget_password(for_email_txt.Text, for_phone_txt.Text, new_password_txt.Text);
                                MessageBox.Show("Password Successfuly Changed", "Forget Passwod", MessageBoxButton.OK, MessageBoxImage.Information);
                                var x = new MainWindow();
                                x.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Password Mismatch", "Forget Passwod", MessageBoxButton.OK, MessageBoxImage.Error);

                            }

                        }
                        else
                        {
                            MessageBox.Show("Invalid Password\nPassword Must Be 8 Characters Doesn't Contain Spaces ", "Forget Passwod", MessageBoxButton.OK, MessageBoxImage.Error);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Phone number", "Forget Passwod", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Email Doesn't Exist", "Forget Passwod", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
            else
            {
                MessageBox.Show("Invalid Email", "Forget Passwod", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
    }
}
