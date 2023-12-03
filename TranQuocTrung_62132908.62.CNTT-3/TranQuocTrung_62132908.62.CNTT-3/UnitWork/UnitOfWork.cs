using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TranQuocTrung_62132908._62.CNTT_3.Repository;

namespace TranQuocTrung_62132908._62.CNTT_3.UnitWork
{
    public class UnitOfWork<T> : IUnitOfWork<T>, IDisposable
         where T : DbContext, new()
    {
        private bool _disposed = false;
        private readonly T _context;
        private IDbContextTransaction? _objTran;
        private Dictionary<string, object> _repositories = new Dictionary<string, object>();
        readonly object _object = new object();
        public UnitOfWork(T context)
        {
            _context = context;
        }

        public Dictionary<string, object> Repositories { get; set; }
        //The Dispose() method is used to free unmanaged resources like files, 
        //database connections etc. at any time.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public T Context
        {
            get { return _context; }
        }
        //This CreateTransaction() method will create a database Trnasaction so that we can do database operations by
        //applying do evrything and do nothing principle
        public void CreateTransaction()
        {
            _objTran = _context.Database.BeginTransaction();
        }
        //If all the Transactions are completed successfuly then we need to call this Commit() 
        //method to Save the changes permanently in the database
        public void Commit()
        {
            _objTran!.Commit();
        }
        //If atleast one of the Transaction is Failed then we need to call this Rollback() 
        //method to Rollback the database changes to its previous state
        public void Rollback()
        {
            _objTran!.Rollback();
            _objTran.Dispose();
        }
        //This Save() Method Implement DbContext Class SaveChanges method so whenever we do a transaction we need to
        //call this Save() method so that it will make the changes in the database
        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException dbEx)
            {
                throw dbEx;
            }
            catch
            {
                throw;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }

        public R CreateInstancesRepository<R, E>() where R : BaseRepository<E> where E : class
        {
            var type = typeof(E).Name;
            lock (_object) 
            {
                if (!_repositories.ContainsKey(type))
                {
                    // create new instance of repository, ex: Repository<Contact>
                    try
                    {
                        var repositoryInstance = Activator.CreateInstance(typeof(R), _context); //  new ();
                        _repositories.Add(type, repositoryInstance!);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            return (R)_repositories[type];
        }

        public void AddRepository<R, E>(R repo)
            where R : BaseRepository<E>
            where E : class
        {
            var type = typeof(E).Name;
            lock (_object)
            {
                if (!_repositories.ContainsKey(type))
                {
                    // create new instance of repository, ex: Repository<Contact>
                    try
                    {
                        _repositories.Add(type, repo);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }
    }
}
