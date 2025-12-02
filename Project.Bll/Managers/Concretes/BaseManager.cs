using AutoMapper;
using Project.Bll.Dtos;
using Project.Bll.ErrorHandling;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    public abstract class BaseManager<T, U> : IManager<T, U>
        where T : class, IDto
        where U : BaseEntity
    {
        private readonly IRepository<U> _repository;
        protected readonly IMapper _mapper;
        protected readonly IErrorHandler _errorHandler;
        protected BaseManager(IRepository<U> repository, IMapper mapper, IErrorHandler errorHandler)
        {
            _repository = repository;
            _mapper = mapper;
            _errorHandler = errorHandler;
        }

        protected async Task<TOut> SafeExecuteAsync<TOut>(Func<Task<TOut>> action)
            => await _errorHandler.ExecuteAsync(action);

        protected async Task SafeExecuteAsync(Func<Task> action)
            => await _errorHandler.ExecuteAsync(action);

        protected TOut SafeExecute<TOut>(Func<TOut> action)
            => _errorHandler.Execute(action);

        protected void SafeExecute(Action action)
            => _errorHandler.Execute(action);


        public async Task CreateAsync(T entity)
        {
            await _errorHandler.ExecuteAsync(async () =>
            {
                if (entity == null)
                    throw new Exception("Gönderilen model boş olamaz.");

                U domainEntity = _mapper.Map<U>(entity);

                domainEntity.CreatedDate = DateTime.Now;
                domainEntity.Status = DataStatus.Inserted;

                await _repository.CreateAsync(domainEntity);
            });
        }


        public async Task<List<T>> GetAllAsync()
        {
            return await _errorHandler.ExecuteAsync(async () =>
            {
                List<U> values = await _repository.GetAllAsync();

                if (values == null || values.Count == 0)
                    throw new Exception("Hiç kayıt bulunamadı.");

                return _mapper.Map<List<T>>(values);
            });
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _errorHandler.ExecuteAsync(async () =>
            {
                if (id <= 0)
                    throw new Exception("ID sıfırdan büyük olmalıdır.");

                U value = await _repository.GetByIdAsync(id);

                if (value == null)
                    throw new Exception($"{id} numaralı kayıt bulunamadı.");

                return _mapper.Map<T>(value);
            });
        }


        public List<T> GetActives()
        {
            return _errorHandler.Execute(() =>
            {
                var values = _repository.Where(x => x.Status != DataStatus.Deleted).ToList();
                return _mapper.Map<List<T>>(values);
            });
        }


        public List<T> GetPassives()
        {
            return _errorHandler.Execute(() =>
            {
                var values = _repository.Where(x => x.Status == DataStatus.Deleted).ToList();
                return _mapper.Map<List<T>>(values);
            });
        }


        public List<T> GetUpdateds()
        {
            return _errorHandler.Execute(() =>
            {
                var values = _repository.Where(x => x.Status == DataStatus.Updated).ToList();
                return _mapper.Map<List<T>>(values);
            });
        }


        public async Task<string> SoftDeleteAsync(int id)
        {
            return await _errorHandler.ExecuteAsync(async () =>
            {
                if (id <= 0)
                    throw new Exception("ID sıfırdan büyük olmalıdır.");

                U originalValue = await _repository.GetByIdAsync(id);

                if (originalValue == null)
                    throw new Exception($"{id} ID'li veri bulunamadı.");

                if (originalValue.Status == DataStatus.Deleted)
                    throw new Exception($"{id} ID'li veri zaten pasif.");

                originalValue.Status = DataStatus.Deleted;
                originalValue.DeletedDate = DateTime.Now;

                await _repository.SaveChangesAsync();

                return $"{id} ID'li veri pasife çekildi.";
            });
        }


        public async Task<string> HardDeleteAsync(int id)
        {
            return await _errorHandler.ExecuteAsync(async () =>
            {
                if (id <= 0)
                    throw new Exception("ID sıfırdan büyük olmalıdır.");

                U originalValue = await _repository.GetByIdAsync(id);

                if (originalValue == null)
                    throw new Exception($"{id} ID'li veri bulunamadı.");

                if (originalValue.Status != DataStatus.Deleted)
                    throw new Exception("Sadece pasif veriler tamamen silinebilir.");

                await _repository.DeleteAsync(originalValue);

                return $"{id} ID'li veri tamamen silindi.";
            });
        }

        public async Task UpdateAsync(T entity)
        {
            await _errorHandler.ExecuteAsync(async () =>
            {
                if (entity == null)
                    throw new Exception("Gönderilen model boş olamaz.");

                U originalValue = await _repository.GetByIdAsync(entity.Id);

                if (originalValue == null)
                    throw new Exception($"{entity.Id} ID'li veri bulunamadı.");

                U newValue = _mapper.Map<U>(entity);
                newValue.UpdatedDate = DateTime.Now;
                newValue.Status = DataStatus.Updated;

                await _repository.UpdateAsync(originalValue, newValue);
            });
        }

    }
}
