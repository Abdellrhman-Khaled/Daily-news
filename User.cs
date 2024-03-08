using Newssify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Newsify
{
   public class User : Person
    {
        public void changePassword(String usernmae, String newPassword)
        {
            for (int i = 0; i < persons_data.Count; i++)
            {

                if (persons_data[i].get_user_name().ToLower() == usernmae.ToLower())
                {
                    persons_data[i].set_password(newPassword);
                }
            }
        }
		

		

		public void insertRate(int neww, double rate)
        {
            foreach (News n in News.news_data)
            {
                if ( n.get_id() == neww)
                {
                    n.set_no_user(n.get_no_users() + 1);
                    //n.set_rate((n.get_rate() + rate) / n.get_no_users());
                    String x = string.Format("{0:0.0}", (n.get_rate() + rate) / n.get_no_users());
                    n.set_rate(double.Parse(x));

                    break;
                }
            }

        }
        public  void add_spam(string username, int news_id)
        {


            if (News.spam.ContainsKey(username))
            {
                News.spam[username].Add(news_id);

            }
            else
            {
                News.spam.Add(username, new HashSet<int> { news_id });
            }

        }
        public  void AddComment(int news_id, string username, string comment)
		{

			//checks if new_id doesn't exist then it adds it
			if (!News.comments.ContainsKey(news_id))
			{
				News.comments.Add(news_id, new List<(string, string)>());
			}


			//when key exists the comment and username are added to it
			News.comments[news_id].Add((username, comment));

		}
        public bool forget_password(string email, string phone_number, string new_pass)
        {
              for (int i = 0; i < persons_data.Count; i++)
                {
                    if ((persons_data[i].get_email().ToLower().Equals(email.ToLower())) && (persons_data[i].get_phoneno().Equals(phone_number)))
                    {
                        persons_data[i].set_password(new_pass);
                        return true;
                    }
                }
            
            return false;
        }

        public void change_mail(String username, String new_mail)
		{
			foreach (Person p in persons_data)
			{
				if (p.get_user_name().ToLower() == username.ToLower())
				{
					p.set_email(new_mail);
				}
			}
		}

        public void change_image(string username,BitmapImage image)
        {
           for(int i = 0; i < persons_data.Count; i++)
            {
                if (username.ToLower() == persons_data[i].get_user_name().ToLower())
                {
                    persons_data[i].set_photo(imagetoByte(image));
                    break;
                }
               
            }
        }
        public void ChangeUserName(string userName, string nw_userName)
        {


            int idx = map_of_perosn[userName];

            map_of_perosn.Remove(userName);

            map_of_perosn[nw_userName] = idx;

            persons_data[idx].set_user_name(nw_userName);
            if (News.spam.ContainsKey(userName))
            {


                if (News.spam[userName].Count != 0)
                {
                    News.spam[nw_userName] = News.spam[userName];
                    News.spam.Remove(userName);
                }

            }

            foreach (KeyValuePair<int, List<(string, string)>> comment in News.comments)
            {
                for (int i = 0; i < comment.Value.Count; i++)
                {
                    if (comment.Value[i].Item1 == userName)
                    {
                        comment.Value[i] = (nw_userName, comment.Value[i].Item2);
                    }
                }
            }
        }



    }
}
