using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для Tovar
/// </summary>
public class Tovar
{
    private string Title { get; set; }
    private string Description { get; set; }
    private int Price { get; set; }

    public Tovar()
    {
        Random rnd = new Random();
        this.Price = rnd.Next(105);
    }
}