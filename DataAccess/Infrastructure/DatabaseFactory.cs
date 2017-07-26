using System;

namespace DataAccess.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private BookmarkContext _context;
        public BookmarkContext Context => _context ?? (_context = new BookmarkContext());
    }

    public interface IDatabaseFactory: IDisposable
    {
        BookmarkContext Context { get; }
    }
}