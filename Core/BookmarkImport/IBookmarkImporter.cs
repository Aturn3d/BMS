using System.Collections.Generic;
using Core.Domain;

namespace Core.BookmarkImport
{
    public interface IBookmarkImporter
    {
        List<Bookmark> Import(string filePath);
    }
}
