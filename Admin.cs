using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newssify;
using Newsify;
using System.Windows.Media.Imaging;

namespace Newsify
{
  public  class Admin : Person
    {
        public  bool add_new_category(string cate)

        {
            bool flag = true;
            for (int i = 0; i < News.categories.Count(); i++)
            {
                if (News.categories[i].ToLower() == cate.ToLower())
                {
                    flag = false;
                }
            }
            if (flag)
            {
                News.categories.Add(cate);
            }

            return flag;
        }
        public void AddNew(string newtitle, string newDescription, string cat, string new_author, BitmapImage image, DateTime time)
        {
            int new_id  ;
            if (News.news_data.Count == 0)
            {
                new_id = 1;
            }
            else
            {
                new_id =News.get_max_new_id();
            }
           

            News n = new News();


            n.set_id(new_id);
            n.set_title(newtitle);
            n.set_description(newDescription);
            n.set_category(cat);
            n.set_author(new_author);
            n.set_photo(imagetoByte(image));
            n.set_rate(5);
            n.set_time(time);
            n.set_no_user(1);
           
            News.news_data.Add(n);
        }
        public void Updat_existing_news(int news_id, string titel, string dis, string cat, string author, BitmapImage photo, DateTime news_time)
        {
            for (int i = 0; i < News.news_data.Count(); i++)
            {
                if (News.news_data[i].get_id() == news_id)
                {
                    News.news_data[i].set_title(titel);
                    News.news_data[i].set_description(dis);
                    News.news_data[i].set_category(cat);
                    News.news_data[i].set_author(author);
                    News.news_data[i].set_photo(imagetoByte(photo));
                    News.news_data[i].set_time(news_time);
                }
            }
        }


        public void remove_user(string username)
        {
            for (int i = 0; i < persons_data.Count(); i++)
            {
                if (persons_data[i].get_user_name().ToLower() == username.ToLower())
                {
                    persons_data.RemoveAt(i);
                }
            }
            foreach (KeyValuePair<int, List<(string, string)>> comment in News.comments)
            {
                for (int i = 0; i < comment.Value.Count; i++)
                {
                    if (comment.Value[i].Item1.ToLower() == username.ToLower())
                    {
                        comment.Value.RemoveAt(i);
                        i--;
                    }
                }
            }
            News.spam.Remove(username);
            map_of_perosn.Remove(username);

        }
        public void RemoveNew(int newid)
        {


            for (int i = 0; i < News.news_data.Count; i++)
            {

                if (News.news_data[i].get_id() == newid)
                {

                    News.news_data.RemoveAt(i);
                    break;
                }
            }

            foreach(string user in News.spam.Keys)
            {
                if (News.spam[user].Contains(newid))
                {
                    News.spam[user].Remove(newid);
                    
                }

            }


           


            if (News.comments.ContainsKey(newid))
            {
                News.comments.Remove(newid);
            }

        }


        public void change_New_image(int id, BitmapImage image)
        {
            for (int i = 0; i < News.news_data.Count; i++)
            {
                if (id == News.news_data[i].get_id())
                {
                    News.news_data[i].set_photo(imagetoByte(image));
                    break;
                }

            }
        }

    }
}
