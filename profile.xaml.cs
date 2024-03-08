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
using Microsoft.Win32;
using Newsify;
using Newssify;

namespace Newsify
{
    /// <summary>
    /// Interaction logic for profile.xaml
    /// </summary>
    public partial class profile : Window
    {
        BitmapImage photo;
        MemoryStream ms;
        User ues;
        string old_user;
        BitmapImage bitmap;
        bool change = false;


        public profile(User u)
        {
            InitializeComponent();
            ues = u;
            changepassword_tb.MouseLeftButtonDown += Changepassword_tb_MouseLeftButtonDown;
            home_tb.MouseLeftButtonDown += Home_tb_MouseLeftButtonDown;
            firstnames_tb.Text = ues.get_fname();
            lastname_tb.Text = ues.get_lname();
            username_tb.Text = ues.get_user_name();
            old_user = username_tb.Text;
            usernametxt_tb.Text = ues.get_user_name();
            profileemail_tb.Text = ues.get_email();
            profileemailtxt_tb.Text = ues.get_email();
            birthdate_tb.Text =ues.get_birthdate().ToString().Substring(0,10); 
            age_tb.Text = ues.get_age().ToString();
            phone_tb.Text = ues.get_phoneno();
            passwordBox.Password = ues.get_password();
            newpasswordBox.Password = ues.get_password();
            confrimpasswordBox.Password = ues.get_password();


            photo = new BitmapImage();
            ms = new MemoryStream(ues.get_photo());
            photo.BeginInit();
            ms.Position = 0;
            //photo.BeginInit();
            photo.CacheOption = BitmapCacheOption.OnLoad;
            photo.StreamSource = ms;
            photo.EndInit();
            // set properties of news
            profilephoto.Source = photo;
            changephoto_bt.Visibility = Visibility.Collapsed;


        }
        private void Home_tb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var x = new Daily_News(ues);
            x.Show();
            this.Close();
        }

        private void Changepassword_tb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Show the TextBox and hide the TextBlock

            profilepassword_lb.Visibility = Visibility.Collapsed;
            passwordTextBox.Visibility = Visibility.Collapsed;
            passwordBox.Visibility = Visibility.Collapsed;
            changepassword_tb.Visibility = Visibility.Collapsed;

            // savepassword_bt.Visibility = Visibility.Visible;

            oldpassword_lb.Visibility = Visibility.Visible;
            oldpasswordBox.Visibility = Visibility.Visible;

            newpassword_lb.Visibility = Visibility.Visible;
            newpasswordBox.Visibility = Visibility.Visible;

            confrimpassword_lb.Visibility = Visibility.Visible;
            confrimpasswordBox.Visibility = Visibility.Visible;

            // Show the save button and hide the edit and eye button
            eye.Visibility = Visibility.Collapsed;
            edit_bt.Visibility = Visibility.Collapsed;
            // save_bt.Visibility = Visibility.Collapsed;
            // savepassword_bt.Visibility = Visibility.Visible;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Update the TextBlock with the new text entered in the TextBox
            string username = username_tb.Text;
            string email = profileemail_tb.Text;
            string phone = phone_tb.Text;
            string pass = passwordBox.Password;


            if (username != usernametxt_tb.Text && email == profileemailtxt_tb.Text && phone == phonetxt_tb.Text && pass == newpasswordBox.Password)
            {
                if (ues.check_valid_username(usernametxt_tb.Text))
                {
                    if (!ues.usernameExist(usernametxt_tb.Text))
                    {
                        if (change)
                        {
                            ues.change_image(usernametxt_tb.Text, bitmap);
                            ues.set_photo(User.imagetoByte(bitmap));
                            change = false;
                        }
                        //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                        ues.ChangeUserName(old_user, usernametxt_tb.Text);
                        ues.change_mail(usernametxt_tb.Text, profileemailtxt_tb.Text);

                        //ues.set_email(profileemailtxt_tb.Text);
                        ues.set_user_name(usernametxt_tb.Text);

                        username_tb.Text = ues.get_user_name();
                        old_user = ues.get_user_name();
                        //profileemail_tb.Text = ues.get_email();
                        //phone_tb.Text = ues.get_phoneno();
                        //passwordBox.Password = ues.get_password();

                        profileemail_tb.Visibility = Visibility.Visible;
                        profileemailtxt_tb.Visibility = Visibility.Collapsed;

                        passwordBox.Visibility = Visibility.Visible;
                        passwordTextBox.Visibility = Visibility.Collapsed;

                        username_tb.Visibility = Visibility.Visible;
                        usernametxt_tb.Visibility = Visibility.Collapsed;

                        phone_tb.Visibility = Visibility.Visible;
                        phonetxt_tb.Visibility = Visibility.Collapsed;

                        changephoto_bt.Visibility = Visibility.Collapsed;
                        // Hide the save button and show the edit button
                        save_bt.Visibility = Visibility.Collapsed;

                        eye.Visibility = Visibility.Visible;

                        changepassword_tb.Visibility = Visibility.Collapsed;

                        edit_bt.Visibility = Visibility.Visible;
                        eye.Visibility = Visibility.Visible;
                        passwordBox.Visibility = Visibility.Visible;


                        //savepassword_bt.Visibility = Visibility.Visible;

                        oldpassword_lb.Visibility = Visibility.Collapsed;
                        oldpasswordBox.Visibility = Visibility.Collapsed;

                        newpassword_lb.Visibility = Visibility.Collapsed;
                        newpasswordBox.Visibility = Visibility.Collapsed;

                        confrimpassword_lb.Visibility = Visibility.Collapsed;
                        confrimpasswordBox.Visibility = Visibility.Collapsed;

                    }
                    else
                    {
                        MessageBox.Show("noooo");
                    }

                }
                else
                {
                    MessageBox.Show("a7a tane");
                }



            }
            else if (username != usernametxt_tb.Text && email == profileemailtxt_tb.Text && phone == phonetxt_tb.Text && pass != confrimpasswordBox.Password)
            {
                if (ues.check_valid_username(usernametxt_tb.Text))
                {
                    if (!ues.usernameExist(usernametxt_tb.Text))
                    {
                        if (ues.Check_valid_Pass(confrimpasswordBox.Password) && ues.Check_valid_Pass(newpasswordBox.Password))
                        {
                            if (change)
                            {
                                ues.change_image(usernametxt_tb.Text, bitmap);
                                ues.set_photo(User.imagetoByte(bitmap));
                                change = false;
                            }

                            //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                            ues.ChangeUserName(old_user, usernametxt_tb.Text);
                            //ues.change_mail(usernametxt_tb.Text, profileemailtxt_tb.Text);
                            ues.changePassword(usernametxt_tb.Text, newpasswordBox.Password);


                            //ues.set_email(profileemailtxt_tb.Text);
                            ues.set_user_name(usernametxt_tb.Text);
                            ues.set_password(newpasswordBox.Password);
                            //ues.set_phone(phonetxt_tb.Text);
                            old_user = ues.get_user_name();

                            username_tb.Text = ues.get_user_name();

                            //profileemail_tb.Text = ues.get_email();
                            //phone_tb.Text = ues.get_phoneno();
                            passwordBox.Password = ues.get_password();
                            passwordTextBox.Text = ues.get_password();

                            profileemail_tb.Visibility = Visibility.Visible;
                            profileemailtxt_tb.Visibility = Visibility.Collapsed;

                            passwordBox.Visibility = Visibility.Visible;
                            passwordTextBox.Visibility = Visibility.Collapsed;

                            username_tb.Visibility = Visibility.Visible;
                            usernametxt_tb.Visibility = Visibility.Collapsed;

                            phone_tb.Visibility = Visibility.Visible;
                            phonetxt_tb.Visibility = Visibility.Collapsed;

                            changephoto_bt.Visibility = Visibility.Collapsed;
                            // Hide the save button and show the edit button
                            save_bt.Visibility = Visibility.Collapsed;

                            eye.Visibility = Visibility.Visible;

                            changepassword_tb.Visibility = Visibility.Collapsed;

                            edit_bt.Visibility = Visibility.Visible;
                            eye.Visibility = Visibility.Visible;
                            passwordBox.Visibility = Visibility.Visible;


                            //savepassword_bt.Visibility = Visibility.Visible;

                            oldpassword_lb.Visibility = Visibility.Collapsed;
                            oldpasswordBox.Visibility = Visibility.Collapsed;

                            newpassword_lb.Visibility = Visibility.Collapsed;
                            newpasswordBox.Visibility = Visibility.Collapsed;

                            confrimpassword_lb.Visibility = Visibility.Collapsed;
                            confrimpasswordBox.Visibility = Visibility.Collapsed;
                        }
                    }
                }

            }
            else if (username != usernametxt_tb.Text && email != profileemailtxt_tb.Text && phone != phonetxt_tb.Text && pass == newpasswordBox.Password)
            {
                if (!ues.usernameExist(usernametxt_tb.Text))
                {
                    if (ues.check_valid_username(usernametxt_tb.Text))
                    {
                        if (!ues.emailExist(profileemailtxt_tb.Text))
                        {
                            if (ues.check_valid_mail(profileemailtxt_tb.Text))
                            {
                                if (ues.Check_valid_PhoneNo(phonetxt_tb.Text))
                                {
                                    if (change)
                                    {
                                        ues.change_image(usernametxt_tb.Text, bitmap);
                                        ues.set_photo(User.imagetoByte(bitmap));
                                        change = false;
                                    }


                                    //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                                    ues.ChangeUserName(old_user, usernametxt_tb.Text);
                                    ues.change_mail(usernametxt_tb.Text, profileemailtxt_tb.Text);
                                    //ues.changePassword(usernametxt_tb.Text, newpasswordBox.Password);


                                    ues.set_email(profileemailtxt_tb.Text);
                                    ues.set_user_name(usernametxt_tb.Text);
                                    //ues.set_password(newpasswordBox.Password);
                                    ues.set_phone(phonetxt_tb.Text);

                                    old_user = ues.get_user_name();

                                    username_tb.Text = ues.get_user_name();
                                    profileemail_tb.Text = ues.get_email();
                                    phone_tb.Text = ues.get_phoneno();
                                    //passwordBox.Password = ues.get_password();
                                    //passwordTextBox.Text = ues.get_password();

                                    profileemail_tb.Visibility = Visibility.Visible;
                                    profileemailtxt_tb.Visibility = Visibility.Collapsed;

                                    passwordBox.Visibility = Visibility.Visible;
                                    passwordTextBox.Visibility = Visibility.Collapsed;

                                    username_tb.Visibility = Visibility.Visible;
                                    usernametxt_tb.Visibility = Visibility.Collapsed;

                                    phone_tb.Visibility = Visibility.Visible;
                                    phonetxt_tb.Visibility = Visibility.Collapsed;

                                    changephoto_bt.Visibility = Visibility.Collapsed;
                                    // Hide the save button and show the edit button
                                    save_bt.Visibility = Visibility.Collapsed;

                                    eye.Visibility = Visibility.Visible;

                                    changepassword_tb.Visibility = Visibility.Collapsed;

                                    edit_bt.Visibility = Visibility.Visible;
                                    eye.Visibility = Visibility.Visible;
                                    passwordBox.Visibility = Visibility.Visible;


                                    //savepassword_bt.Visibility = Visibility.Visible;

                                    oldpassword_lb.Visibility = Visibility.Collapsed;
                                    oldpasswordBox.Visibility = Visibility.Collapsed;

                                    newpassword_lb.Visibility = Visibility.Collapsed;
                                    newpasswordBox.Visibility = Visibility.Collapsed;

                                    confrimpassword_lb.Visibility = Visibility.Collapsed;
                                    confrimpasswordBox.Visibility = Visibility.Collapsed;


                                }
                                else
                                {
                                    MessageBox.Show("no phone");

                                }
                            }
                            else
                            {
                                MessageBox.Show("1");

                            }
                        }
                        else
                        {
                            MessageBox.Show("2");

                        }
                    }
                    else
                    {
                        MessageBox.Show("3");

                    }
                }
                else
                {
                    MessageBox.Show("4");

                }
            }
            else if (username != usernametxt_tb.Text && email != profileemailtxt_tb.Text && phone == phonetxt_tb.Text && pass != newpasswordBox.Password)
            {

                if (!ues.usernameExist(usernametxt_tb.Text))
                {
                    if (ues.check_valid_username(usernametxt_tb.Text))
                    {
                        if (!ues.emailExist(profileemailtxt_tb.Text))
                        {
                            if (ues.check_valid_mail(profileemailtxt_tb.Text))
                            {
                                if (ues.Check_valid_Pass(confrimpasswordBox.Password) && ues.Check_valid_Pass(newpasswordBox.Password))
                                {
                                    if (change)
                                    {
                                        ues.change_image(usernametxt_tb.Text, bitmap);
                                        ues.set_photo(User.imagetoByte(bitmap));
                                        change = false;
                                    }

                                    //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                                    ues.ChangeUserName(old_user, usernametxt_tb.Text);
                                    ues.change_mail(usernametxt_tb.Text, profileemailtxt_tb.Text);
                                    ues.changePassword(usernametxt_tb.Text, newpasswordBox.Password);


                                    ues.set_email(profileemailtxt_tb.Text);
                                    ues.set_user_name(usernametxt_tb.Text);
                                    ues.set_password(newpasswordBox.Password);
                                    //ues.set_phone(phonetxt_tb.Text);
                                    old_user = ues.get_user_name();
                                    username_tb.Text = ues.get_user_name();
                                    profileemail_tb.Text = ues.get_email();
                                    //phone_tb.Text = ues.get_phoneno();
                                    passwordBox.Password = ues.get_password();
                                    passwordTextBox.Text = ues.get_password();

                                    profileemail_tb.Visibility = Visibility.Visible;
                                    profileemailtxt_tb.Visibility = Visibility.Collapsed;

                                    passwordBox.Visibility = Visibility.Visible;
                                    passwordTextBox.Visibility = Visibility.Collapsed;

                                    username_tb.Visibility = Visibility.Visible;
                                    usernametxt_tb.Visibility = Visibility.Collapsed;

                                    phone_tb.Visibility = Visibility.Visible;
                                    phonetxt_tb.Visibility = Visibility.Collapsed;

                                    changephoto_bt.Visibility = Visibility.Collapsed;
                                    // Hide the save button and show the edit button
                                    save_bt.Visibility = Visibility.Collapsed;

                                    eye.Visibility = Visibility.Visible;

                                    changepassword_tb.Visibility = Visibility.Collapsed;

                                    edit_bt.Visibility = Visibility.Visible;
                                    eye.Visibility = Visibility.Visible;
                                    passwordBox.Visibility = Visibility.Visible;


                                    //savepassword_bt.Visibility = Visibility.Visible;

                                    oldpassword_lb.Visibility = Visibility.Collapsed;
                                    oldpasswordBox.Visibility = Visibility.Collapsed;

                                    newpassword_lb.Visibility = Visibility.Collapsed;
                                    newpasswordBox.Visibility = Visibility.Collapsed;

                                    confrimpassword_lb.Visibility = Visibility.Collapsed;
                                    confrimpasswordBox.Visibility = Visibility.Collapsed;
                                }


                            }
                            else
                            {
                                MessageBox.Show("1");

                            }
                        }
                        else
                        {
                            MessageBox.Show("2");

                        }
                    }
                    else
                    {
                        MessageBox.Show("3");

                    }
                }
                else
                {
                    MessageBox.Show("4");

                }
            }
            else if (username != usernametxt_tb.Text && email != profileemailtxt_tb.Text && phone == phonetxt_tb.Text && pass == newpasswordBox.Password)
            {

                if (!ues.usernameExist(usernametxt_tb.Text))
                {
                    if (ues.check_valid_username(usernametxt_tb.Text))
                    {
                        if (!ues.emailExist(profileemailtxt_tb.Text))
                        {
                            if (ues.check_valid_mail(profileemailtxt_tb.Text))
                            {
                                if (change)
                                {
                                    ues.change_image(usernametxt_tb.Text, bitmap);
                                    ues.set_photo(User.imagetoByte(bitmap));
                                    change = false;
                                }
                                ues.ChangeUserName(old_user, usernametxt_tb.Text);
                                ues.change_mail(usernametxt_tb.Text, profileemailtxt_tb.Text);
                                //ues.changePassword(usernametxt_tb.Text, newpasswordBox.Password);


                                ues.set_email(profileemailtxt_tb.Text);
                                ues.set_user_name(usernametxt_tb.Text);
                                //ues.set_password(newpasswordBox.Password);
                                //ues.set_phone(phonetxt_tb.Text);
                                old_user = ues.get_user_name();
                                username_tb.Text = ues.get_user_name();
                                profileemail_tb.Text = ues.get_email();
                                //phone_tb.Text = ues.get_phoneno();
                                //passwordBox.Password = ues.get_password();
                                //passwordTextBox.Text = ues.get_password();

                                profileemail_tb.Visibility = Visibility.Visible;
                                profileemailtxt_tb.Visibility = Visibility.Collapsed;

                                passwordBox.Visibility = Visibility.Visible;
                                passwordTextBox.Visibility = Visibility.Collapsed;

                                username_tb.Visibility = Visibility.Visible;
                                usernametxt_tb.Visibility = Visibility.Collapsed;

                                phone_tb.Visibility = Visibility.Visible;
                                phonetxt_tb.Visibility = Visibility.Collapsed;

                                changephoto_bt.Visibility = Visibility.Collapsed;
                                // Hide the save button and show the edit button
                                save_bt.Visibility = Visibility.Collapsed;

                                eye.Visibility = Visibility.Visible;

                                changepassword_tb.Visibility = Visibility.Collapsed;

                                edit_bt.Visibility = Visibility.Visible;
                                eye.Visibility = Visibility.Visible;
                                passwordBox.Visibility = Visibility.Visible;


                                //savepassword_bt.Visibility = Visibility.Visible;

                                oldpassword_lb.Visibility = Visibility.Collapsed;
                                oldpasswordBox.Visibility = Visibility.Collapsed;

                                newpassword_lb.Visibility = Visibility.Collapsed;
                                newpasswordBox.Visibility = Visibility.Collapsed;

                                confrimpassword_lb.Visibility = Visibility.Collapsed;
                                confrimpasswordBox.Visibility = Visibility.Collapsed;

                            }
                        }
                        else
                        {
                            MessageBox.Show("2");

                        }
                    }
                    else
                    {
                        MessageBox.Show("3");

                    }
                }
                else
                {
                    MessageBox.Show("4");

                }
            }
            else if (username != usernametxt_tb.Text && email == profileemailtxt_tb.Text && phone != phonetxt_tb.Text && pass != confrimpasswordBox.Password)
            {
                if (!ues.usernameExist(usernametxt_tb.Text))
                {
                    if (ues.check_valid_username(usernametxt_tb.Text))
                    {

                        if (ues.check_valid_mail(profileemailtxt_tb.Text))
                        {
                            if (ues.Check_valid_PhoneNo(phonetxt_tb.Text))
                            {
                                if (ues.Check_valid_Pass(confrimpasswordBox.Password) && ues.Check_valid_Pass(newpasswordBox.Password))
                                {
                                    if (change)
                                    {
                                        ues.change_image(usernametxt_tb.Text, bitmap);
                                        ues.set_photo(User.imagetoByte(bitmap));
                                        change = false;
                                    }

                                    //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                                    ues.ChangeUserName(old_user, usernametxt_tb.Text);
                                    //ues.change_mail(usernametxt_tb.Text, profileemailtxt_tb.Text);
                                    ues.changePassword(usernametxt_tb.Text, newpasswordBox.Password);


                                    //ues.set_email(profileemailtxt_tb.Text);
                                    ues.set_user_name(usernametxt_tb.Text);
                                    ues.set_password(newpasswordBox.Password);
                                    ues.set_phone(phonetxt_tb.Text);

                                    old_user = ues.get_user_name();
                                    username_tb.Text = ues.get_user_name();
                                    //profileemail_tb.Text = ues.get_email();
                                    phone_tb.Text = ues.get_phoneno();
                                    passwordBox.Password = ues.get_password();
                                    passwordTextBox.Text = ues.get_password();

                                    profileemail_tb.Visibility = Visibility.Visible;
                                    profileemailtxt_tb.Visibility = Visibility.Collapsed;

                                    passwordBox.Visibility = Visibility.Visible;
                                    passwordTextBox.Visibility = Visibility.Collapsed;

                                    username_tb.Visibility = Visibility.Visible;
                                    usernametxt_tb.Visibility = Visibility.Collapsed;

                                    phone_tb.Visibility = Visibility.Visible;
                                    phonetxt_tb.Visibility = Visibility.Collapsed;

                                    changephoto_bt.Visibility = Visibility.Collapsed;
                                    // Hide the save button and show the edit button
                                    save_bt.Visibility = Visibility.Collapsed;

                                    eye.Visibility = Visibility.Visible;

                                    changepassword_tb.Visibility = Visibility.Collapsed;

                                    edit_bt.Visibility = Visibility.Visible;
                                    eye.Visibility = Visibility.Visible;
                                    passwordBox.Visibility = Visibility.Visible;


                                    //savepassword_bt.Visibility = Visibility.Visible;

                                    oldpassword_lb.Visibility = Visibility.Collapsed;
                                    oldpasswordBox.Visibility = Visibility.Collapsed;

                                    newpassword_lb.Visibility = Visibility.Collapsed;
                                    newpasswordBox.Visibility = Visibility.Collapsed;

                                    confrimpassword_lb.Visibility = Visibility.Collapsed;
                                    confrimpasswordBox.Visibility = Visibility.Collapsed;
                                }

                            }
                            else
                            {
                                MessageBox.Show("no phone");

                            }
                        }
                        else
                        {
                            MessageBox.Show("1");

                        }

                    }
                    else
                    {
                        MessageBox.Show("3");

                    }
                }
                else
                {
                    MessageBox.Show("4");

                }
            }
            else if (username != usernametxt_tb.Text && email == profileemailtxt_tb.Text && phone != phonetxt_tb.Text && pass == confrimpasswordBox.Password)
            {
                if (!ues.usernameExist(usernametxt_tb.Text))
                {
                    if (ues.check_valid_username(usernametxt_tb.Text))
                    {

                        if (ues.Check_valid_Pass(confrimpasswordBox.Password) && ues.Check_valid_Pass(newpasswordBox.Password))
                        {
                            if (change)
                            {
                                ues.change_image(usernametxt_tb.Text, bitmap);
                                ues.set_photo(User.imagetoByte(bitmap));
                                change = false;
                            }

                            //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                            ues.ChangeUserName(old_user, usernametxt_tb.Text);
                            //ues.change_mail(usernametxt_tb.Text, profileemailtxt_tb.Text);
                            //ues.changePassword(usernametxt_tb.Text, newpasswordBox.Password);


                            //ues.set_email(profileemailtxt_tb.Text);
                            ues.set_user_name(usernametxt_tb.Text);
                            //ues.set_password(newpasswordBox.Password);
                            ues.set_phone(phonetxt_tb.Text);
                            old_user = ues.get_user_name();

                            username_tb.Text = ues.get_user_name();
                            //profileemail_tb.Text = ues.get_email();
                            phone_tb.Text = ues.get_phoneno();
                            //passwordBox.Password = ues.get_password();
                            //passwordTextBox.Text = ues.get_password();

                            profileemail_tb.Visibility = Visibility.Visible;
                            profileemailtxt_tb.Visibility = Visibility.Collapsed;

                            passwordBox.Visibility = Visibility.Visible;
                            passwordTextBox.Visibility = Visibility.Collapsed;

                            username_tb.Visibility = Visibility.Visible;
                            usernametxt_tb.Visibility = Visibility.Collapsed;

                            phone_tb.Visibility = Visibility.Visible;
                            phonetxt_tb.Visibility = Visibility.Collapsed;

                            changephoto_bt.Visibility = Visibility.Collapsed;
                            // Hide the save button and show the edit button
                            save_bt.Visibility = Visibility.Collapsed;

                            eye.Visibility = Visibility.Visible;

                            changepassword_tb.Visibility = Visibility.Collapsed;

                            edit_bt.Visibility = Visibility.Visible;
                            eye.Visibility = Visibility.Visible;
                            passwordBox.Visibility = Visibility.Visible;


                            //savepassword_bt.Visibility = Visibility.Visible;

                            oldpassword_lb.Visibility = Visibility.Collapsed;
                            oldpasswordBox.Visibility = Visibility.Collapsed;

                            newpassword_lb.Visibility = Visibility.Collapsed;
                            newpasswordBox.Visibility = Visibility.Collapsed;

                            confrimpassword_lb.Visibility = Visibility.Collapsed;
                            confrimpasswordBox.Visibility = Visibility.Collapsed;
                        }



                    }
                    else
                    {
                        MessageBox.Show("3");

                    }
                }
                else
                {
                    MessageBox.Show("4");

                }
            }
            else if (username == usernametxt_tb.Text && email != profileemailtxt_tb.Text && phone != phonetxt_tb.Text && pass != newpasswordBox.Password)
            {
                if (!ues.emailExist(profileemailtxt_tb.Text))
                {
                    if (ues.check_valid_mail(profileemailtxt_tb.Text))
                    {
                        if (ues.Check_valid_PhoneNo(phonetxt_tb.Text))
                        {
                            if (ues.Check_valid_Pass(confrimpasswordBox.Password) && ues.Check_valid_Pass(newpasswordBox.Password))
                            {
                                if (change)
                                {
                                    ues.change_image(usernametxt_tb.Text, bitmap);
                                    ues.set_photo(User.imagetoByte(bitmap));
                                    change = false;
                                }

                                //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                                //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                                ues.change_mail(usernametxt_tb.Text, profileemailtxt_tb.Text);
                                ues.changePassword(usernametxt_tb.Text, newpasswordBox.Password);


                                ues.set_email(profileemailtxt_tb.Text);
                                //ues.set_user_name(usernametxt_tb.Text);
                                ues.set_password(newpasswordBox.Password);
                                ues.set_phone(phonetxt_tb.Text);

                                //username_tb.Text = ues.get_user_name();
                                profileemail_tb.Text = ues.get_email();
                                phone_tb.Text = ues.get_phoneno();
                                passwordBox.Password = ues.get_password();
                                passwordTextBox.Text = ues.get_password();

                                profileemail_tb.Visibility = Visibility.Visible;
                                profileemailtxt_tb.Visibility = Visibility.Collapsed;

                                passwordBox.Visibility = Visibility.Visible;
                                passwordTextBox.Visibility = Visibility.Collapsed;

                                username_tb.Visibility = Visibility.Visible;
                                usernametxt_tb.Visibility = Visibility.Collapsed;

                                phone_tb.Visibility = Visibility.Visible;
                                phonetxt_tb.Visibility = Visibility.Collapsed;

                                changephoto_bt.Visibility = Visibility.Collapsed;
                                // Hide the save button and show the edit button
                                save_bt.Visibility = Visibility.Collapsed;

                                eye.Visibility = Visibility.Visible;

                                changepassword_tb.Visibility = Visibility.Collapsed;

                                edit_bt.Visibility = Visibility.Visible;
                                eye.Visibility = Visibility.Visible;
                                passwordBox.Visibility = Visibility.Visible;


                                //savepassword_bt.Visibility = Visibility.Visible;

                                oldpassword_lb.Visibility = Visibility.Collapsed;
                                oldpasswordBox.Visibility = Visibility.Collapsed;

                                newpassword_lb.Visibility = Visibility.Collapsed;
                                newpasswordBox.Visibility = Visibility.Collapsed;

                                confrimpassword_lb.Visibility = Visibility.Collapsed;
                                confrimpasswordBox.Visibility = Visibility.Collapsed;
                            }

                        }
                        else
                        {
                            MessageBox.Show("no phone");

                        }
                    }
                    else
                    {
                        MessageBox.Show("1");

                    }
                }
                else
                {
                    MessageBox.Show("2");

                }
            }
            else if (username == usernametxt_tb.Text && email != profileemailtxt_tb.Text && phone != phonetxt_tb.Text && pass == newpasswordBox.Password)
            {
                if (!ues.emailExist(profileemailtxt_tb.Text))
                {
                    if (ues.check_valid_mail(profileemailtxt_tb.Text))
                    {
                        if (ues.Check_valid_PhoneNo(phonetxt_tb.Text))
                        {
                            if (change)
                            {
                                ues.change_image(usernametxt_tb.Text, bitmap);
                                ues.set_photo(User.imagetoByte(bitmap));
                                change = false;
                            }


                            //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                            //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                            ues.change_mail(usernametxt_tb.Text, profileemailtxt_tb.Text);
                            //ues.changePassword(usernametxt_tb.Text, newpasswordBox.Password);


                            ues.set_email(profileemailtxt_tb.Text);
                            //ues.set_user_name(usernametxt_tb.Text);
                            //ues.set_password(newpasswordBox.Password);
                            ues.set_phone(phonetxt_tb.Text);


                            //username_tb.Text = ues.get_user_name();
                            profileemail_tb.Text = ues.get_email();
                            phone_tb.Text = ues.get_phoneno();
                            //passwordBox.Password = ues.get_password();
                            //passwordTextBox.Text = ues.get_password();

                            profileemail_tb.Visibility = Visibility.Visible;
                            profileemailtxt_tb.Visibility = Visibility.Collapsed;

                            passwordBox.Visibility = Visibility.Visible;
                            passwordTextBox.Visibility = Visibility.Collapsed;

                            username_tb.Visibility = Visibility.Visible;
                            usernametxt_tb.Visibility = Visibility.Collapsed;

                            phone_tb.Visibility = Visibility.Visible;
                            phonetxt_tb.Visibility = Visibility.Collapsed;

                            changephoto_bt.Visibility = Visibility.Collapsed;
                            // Hide the save button and show the edit button
                            save_bt.Visibility = Visibility.Collapsed;

                            eye.Visibility = Visibility.Visible;

                            changepassword_tb.Visibility = Visibility.Collapsed;

                            edit_bt.Visibility = Visibility.Visible;
                            eye.Visibility = Visibility.Visible;
                            passwordBox.Visibility = Visibility.Visible;


                            //savepassword_bt.Visibility = Visibility.Visible;

                            oldpassword_lb.Visibility = Visibility.Collapsed;
                            oldpasswordBox.Visibility = Visibility.Collapsed;

                            newpassword_lb.Visibility = Visibility.Collapsed;
                            newpasswordBox.Visibility = Visibility.Collapsed;

                            confrimpassword_lb.Visibility = Visibility.Collapsed;
                            confrimpasswordBox.Visibility = Visibility.Collapsed;


                        }
                        else
                        {
                            MessageBox.Show("no phone");

                        }
                    }
                    else
                    {
                        MessageBox.Show("1");

                    }
                }
                else
                {
                    MessageBox.Show("2");

                }
            }
            else if (username == usernametxt_tb.Text && email != profileemailtxt_tb.Text && phone == phonetxt_tb.Text && pass != newpasswordBox.Password)
            {
                if (ues.check_valid_mail(profileemailtxt_tb.Text))
                {
                    if (!ues.emailExist(profileemailtxt_tb.Text))
                    {
                        if (ues.Check_valid_Pass(confrimpasswordBox.Password) && ues.Check_valid_Pass(newpasswordBox.Password))
                        {

                            if (change)
                            {
                                ues.change_image(usernametxt_tb.Text, bitmap);
                                ues.set_photo(User.imagetoByte(bitmap));
                                change = false;
                            }
                            //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                            //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                            ues.change_mail(usernametxt_tb.Text, profileemailtxt_tb.Text);
                            ues.changePassword(usernametxt_tb.Text, newpasswordBox.Password);


                            //ues.set_user_name(usernametxt_tb.Text);
                            ues.set_password(newpasswordBox.Password);
                            ues.set_email(profileemailtxt_tb.Text);
                            //ues.set_phone(phonetxt_tb.Text);

                            //username_tb.Text = ues.get_user_name();
                            profileemail_tb.Text = ues.get_email();
                            //phone_tb.Text = ues.get_phoneno();
                            passwordBox.Password = ues.get_password();
                            passwordTextBox.Text = ues.get_password();

                            profileemail_tb.Visibility = Visibility.Visible;
                            profileemailtxt_tb.Visibility = Visibility.Collapsed;

                            passwordBox.Visibility = Visibility.Visible;
                            passwordTextBox.Visibility = Visibility.Collapsed;

                            username_tb.Visibility = Visibility.Visible;
                            usernametxt_tb.Visibility = Visibility.Collapsed;

                            phone_tb.Visibility = Visibility.Visible;
                            phonetxt_tb.Visibility = Visibility.Collapsed;

                            changephoto_bt.Visibility = Visibility.Collapsed;
                            // Hide the save button and show the edit button
                            save_bt.Visibility = Visibility.Collapsed;

                            eye.Visibility = Visibility.Visible;

                            changepassword_tb.Visibility = Visibility.Collapsed;

                            edit_bt.Visibility = Visibility.Visible;
                            eye.Visibility = Visibility.Visible;
                            passwordBox.Visibility = Visibility.Visible;


                            //savepassword_bt.Visibility = Visibility.Visible;

                            oldpassword_lb.Visibility = Visibility.Collapsed;
                            oldpasswordBox.Visibility = Visibility.Collapsed;

                            newpassword_lb.Visibility = Visibility.Collapsed;
                            newpasswordBox.Visibility = Visibility.Collapsed;

                            confrimpassword_lb.Visibility = Visibility.Collapsed;
                            confrimpasswordBox.Visibility = Visibility.Collapsed;
                        }
                    }
                    else
                    {
                        MessageBox.Show("a7a");
                    }
                }
                else
                {
                    MessageBox.Show("111");
                }
            }
            else if (username == usernametxt_tb.Text && email == profileemailtxt_tb.Text && phone != phonetxt_tb.Text && pass != newpasswordBox.Password)
            {
                if (ues.Check_valid_PhoneNo(phonetxt_tb.Text))
                {
                    if (ues.Check_valid_Pass(confrimpasswordBox.Password) && ues.Check_valid_Pass(newpasswordBox.Password))
                    {
                        if (change)
                        {
                            ues.change_image(usernametxt_tb.Text, bitmap);
                            ues.set_photo(User.imagetoByte(bitmap));
                            change = false;
                        }

                        //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                        //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                        //ues.change_mail(usernametxt_tb.Text, profileemailtxt_tb.Text);
                        ues.changePassword(usernametxt_tb.Text, newpasswordBox.Password);


                        //ues.set_email(profileemailtxt_tb.Text);
                        //ues.set_user_name(usernametxt_tb.Text);
                        ues.set_password(newpasswordBox.Password);
                        ues.set_phone(phonetxt_tb.Text);

                        //username_tb.Text = ues.get_user_name();
                        //profileemail_tb.Text = ues.get_email();
                        phone_tb.Text = ues.get_phoneno();
                        passwordBox.Password = ues.get_password();
                        passwordTextBox.Text = ues.get_password();

                        profileemail_tb.Visibility = Visibility.Visible;
                        profileemailtxt_tb.Visibility = Visibility.Collapsed;

                        passwordBox.Visibility = Visibility.Visible;
                        passwordTextBox.Visibility = Visibility.Collapsed;

                        username_tb.Visibility = Visibility.Visible;
                        usernametxt_tb.Visibility = Visibility.Collapsed;

                        phone_tb.Visibility = Visibility.Visible;
                        phonetxt_tb.Visibility = Visibility.Collapsed;

                        changephoto_bt.Visibility = Visibility.Collapsed;
                        // Hide the save button and show the edit button
                        save_bt.Visibility = Visibility.Collapsed;

                        eye.Visibility = Visibility.Visible;

                        changepassword_tb.Visibility = Visibility.Collapsed;

                        edit_bt.Visibility = Visibility.Visible;
                        eye.Visibility = Visibility.Visible;
                        passwordBox.Visibility = Visibility.Visible;


                        //savepassword_bt.Visibility = Visibility.Visible;

                        oldpassword_lb.Visibility = Visibility.Collapsed;
                        oldpasswordBox.Visibility = Visibility.Collapsed;

                        newpassword_lb.Visibility = Visibility.Collapsed;
                        newpasswordBox.Visibility = Visibility.Collapsed;

                        confrimpassword_lb.Visibility = Visibility.Collapsed;
                        confrimpasswordBox.Visibility = Visibility.Collapsed;
                    }

                }
                else
                {
                    MessageBox.Show("no phone");

                }
            }
            else if (username == usernametxt_tb.Text && email == profileemailtxt_tb.Text && phone == phonetxt_tb.Text && pass == newpasswordBox.Password)
            {
                if (change)
                {
                    ues.change_image(usernametxt_tb.Text, bitmap);
                    ues.set_photo(User.imagetoByte(bitmap));
                    change = false;
                }
                //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                //ues.change_mail(usernametxt_tb.Text, profileemailtxt_tb.Text);
                //ues.changePassword(usernametxt_tb.Text, newpasswordBox.Password);


                //ues.set_email(profileemailtxt_tb.Text);
                //ues.set_user_name(usernametxt_tb.Text);
                //ues.set_password(newpasswordBox.Password);
                //ues.set_phone(phonetxt_tb.Text);

                //username_tb.Text = ues.get_user_name();
                //profileemail_tb.Text = ues.get_email();
                //phone_tb.Text = ues.get_phoneno();
                //passwordBox.Password = ues.get_password();
                //passwordTextBox.Text = ues.get_password();

                profileemail_tb.Visibility = Visibility.Visible;
                profileemailtxt_tb.Visibility = Visibility.Collapsed;

                passwordBox.Visibility = Visibility.Visible;
                passwordTextBox.Visibility = Visibility.Collapsed;

                username_tb.Visibility = Visibility.Visible;
                usernametxt_tb.Visibility = Visibility.Collapsed;

                phone_tb.Visibility = Visibility.Visible;
                phonetxt_tb.Visibility = Visibility.Collapsed;

                changephoto_bt.Visibility = Visibility.Collapsed;
                // Hide the save button and show the edit button
                save_bt.Visibility = Visibility.Collapsed;

                eye.Visibility = Visibility.Visible;

                changepassword_tb.Visibility = Visibility.Collapsed;

                edit_bt.Visibility = Visibility.Visible;
                eye.Visibility = Visibility.Visible;
                passwordBox.Visibility = Visibility.Visible;


                //savepassword_bt.Visibility = Visibility.Visible;

                oldpassword_lb.Visibility = Visibility.Collapsed;
                oldpasswordBox.Visibility = Visibility.Collapsed;

                newpassword_lb.Visibility = Visibility.Collapsed;
                newpasswordBox.Visibility = Visibility.Collapsed;

                confrimpassword_lb.Visibility = Visibility.Collapsed;
                confrimpasswordBox.Visibility = Visibility.Collapsed;
            }














            else if (username == usernametxt_tb.Text && email != profileemailtxt_tb.Text && phone == phonetxt_tb.Text && pass == newpasswordBox.Password)
            {
                if (ues.check_valid_mail(profileemailtxt_tb.Text))
                {
                    if (!ues.emailExist(profileemailtxt_tb.Text))
                    {
                        if (change)
                        {
                            ues.change_image(usernametxt_tb.Text, bitmap);
                            ues.set_photo(User.imagetoByte(bitmap));
                            change = false;
                        }
                        //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                        ues.change_mail(usernametxt_tb.Text, profileemailtxt_tb.Text);
                        //ues.changePassword(usernametxt_tb.Text, newpasswordBox.Password);


                        ues.set_email(profileemailtxt_tb.Text);
                        //ues.set_user_name(usernametxt_tb.Text);
                        //ues.set_password(newpasswordBox.Password);
                        //ues.set_phone(phonetxt_tb.Text);

                        //username_tb.Text = ues.get_user_name();
                        profileemail_tb.Text = ues.get_email();
                        //phone_tb.Text = ues.get_phoneno();
                        //passwordBox.Password = ues.get_password();
                        //passwordTextBox.Text = ues.get_password();

                        profileemail_tb.Visibility = Visibility.Visible;
                        profileemailtxt_tb.Visibility = Visibility.Collapsed;

                        passwordBox.Visibility = Visibility.Visible;
                        passwordTextBox.Visibility = Visibility.Collapsed;

                        username_tb.Visibility = Visibility.Visible;
                        usernametxt_tb.Visibility = Visibility.Collapsed;

                        phone_tb.Visibility = Visibility.Visible;
                        phonetxt_tb.Visibility = Visibility.Collapsed;

                        changephoto_bt.Visibility = Visibility.Collapsed;
                        // Hide the save button and show the edit button
                        save_bt.Visibility = Visibility.Collapsed;

                        eye.Visibility = Visibility.Visible;

                        changepassword_tb.Visibility = Visibility.Collapsed;

                        edit_bt.Visibility = Visibility.Visible;
                        eye.Visibility = Visibility.Visible;
                        passwordBox.Visibility = Visibility.Visible;


                        //savepassword_bt.Visibility = Visibility.Visible;

                        oldpassword_lb.Visibility = Visibility.Collapsed;
                        oldpasswordBox.Visibility = Visibility.Collapsed;

                        newpassword_lb.Visibility = Visibility.Collapsed;
                        newpasswordBox.Visibility = Visibility.Collapsed;

                        confrimpassword_lb.Visibility = Visibility.Collapsed;
                        confrimpasswordBox.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        MessageBox.Show("a7a");
                    }
                }
                else
                {
                    MessageBox.Show("111");
                }
            }
            else if (username == usernametxt_tb.Text && email == profileemailtxt_tb.Text && phone != phonetxt_tb.Text && pass == newpasswordBox.Password)
            {
                if (ues.Check_valid_PhoneNo(phonetxt_tb.Text))
                {
                    if (change)
                    {
                        ues.change_image(usernametxt_tb.Text, bitmap);
                        ues.set_photo(User.imagetoByte(bitmap));
                        change = false;
                    }
                    //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                    //ues.change_mail(usernametxt_tb.Text, profileemailtxt_tb.Text);

                    //ues.set_email(profileemailtxt_tb.Text);
                    //ues.set_user_name(usernametxt_tb.Text);
                    //ues.set_password(newpasswordBox.Password);
                    ues.set_phone(phonetxt_tb.Text);

                    //username_tb.Text = ues.get_user_name();
                    //profileemail_tb.Text = ues.get_email();
                    phone_tb.Text = ues.get_phoneno();
                    //passwordBox.Password = ues.get_password();

                    profileemail_tb.Visibility = Visibility.Visible;
                    profileemailtxt_tb.Visibility = Visibility.Collapsed;

                    passwordBox.Visibility = Visibility.Visible;
                    passwordTextBox.Visibility = Visibility.Collapsed;

                    username_tb.Visibility = Visibility.Visible;
                    usernametxt_tb.Visibility = Visibility.Collapsed;

                    phone_tb.Visibility = Visibility.Visible;
                    phonetxt_tb.Visibility = Visibility.Collapsed;

                    changephoto_bt.Visibility = Visibility.Collapsed;
                    // Hide the save button and show the edit button
                    save_bt.Visibility = Visibility.Collapsed;

                    eye.Visibility = Visibility.Visible;

                    changepassword_tb.Visibility = Visibility.Collapsed;

                    edit_bt.Visibility = Visibility.Visible;
                    eye.Visibility = Visibility.Visible;
                    passwordBox.Visibility = Visibility.Visible;


                    // savepassword_bt.Visibility = Visibility.Visible;

                    oldpassword_lb.Visibility = Visibility.Collapsed;
                    oldpasswordBox.Visibility = Visibility.Collapsed;

                    newpassword_lb.Visibility = Visibility.Collapsed;
                    newpasswordBox.Visibility = Visibility.Collapsed;

                    confrimpassword_lb.Visibility = Visibility.Collapsed;
                    confrimpasswordBox.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("22");
                }
            }
            else if (username == usernametxt_tb.Text && email == profileemailtxt_tb.Text && phone == phonetxt_tb.Text && pass != confrimpasswordBox.Password)
            {
                if (ues.Check_valid_Pass(confrimpasswordBox.Password) && ues.Check_valid_Pass(newpasswordBox.Password))
                {
                    if (change)
                    {
                        ues.change_image(usernametxt_tb.Text, bitmap);
                        ues.set_photo(User.imagetoByte(bitmap));
                        change = false;
                    }

                    //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                    //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                    //ues.change_mail(usernametxt_tb.Text, profileemailtxt_tb.Text);
                    ues.changePassword(usernametxt_tb.Text, newpasswordBox.Password);


                    //ues.set_email(profileemailtxt_tb.Text);
                    //ues.set_user_name(usernametxt_tb.Text);
                    ues.set_password(newpasswordBox.Password);
                    //ues.set_phone(phonetxt_tb.Text);

                    //username_tb.Text = ues.get_user_name();
                    //profileemail_tb.Text = ues.get_email();
                    //phone_tb.Text = ues.get_phoneno();
                    passwordBox.Password = ues.get_password();
                    passwordTextBox.Text = ues.get_password();

                    profileemail_tb.Visibility = Visibility.Visible;
                    profileemailtxt_tb.Visibility = Visibility.Collapsed;

                    passwordBox.Visibility = Visibility.Visible;
                    passwordTextBox.Visibility = Visibility.Collapsed;

                    username_tb.Visibility = Visibility.Visible;
                    usernametxt_tb.Visibility = Visibility.Collapsed;

                    phone_tb.Visibility = Visibility.Visible;
                    phonetxt_tb.Visibility = Visibility.Collapsed;

                    changephoto_bt.Visibility = Visibility.Collapsed;
                    // Hide the save button and show the edit button
                    save_bt.Visibility = Visibility.Collapsed;

                    eye.Visibility = Visibility.Visible;

                    changepassword_tb.Visibility = Visibility.Collapsed;

                    edit_bt.Visibility = Visibility.Visible;
                    eye.Visibility = Visibility.Visible;
                    passwordBox.Visibility = Visibility.Visible;


                    //savepassword_bt.Visibility = Visibility.Visible;

                    oldpassword_lb.Visibility = Visibility.Collapsed;
                    oldpasswordBox.Visibility = Visibility.Collapsed;

                    newpassword_lb.Visibility = Visibility.Collapsed;
                    newpasswordBox.Visibility = Visibility.Collapsed;

                    confrimpassword_lb.Visibility = Visibility.Collapsed;
                    confrimpasswordBox.Visibility = Visibility.Collapsed;
                }
            }
            else
            {

                // Show the TextBlock and hide the TextBox

                if (!ues.usernameExist(usernametxt_tb.Text))
                {
                    if (ues.check_valid_username(usernametxt_tb.Text))
                    {
                        if (!ues.emailExist(profileemailtxt_tb.Text))
                        {
                            if (ues.check_valid_mail(profileemailtxt_tb.Text))
                            {
                                if (ues.Check_valid_PhoneNo(phonetxt_tb.Text))
                                {
                                    if (ues.Check_valid_Pass(confrimpasswordBox.Password) && ues.Check_valid_Pass(newpasswordBox.Password))
                                    {

                                        if (change)
                                        {
                                            ues.change_image(usernametxt_tb.Text, bitmap);
                                            ues.set_photo(User.imagetoByte(bitmap));
                                            change = false;
                                        }
                                        //ues.ChangeUserName(old_user, usernametxt_tb.Text);
                                        ues.ChangeUserName(old_user, usernametxt_tb.Text);
                                        ues.change_mail(usernametxt_tb.Text, profileemailtxt_tb.Text);
                                        ues.changePassword(usernametxt_tb.Text, newpasswordBox.Password);


                                        ues.set_email(profileemailtxt_tb.Text);
                                        ues.set_user_name(usernametxt_tb.Text);
                                        ues.set_password(newpasswordBox.Password);
                                        ues.set_phone(phonetxt_tb.Text);

                                        old_user = ues.get_user_name();

                                        username_tb.Text = ues.get_user_name();
                                        profileemail_tb.Text = ues.get_email();
                                        phone_tb.Text = ues.get_phoneno();
                                        passwordBox.Password = ues.get_password();
                                        passwordTextBox.Text = ues.get_password();

                                        profileemail_tb.Visibility = Visibility.Visible;
                                        profileemailtxt_tb.Visibility = Visibility.Collapsed;

                                        passwordBox.Visibility = Visibility.Visible;
                                        passwordTextBox.Visibility = Visibility.Collapsed;

                                        username_tb.Visibility = Visibility.Visible;
                                        usernametxt_tb.Visibility = Visibility.Collapsed;

                                        phone_tb.Visibility = Visibility.Visible;
                                        phonetxt_tb.Visibility = Visibility.Collapsed;

                                        changephoto_bt.Visibility = Visibility.Collapsed;
                                        // Hide the save button and show the edit button
                                        save_bt.Visibility = Visibility.Collapsed;

                                        eye.Visibility = Visibility.Visible;

                                        changepassword_tb.Visibility = Visibility.Collapsed;

                                        edit_bt.Visibility = Visibility.Visible;
                                        eye.Visibility = Visibility.Visible;
                                        passwordBox.Visibility = Visibility.Visible;


                                        //savepassword_bt.Visibility = Visibility.Visible;

                                        oldpassword_lb.Visibility = Visibility.Collapsed;
                                        oldpasswordBox.Visibility = Visibility.Collapsed;

                                        newpassword_lb.Visibility = Visibility.Collapsed;
                                        newpasswordBox.Visibility = Visibility.Collapsed;

                                        confrimpassword_lb.Visibility = Visibility.Collapsed;
                                        confrimpasswordBox.Visibility = Visibility.Collapsed;
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("no phone");

                                }
                            }
                            else
                            {
                                MessageBox.Show("1");

                            }
                        }
                        else
                        {
                            MessageBox.Show("2");

                        }
                    }
                    else
                    {
                        MessageBox.Show("3");

                    }
                }
                else
                {
                    MessageBox.Show("4");

                }


            }
           
        }

        private void edit_Click_1(object sender, RoutedEventArgs e)
        {
            // Show the TextBox and hide the TextBlock

            usernametxt_tb.Visibility = Visibility.Visible;
            username_tb.Visibility = Visibility.Collapsed;

            profileemailtxt_tb.Visibility = Visibility.Visible;
            profileemail_tb.Visibility = Visibility.Collapsed;

            phonetxt_tb.Visibility = Visibility.Visible;
            phone_tb.Visibility = Visibility.Collapsed;

            passwordTextBox.Visibility = Visibility.Visible;
            passwordBox.Visibility = Visibility.Collapsed;
            changephoto_bt.Visibility = Visibility.Visible;

            // Set the text of the TextBox to the current text of the TextBlock

            passwordTextBox.Text = passwordBox.Password;

            profileemailtxt_tb.Text = profileemail_tb.Text;

            phonetxt_tb.Text = phone_tb.Text;

            usernametxt_tb.Text = username_tb.Text;

            // Show the save button and hide the edit button

            changepassword_tb.Visibility = Visibility.Visible;

            save_bt.Visibility = Visibility.Visible;

            eye.Visibility = Visibility.Collapsed;

            changepassword_tb.Visibility = Visibility.Visible;

            (sender as Button).Visibility = Visibility.Collapsed;
        }

        private void eye_Click(object sender, RoutedEventArgs e)
        {
            var brush = new ImageBrush();
           

            if (passwordBox.Visibility == Visibility.Visible)
            {
                // Show the password
                passwordTextBox.Text = ues.get_password();
                passwordBox.Visibility = Visibility.Collapsed;
                passwordTextBox.Visibility = Visibility.Visible;
                brush.ImageSource = new BitmapImage(new Uri(@"E:\Newsify\Resources\view.png", UriKind.Relative));

                (sender as Button).Background = brush;
            }
            else
            {
                // Hide the password
                passwordBox.Password = ues.get_password();
                passwordBox.Visibility = Visibility.Visible;
                passwordTextBox.Visibility = Visibility.Collapsed;
                brush.ImageSource = new BitmapImage(new Uri(@"E:\Newsify\Resources\hide.png", UriKind.Relative));

                (sender as Button).Background = brush;
            }
        }
        private void changephoto_bt_Click(object sender, RoutedEventArgs e)
        {
            change = true;
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
                profilephoto.Source = bitmap;
                profilephoto.Width = 170;
                profilephoto.Height = 190;
                profilephoto.Stretch = Stretch.Uniform;
                //selectprofile_image.Stretch = Stretch.Uniform;
                profilephoto.HorizontalAlignment = HorizontalAlignment.Center;
                profilephoto.VerticalAlignment = VerticalAlignment.Center;


            }




        }
    }
    }
