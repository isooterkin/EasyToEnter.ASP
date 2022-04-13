using EasyToEnter.ASP.Dependence;
using EasyToEnter.EntityFrameworkCore.Services.Interface;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using EasyToEnter.ASP.Data;

namespace EasyToEnter.EntityFrameworkCore.Services.Class
{
    public class DataService<T> : IDataService<T> where T : ModelWithId
    {
        private readonly EasyToEnterDbContext _contextFactory;

        public DataService(EasyToEnterDbContext contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // Создать запись
        public async Task<T> Create(T entity)
        {
            using EasyToEnterDbContext context = _contextFactory;
            EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return createdResult.Entity;
        }

        // Удалить запись по id
        public async Task<bool> Delete(int id)
        {
            using EasyToEnterDbContext context = _contextFactory;
            T? entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null) return false;
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        // Удалить запись по id
        public async Task<bool> Delete(int[] ids)
        {
            using EasyToEnterDbContext context = _contextFactory;
            IEnumerable<T> entitys = await context.Set<T>().Where(e => ids.Contains(e.Id)).ToListAsync();
            if (!entitys.Any()) return false;
            context.Set<T>().RemoveRange(entitys);
            await context.SaveChangesAsync();
            return true;
        }

        // Получить все записи
        public async Task<List<T>> GetAll()
        {
            using EasyToEnterDbContext context = _contextFactory;
            List<T> entity = await context.Set<T>().ToListAsync();
            return entity;
        }

        // Получить все записи по id
        public async Task<T?> GetForId(int id)
        {
            using EasyToEnterDbContext context = _contextFactory;
            T? entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        // Получить все записи по id
        public async Task<List<T>> GetForId(int[] ids)
        {
            using EasyToEnterDbContext context = _contextFactory;
            List<T> entitys = await context.Set<T>().Where(e => ids.Contains(e.Id)).ToListAsync();
            return entitys;
        }

        // Обновить запись
        public async Task<T?> Update(T entity)
        {
            using EasyToEnterDbContext context = _contextFactory;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}