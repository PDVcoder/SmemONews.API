using Microsoft.EntityFrameworkCore;
using SmemONews.DAL.EF;
using SmemONews.DAL.Entity;
using SmemONews.DAL.Interfaces;
using System;

namespace SmemONews.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;
        private DataContext _context;
        private Repository<User> _userRepository;
        private Repository<Role> _roleRepository;
        private Repository<Heading> _headingRepository;
        private Repository<News> _newsRepository;
        private Repository<Comment> _commentRepository;
        private Repository<Tag> _tagRepository;
        private Repository<TagsInNews> _tagsInNewsRepository;

        public EFUnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IRepository<User> User
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new Repository<User>(_context);
                }
                return _userRepository;
            }
        }

        public IRepository<Heading> Heading
        {
            get
            {
                if (_headingRepository == null)
                {
                    _headingRepository = new Repository<Heading>(_context);
                }
                return _headingRepository;
            }
        }

        public IRepository<Tag> Tag
        {
            get
            {
                if (_tagRepository == null)
                {
                    _tagRepository = new Repository<Tag>(_context);
                }
                return _tagRepository;
            }
        }

        public IRepository<News> News
        {
            get
            {
                if(_newsRepository == null)
                {
                    _newsRepository = new Repository<News>(_context);
                }
                return _newsRepository;
            }
        }

        public IRepository<Comment> Comment
        {
            get
            {
                if(_commentRepository == null)
                {
                    _commentRepository = new Repository<Comment>(_context);
                }
                return _commentRepository;
            }
        }

        public IRepository<Role> Role
        {
            get
            {
                if(_roleRepository == null)
                {
                    _roleRepository = new Repository<Role>(_context);
                }
                return _roleRepository;
            }
        }

        public IRepository<TagsInNews> TagsInNews
        {
            get
            {
                if(_tagsInNewsRepository == null)
                {
                    _tagsInNewsRepository = new Repository<TagsInNews>(_context);
                }
                return _tagsInNewsRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
