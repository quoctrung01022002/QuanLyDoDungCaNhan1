
using Microsoft.EntityFrameworkCore;
using TranQuocTrung_62132908._62.CNTT_3.Repository;


namespace TranQuocTrung_62132908._62.CNTT_3.UnitWork
{
    public interface IUnitOfWork<out T> where T : DbContext, new()
    {
        T Context { get; }
        R CreateInstancesRepository<R, E>() where R : BaseRepository<E> where E : class;
        void CreateTransaction();
        void Commit();
        void Rollback();
        void AddRepository<R, E>(R repo) where R : BaseRepository<E> where E : class;
        Dictionary<string, object> Repositories { get; set; }
        Task SaveChangesAsync();
    }
}
