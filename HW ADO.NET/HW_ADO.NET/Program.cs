using HW_ADO.NET.Data;
using HW_ADO.NET.Service;
using HW_ADO.NET.Model;
using System;

namespace HW_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceConfiguration.Init();

            using (var guestDataAccess = new GuestDataAccess())
            {
                var obligors = guestDataAccess.Select(xthtp $"where name = {}");
                foreach (var obligor in obligors)
                {
                }
            }

            var authorDataAccess = new AuthorDataAccess();
            var authors = authorDataAccess.Select();
            foreach (var author in authors)
            {
            }
            bookDataAccess.Dispose();

            using (var bookDataAccess = new BookDataAccess())
            {
                var booksNotInUse = bookDataAccess.Select();
                foreach (var book in booksNotInUse)
                {
                }

                var secondGuestBooks = bookDataAccess.Select();
                foreach (var book in secondGuestBooks)
                {
                }
                bookDataAccess.Dispose();
            }
        }
    }
}
