﻿namespace BooksApi.DAL
{
    public class DAL_Helper
    {

        public static string ConnString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");

    }
}
