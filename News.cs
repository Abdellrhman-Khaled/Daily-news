using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Media.Imaging;

namespace Newssify
{
   class News
    {
        private int News_id;
        private string title;
        private string description;
        private string category;
        private string author;
        private byte[] photo;
        private double rate;
        private DateTime News_time;
        private int no_of_users;
        public static List<News> news_data;
        public static Dictionary<string, HashSet<int>> spam;
        public static Dictionary<int, List<(string, string)>> comments;
        public static List<string> categories;



        static News()
        {
            SQLiteConnection conn = new SQLiteConnection(@"Datasource=E:\Newsify\database.db");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            








            cmd.Connection = conn;
            cmd.CommandText = "select * from News";
            cmd.CommandType = System.Data.CommandType.Text;

            SQLiteDataReader dr = cmd.ExecuteReader();
            news_data = new List<News>();
            spam = new Dictionary<string, HashSet<int>>();
            comments = new Dictionary<int, List<(string, string)>>();

            while (dr.Read())
            {
                News n = new News
                {
                    News_id = Convert.ToInt32(dr[0]),
                    title = dr[1].ToString(),
                    description = dr[2].ToString(),
                    category = dr[3].ToString(),
                    author = dr[4].ToString(),
                    photo = (byte[])dr[5],
                    rate = Convert.ToDouble(dr[6]),
                    News_time = Convert.ToDateTime(dr[7]),
                    no_of_users = Convert.ToInt32(dr[8])


                };
                news_data.Add(n);

            }


            SQLiteCommand cmd2 = new SQLiteCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select * from spam";
            cmd2.CommandType = System.Data.CommandType.Text;
            SQLiteDataReader dr2 = cmd2.ExecuteReader();

            while (dr2.Read())
            {
                if (!spam.ContainsKey(dr2[1].ToString()))
                {
                    spam.Add(dr2[1].ToString(), new HashSet<int>());
                }

                spam[dr2[1].ToString()].Add(Convert.ToInt32(dr2[0]));
            }


            SQLiteCommand cmd3 = new SQLiteCommand();
            cmd3.Connection = conn;
            cmd3.CommandText = "select * from comments";
            cmd3.CommandType = System.Data.CommandType.Text;
            SQLiteDataReader dr3 = cmd3.ExecuteReader();

            while (dr3.Read())
            {
                if (!comments.ContainsKey(Convert.ToInt32(dr3[0])))
                {
                    comments.Add(Convert.ToInt32(dr3[0]), new List<(string, string)>());

                }

                comments[Convert.ToInt32(dr3[0])].Add((dr3[1].ToString(), dr3[2].ToString()));
            }


            categories = new List<string>();
            SQLiteCommand cmd4 = new SQLiteCommand();
            cmd4.Connection = conn;
            cmd4.CommandText="select * from categories";
            cmd4.CommandType = System.Data.CommandType.Text;

            SQLiteDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                categories.Add(dr4[0].ToString());
            }




            dr4.Close();
            dr3.Close();
            dr2.Close();
            dr.Close();
            conn.Close();

        }

        public static News get_new(string id)
        {
            // New data= new New();
            int x = Convert.ToInt32(id);
            int y = 0;
            for (int i = 0; i < news_data.Count; i++)
            {
                if (x == news_data[i].News_id)
                {
                    y = i;
                    break;
                }

            }
            return news_data[y];
        }

        //public static List<string> list_category()
        //{
        //    List<string> list = new List<string>();
        

        //    Dictionary<string, int> dic = new Dictionary<string, int>();
        //    for (int i = 0; i < news_data.Count; i++)
        //    {
        //        if (dic.ContainsKey(news_data[i].category))
        //        {
        //            continue;
        //        }
        //        dic.Add(news_data[i].category, i + 1);
        //    }

        //    foreach (string x in dic.Keys)
        //    {
        //        list.Add(x);

        //    }
        //    return list;
        //}


        private static byte[] imagetoByte(BitmapImage image)
             
        {
            MemoryStream memStream = new MemoryStream();
            BitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            encoder.Save(memStream);
            return memStream.ToArray();
        }

       

        public static List<News> GetDataNewss()
        {
            return news_data;
        }

        


        public int get_id()
        {
            return News_id;
        }
        public void set_id(int id)
        {
            this.News_id = id;
        }

        public string get_title()
        {
            return title;
        }
        public void set_title(string title)
        {
            this.title = title;
        }

        public string get_description()
        {
            return description;
        }
        public void set_description(string desc)
        {
            this.description = desc;
        }

        public string get_category()
        {
            return category;
        }
        public void set_category(string cat)
        {
            this.category = cat;
        }
        public string get_author()
        {
            return author;
        }
        public void set_author(string auth)
        {
            this.author = auth;
        }

        public double get_rate()
        {
            return rate;
        }
        public void set_rate(double r)
        {
            this.rate = r;
        }

        public int get_no_users()
        {
            return no_of_users;
        }
        public void set_no_user(int n)
        {
            this.no_of_users = n;
        }

        public DateTime get_time()
        {
            return News_time;
        }
        public void set_time(DateTime T)
        {
            News_time = T;
        }
        public byte[] get_photo()
        {
            return this.photo;
        }
        public void set_photo(byte[] p)
        {
            this.photo = p;
        }

        public static List<(string,string)> GetCommentsData(int id)
        {

            if (comments.ContainsKey(id))
            {
                return comments[id];
            }
            else
            {
                return null;
            }

            

        }
        public static void save_cateories_to_database()
        {
            SQLiteConnection conn = new SQLiteConnection(@"Datasource=E:\Newsify\database.db");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from categories";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into categories values (@cat)";
            cmd.CommandType = System.Data.CommandType.Text;

            for(int i = 0; i < categories.Count; i++)
            {
                cmd.Parameters.AddWithValue("@cat", categories[i]);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            conn.Close();

        }
        public static void save_news_to_database()
        {
            SQLiteConnection conn = new SQLiteConnection(@"Datasource=E:\Newsify\database.db");
            conn.Open();
            SQLiteCommand cmd =new SQLiteCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from news";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into news values (@id,@title,@description,@category,@author,@photo,@rate,@time,@no_users)";
            cmd.CommandType = System.Data.CommandType.Text;

            for(int i = 0; i < news_data.Count; i++)
            {
                cmd.Parameters.AddWithValue("@id", news_data[i].News_id);
                cmd.Parameters.AddWithValue("@title", news_data[i].title);
                cmd.Parameters.AddWithValue("@description", news_data[i].description);
                cmd.Parameters.AddWithValue("@category", news_data[i].category);
                cmd.Parameters.AddWithValue("@author", news_data[i].author);
                cmd.Parameters.AddWithValue("@photo", news_data[i].photo);
                cmd.Parameters.AddWithValue("@rate", news_data[i].rate);
                cmd.Parameters.AddWithValue("@time", news_data[i].News_time);
                cmd.Parameters.AddWithValue("@no_users", news_data[i].no_of_users);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            conn.Close();

        }

        public static void save_comments_to_database()
        {
            SQLiteConnection conn = new SQLiteConnection(@"Datasource=E:\Newsify\database.db");
            conn.Open();

            SQLiteCommand insert = new SQLiteCommand();
            insert.Connection = conn;
            insert.CommandText = "delete from comments";
            insert.ExecuteNonQuery();

            insert.CommandText = "insert into comments values(@new_id, @user_name, @user_comment)";


            foreach (var pair in comments)
            {
                foreach (var tuple in pair.Value)
                {
                    insert.Parameters.AddWithValue("@new_id", pair.Key);
                    insert.Parameters.AddWithValue("@user_name", tuple.Item1);
                    insert.Parameters.AddWithValue("@user_comment", tuple.Item2);
                    insert.ExecuteNonQuery();
                    insert.Parameters.Clear();

                }
            }

            conn.Close();
        }

        public static int get_max_new_id() {

            int max = -1;

            for(int i = 0; i < news_data.Count; i++)
            {
                if (news_data[i].get_id() >= max)
                {
                    max = news_data[i].get_id();
                }
            }
            return max + 1;

        }


        public static void save_categories_to_database()
        {
            SQLiteConnection conn = new SQLiteConnection(@"Datasource=E:\Newsify\database.db");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from categories";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into categories values (@cat)";
            cmd.CommandType = System.Data.CommandType.Text;
            for(int i = 0; i < categories.Count; i++)
            {
                cmd.Parameters.AddWithValue("@cat", categories[i]);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            conn.Close();

        }
         
        public static void save_spam_to_database()
        {
            SQLiteConnection conn = new SQLiteConnection(@"Datasource=E:\Newsify\database.db");
            conn.Open();
            SQLiteCommand cmd4 = new SQLiteCommand();
            cmd4.Connection = conn;
            cmd4.CommandType = System.Data.CommandType.Text;
            cmd4.CommandText = "DELETE FROM spam";
            cmd4.ExecuteNonQuery();

            foreach (KeyValuePair<string, HashSet<int>> spams in spam)
            {
                string username = spams.Key;
                HashSet<int> newid = spams.Value;

                foreach (int id in newid)
                {
                    cmd4.CommandText = "INSERT INTO spam (new_id, user_name) VALUES (@newId, @userName)";
                    cmd4.Parameters.AddWithValue("@newId", id);
                    cmd4.Parameters.AddWithValue("@userName", username);
                    cmd4.ExecuteNonQuery();
                    cmd4.Parameters.Clear();
                }
            }
            conn.Close();

        }

        public static List<string> exist_cat(List<News> n , List<string> cat)
        {
            List<string> new_cat = new List<string>();
            for(int i = 0; i < cat.Count; i++)
            {
                foreach(News ne in n)
                {
                    if (ne.category.ToLower() == cat[i].ToLower())
                    {
                        new_cat.Add(cat[i]);
                        break;

                    }

                }
            }
            return new_cat;

        }

        public static List<News> Display_by_latest_News(List<News> sorted_Newss)
        {
            List<News> sorted_Newss2 = new List<News>();

            sorted_Newss2.AddRange(sorted_Newss);

            // < 0 − If date1 is earlier than date2
            // 0 − If date1 is the same as date2
            // > 0 − If date1 is later than date2
            for (var i = 0; i < sorted_Newss.Count; i++)
            {
                for (var j = i + 1; j < sorted_Newss.Count; j++)
                {
                    News temp;
                    int ret_time = DateTime.Compare(sorted_Newss2[i].get_time(), sorted_Newss2[j].get_time());
                    if (ret_time < 0)
                    {
                        temp = sorted_Newss2[j];
                        sorted_Newss2[j] = sorted_Newss2[i];
                        sorted_Newss2[i] = temp;
                    }


                }


            }

            return sorted_Newss2;

        }
       
        public static List<News> filterUserSpammed(List<News> n, String user_name)
        {


            if (!spam.ContainsKey(user_name))
            {
                return n;
            }

            
                for (int j = 0; j < n.Count; j++)
                {
                    if (spam[user_name].Contains(n[j].News_id))
                    {
                        n.RemoveAt(j);
                        j--;
                    }
                }
            

            return n;


        }

        public static List<News> Sort_by_Rate_Descendingly(List<News> filtered_news)
        {

            // Sorting filtered_news desc. by rate using bubble sort algorithm.
            for (int i = 0; i < filtered_news.Count - 1; i++)
            {
                for (int j = i + 1; j < filtered_news.Count; j++)
                {
                    if (filtered_news[j].get_rate() > filtered_news[i].get_rate())
                    {
                        News temp = filtered_news[i];
                        filtered_news[i] = filtered_news[j];
                        filtered_news[j] = temp;
                    }
                }
            }



            // Returns filtered_sorted_news
            return filtered_news;
        }


        public static List<News> sort_rate_ascendingly(List<News> newsrate)
        {
            List<News> sorted_by_rate = new List<News>(newsrate);

            for (int i = 1; i < sorted_by_rate.Count; i++)
            {
                News key = sorted_by_rate[i];
                int j = i - 1;
                while (j >= 0 && sorted_by_rate[j].get_rate() > key.get_rate())
                {
                    sorted_by_rate[j + 1] = sorted_by_rate[j];
                    j--;
                }
                sorted_by_rate[j + 1] = key;
            }

            return sorted_by_rate;
        }

        public static List<News> Filter_and_Sort_by_Category(List<News> news ,string category)
        {
            List<News> filtered_news = new List<News>();
            // Getting a list of filtered_news according to given category
            foreach (News n in news)
            {
                if (n.get_category().ToLower() == category.ToLower())
                {
                    filtered_news.Add(n);
                }
            }

            //sorting news by latest using Display_by_latest_News in News class
            //filtered_news = News.Display_by_latest_News(filtered_news);

            // Returns filtered_sorted_news

            return filtered_news;
        }

        public static List<News> hide_below_2(List<News> news)
        {
            /*List<New> copy = new List<New>();
            copy.AddRange(news);*/

            for (int i = 0; i < news.Count; i++)
            {
                if (news[i].rate < 2)
                {
                    news.RemoveAt(i);
                    i--;
                }
            }
            return news;
        }

        public static void deleteSpam()
        {
            Dictionary<int, int> countDict = new Dictionary<int, int>();
            List<int> repeated = new List<int>();

            // Loop through all keys in the spam dictionary
            foreach (string key in spam.Keys)
            {

                // Loop through all values in the spam dictionary
                foreach (int value in spam[key])
                {
                    // If the value is already in the count dictionary, increment its count
                    if (countDict.ContainsKey(value))
                    {
                        countDict[value]++;
                    }
                    // Otherwise, add the value to the count dictionary with a count of 1
                    else
                    {
                        countDict.Add(value, 1);
                    }
                }


                // Loop through all keys in the count dictionary
                foreach (int value in countDict.Keys)
                {
                    // If the value has been repeated more than 5 times, add it to the repeated list
                    if (countDict[value] >= 5)
                    {
                        repeated.Add(value);
                    }
                }
            }

            /////////////////////////////
            int[] arr = repeated.ToArray();


         

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < news_data.Count; j++)
                {
                    if (arr[i] == news_data[j].News_id)
                    {
                        news_data.RemoveAt(j);
                    }
                }

            }


            repeated.Clear();
            countDict.Clear();

        }




        public static List<News> Display_based_on_specific_title(List<News> Newss, string s)
        {

            List<News> nw = new List<News>();

            for (int i = 0; i < Newss.Count; i++)
            {
                if (Newss[i].title.ToLower().Contains(s.ToLower()))
                {
                    nw.Add(Newss[i]);
                }
            }

          

            return nw;

        }

    }
}
