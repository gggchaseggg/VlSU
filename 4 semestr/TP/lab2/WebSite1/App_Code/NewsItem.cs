using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class NewsItem
{
    private string title;
    private string text;
    private string author;
    private int articleRating;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    public string Text
    {
        get { return text; }
        set { text = value; }
    }
    public string Author
    {
        get { return author; }
        set { author = value; }
    }
    public int ArticleRating
    {
        get { return articleRating; }
        set { articleRating = value; }
    }

    public NewsItem()
    {
        Random rnd = new Random();
        this.ArticleRating = rnd.Next(5);
    }
}