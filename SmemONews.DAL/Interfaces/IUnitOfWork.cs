using SmemONews.DAL.Entity;

namespace SmemONews.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<User> User { get; }
        public IRepository<Heading> Heading { get; }
        public IRepository<Tag> Tag { get; }
        public IRepository<News> News { get; }
        public IRepository<Comment> Comment{ get; }
        public IRepository<Role> Role { get; }
        public IRepository<TagsInNews> TagsInNews { get; }
        void Save();
        void Dispose();
    }
}
