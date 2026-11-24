using FluentValidation;
using RevoCastApp.Domain.Base;

namespace RevoCastApp.Service.Base
{
    public interface IBaseService<TEntity> where TEntity : IBaseEntity
    {
        void AttachObject(object obj);
        TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        void Delete(int id);
        IList<TEntity> Get(IList<string>? includes = null);
        TEntity? GetById(int id, IList<string>? includes = null);
        TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    }
}