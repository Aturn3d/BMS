using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Core.Domain;
using Core.Extensions;
using HtmlAgilityPack;

namespace Core.BookmarkImport
{
    /// <summary>
    /// Get list of bookmarks from Google Chrome Export files
    /// </summary>
    public class HtmlBookmarkImporter : IBookmarkImporter
    {
        public List<Bookmark> Import(string filePath)
        {
            if (!File.Exists(filePath)) {
                throw new FileNotFoundException(string.Format("Selected file is not existed: {0}", filePath));
            }

            var doc = new HtmlDocument();
            doc.Load(filePath);
            return doc.DocumentNode.Descendants("a").Select(x => MapBookmark(x, doc.DetectEncoding(filePath))).ToList();
        }
        
        private Bookmark MapBookmark(HtmlNode node, Encoding docEncoding)
        {            
            return new Bookmark {
                Title = DecodeTitle(node.InnerText, docEncoding),
                AddedDate = GetDate(node.Attributes["ADD_DATE"].Value),
                Uri = new Uri(node.Attributes["HREF"].Value),
                Icon = node.Attributes["ICON"].Value
            };
        }        

        private DateTime GetDate(string date)
        {
            //Date is formated if UNIX notation(seconds elapsed from January 1st 1970 in UTC coordinates.)
            var ticks = long.Parse(date);
            return DateTimeExtensions.ConvertFromUnixTimestamp(ticks);
        }

        /// <summary>
        /// Chrome exports title into Windows-1251 encoding. So, we need to decode
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        private string DecodeTitle(string title, Encoding sourceEncoding)
        {
            //var initialEncoding = Encoding.GetEncoding("Windows-1251");
            var bytes = sourceEncoding.GetBytes(title);
            return Encoding.UTF8.GetString(bytes);
        }

    }
}
