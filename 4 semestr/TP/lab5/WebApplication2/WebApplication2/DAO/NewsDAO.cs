using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using WebApplication2.Models;

namespace WebApplication2.DAO
{
    public class NewsDAO : DAO
    {
        public List<News> GetAllNews()
        {
            Connect();
            List<News> NewsList = new List<News>();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM News", Connection);
                MySqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    News record = new News();
                    record.ID = Convert.ToInt32(reader["ID"]);
                    record.Title = Convert.ToString(reader["Title"]);
                    record.Text = Convert.ToString(reader["Tekst"]);
                    record.Raiting =Convert.ToInt32(reader["Raiting"]);
                    NewsList.Add(record);
                }
                reader.Close();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }finally
            {
                Disconnect();
            }
            return NewsList;
        }

        public News GetNews(int id)
        {
            Connect();
            News Novost = new News();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM News WHERE ID = " + id, Connection);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Novost.ID = Convert.ToInt32(reader["ID"]);
                Novost.Title = Convert.ToString(reader["Title"]);
                Novost.Text = Convert.ToString(reader["Tekst"]);
                Novost.Raiting = Convert.ToInt32(reader["Raiting"]);
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Disconnect();
            }
            return Novost;
        }

        public bool AddNews(News news)
        {
            bool result = true;
            Connect();
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT News(title, tekst, raiting) VALUES (@title, @tekst, @raiting)",Connection);
                cmd.Parameters.Add(new MySqlParameter("@title",news.Title));
                cmd.Parameters.Add(new MySqlParameter("@tekst",news.Text));
                cmd.Parameters.Add(new MySqlParameter("@raiting",news.Raiting));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
    
        public bool EditNews(News news)
        {
            bool result = true;
            Connect();
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE News SET " +
                    "title = @title, tekst = @text, raiting = @raiting " +
                    "WHERE ID = 4", Connection);
                cmd.Parameters.Add(new MySqlParameter("@title", news.Title));
                cmd.Parameters.Add(new MySqlParameter("@text", news.Text));
                cmd.Parameters.Add(new MySqlParameter("@raiting", news.Raiting));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
            return result;
        }

        public bool DeleteNews(int id)
        {
            Connect();
            bool result = true;
            try
            {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM news WHERE ID = " + id, Connection);
                cmd.ExecuteNonQuery();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }

    }
}