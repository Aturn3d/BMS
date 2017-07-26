using DataAccess.Infrastructure;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class BookmarkRepository : RepositoryBase<Bookmark>, IBookmarkRepository
    {
        public BookmarkRepository(IDatabaseFactory factory) : base(factory)
        {
        }
    }

    public interface IBookmarkRepository: IRepository<Bookmark> { }
}
