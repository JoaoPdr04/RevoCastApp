using FluentValidation;
using RevoCastApp.Domain.Base;
using RevoCastApp.Repository.Base;

namespace RevoCastApp.Service.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void AttachObject(object obj)
        {
            _baseRepository.AttachObject(obj);
        }

        public TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(obj);
            return obj;
        }

        public void Delete(int id)
        {
            _baseRepository.Delete(id);
        }

        public IList<TEntity> Get(IList<string>? includes = null)
        {
            return _baseRepository.Select(includes);
        }

        public TEntity? GetById(int id, IList<string>? includes = null)
        {
            return _baseRepository.Select(id, includes);
        }

        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(obj);
            return obj;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}