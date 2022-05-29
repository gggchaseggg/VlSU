using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using MySql.Data.MySqlClient;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
    public class NewsModel : PageModel
    {
        private string connectionString = "server=localhost;user id=root;Password=daniil;persistsecurityinfo=True;" +
                                          "port=3306;;database=newslist;CharSet=utf8";
        public static List<News> newsList = new List<News>();
        public List<News> NewsList{get { return newsList; }}
        [BindProperty]
        public News formNews { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = $"INSERT news(title, tekst, raiting) VALUES ('{formNews.title}','{formNews.text}',{formNews.raiting})";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Page();
        }
        public MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return null;
        }



    }
}