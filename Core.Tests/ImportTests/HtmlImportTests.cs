using System.IO;
using System.Reflection;
using Core.BookmarkImport;
using NUnit.Framework;

namespace Core.Tests.ImportTests
{
    [TestFixture]
    public class HtmlImportTests
    {
        [Test]
        public void ImportTest()
        {
            var fileName = "chromeBookmark.html";
            var dir = Assembly.GetExecutingAssembly().Location;
            dir += @"\..\..\..\ImportTests\TestFiles\" + fileName;
            var path = Path.GetFullPath(dir);
            var importer = new HtmlBookmarkImporter();
            var list = importer.Import(path);
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("Лайфхакер", list[2].Title);
        }

        [Test]
        public void NoFile()
        {
            var testFilePath = "NoTestFile.html";
            var importer = new HtmlBookmarkImporter();
            Assert.Throws<FileNotFoundException>(() => importer.Import(testFilePath));
        }
    }
}
