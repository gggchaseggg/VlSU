namespace WebApplication1.Domain
{
    public static class Base
    {
        private static String ConnectionString
        {
            get { return "server=localhost;user id=root;password=daniil;persistsecurityinfo=True;port=3306;database=newslist;CharSet=utf8"; }
        }

        public static string strConnect
        {
            get
            { return System.Configuration.ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString; }
        }
    }
}
