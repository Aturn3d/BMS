using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.BookmarkImport;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\Projects\BMS\Core.Tests\ImportTests\TestFiles\chromeBookmark.html";
            var importer = new HtmlBookmarkImporter();
            var list = importer.Import(path);
           
        }
    }
}
