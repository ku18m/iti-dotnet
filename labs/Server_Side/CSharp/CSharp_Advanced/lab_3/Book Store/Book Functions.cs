﻿using System.Globalization;

namespace Book_Store
{
    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return B.Title;
        }
        public static string GetAuthors(Book B)
        {
            return string.Join(", ", B.Authors);
        }
        public static string GetPrice(Book B)
        {
            return B.Price.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}
