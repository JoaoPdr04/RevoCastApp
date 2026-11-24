using RevoCastApp.Domain.Base;

namespace RevoCastApp.Repository.Base
{
    public interface IBaseRepository<TEntity> where TEntity : IBaseEntity
    {
        //Métodos CRUD
        // Limpa entidades rastreadas na memória para evitar conflito de mesmo Id no WinForms
        void CleanChangeTracker();
        // Anexa um objeto relacionado (ex: Episodio vindo de um ComboBox) para o EF não tentar inseri-lo novamente
        void AttachObject(object obj);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(object id);
        // Retorna todos os registros da tabela, fazendo JOIN com as propriedades informadas em 'includes'
        IList<TEntity> Select(IList<string>? includes = null);
        // Retorna o registro pelo Id, fazendo JOIN com as propriedades informadas em 'includes'
        TEntity? Select(object id, IList<string>? includes = null);
    }
}