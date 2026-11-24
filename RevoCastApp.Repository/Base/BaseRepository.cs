using Microsoft.EntityFrameworkCore;
using RevoCastApp.Domain.Base;
using RevoCastApp.Repository.Context;

namespace RevoCastApp.Repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MyDBContext _myDbContext;

        public BaseRepository(MyDBContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        // Limpa entidades rastreadas na memória para evitar conflito de mesmo Id no WinForms
        public void CleanChangeTracker()
        {
            _myDbContext.ChangeTracker.Clear();
        }

        // Anexa um objeto relacionado (ex: Episodio vindo de um ComboBox) para o EF não tentar inseri-lo novamente
        public void AttachObject(object obj)
        {
            _myDbContext.Attach(obj);
        }

        // Marca a entidade para inserção e executa o INSERT no PostgreSQL
        public void Insert(TEntity obj)
        {
            _myDbContext.Set<TEntity>().Add(obj);
            _myDbContext.SaveChanges();
        }

        // Marca o estado da entidade como modificado e executa o UPDATE no PostgreSQL
        public void Update(TEntity obj)
        {
            _myDbContext.Entry(obj).State = EntityState.Modified;
            _myDbContext.SaveChanges();
        }

        // Busca o registro pelo Id e executa o DELETE no PostgreSQL
        public void Delete(object id)
        {
            var entity = Select(id);
            if (entity != null)
            {
                _myDbContext.Set<TEntity>().Remove(entity);
                _myDbContext.SaveChanges();
            }
        }

        // Retorna todos os registros da tabela, fazendo JOIN com as propriedades informadas em 'includes'
        public IList<TEntity> Select(IList<string>? includes = null)
        {
            IQueryable<TEntity> dbContext = _myDbContext.Set<TEntity>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    dbContext = dbContext.Include(include);
                }
            }

            return dbContext.ToList();
        }

        // Retorna um único registro pelo Id, também carregando relacionamentos se informados
        public TEntity? Select(object id, IList<string>? includes = null)
        {
            IQueryable<TEntity> dbContext = _myDbContext.Set<TEntity>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    dbContext = dbContext.Include(include);
                }
            }

            return dbContext.FirstOrDefault(x => x.Id == (int)id);
        }
    }
}