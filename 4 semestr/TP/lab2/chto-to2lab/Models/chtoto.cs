namespace chto_to2lab.Models{
public class NewsItem {
    private string title;
    private string author;
    private string text;
    private int articleRating;
    
    public string Title {
        get { return title; }
        set { title = value; }
    }
    public string Text {
        get { return text; }
        set { text = value; }
    }
    public string Author {
        get { return author; }
        set { author = value; }
    }
    public int ArticleRating {
        get { return articleRating; }
        set { articleRating = value; }
    }
    public NewsItem() {
        Random rnd = new Random();
        this.ArticleRating = rnd.Next(5);
    }
}
}

