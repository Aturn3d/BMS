using System;
using Core.BookmarkImport;
using DataAccess.Repositories;
using DataAccess.Infrastructure;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDb();

        }

        private static void TestImport()
        {
        }

        public static void TestDb()
        {
            var bms = new BookmarkRepository(new DatabaseFactory()).GetAll().First();
            bms.Name.ToConsole();
            bms.URL.ToConsole();
        }
    }

    public static class Ext
    {
        public static void ToConsole(this object obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }
}
