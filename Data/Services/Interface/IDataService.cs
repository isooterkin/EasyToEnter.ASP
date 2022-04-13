namespace EasyToEnter.EntityFrameworkCore.Services.Interface
{
    public interface IDataService<T>
    {
        // Получить все записи
        Task<List<T>> GetAll();

        // Получить все записи по id
        Task<T?> GetForId(int id);

        // Получить все записи по id
        Task<List<T>> GetForId(int[] ids);

        // Создать запись
        Task<T> Create(T entity);

        // Обновить запись
        Task<T?> Update(T entity);

        // Удалить запись по id
        Task<bool> Delete(int id);

        // Удалить запись по id
        Task<bool> Delete(int[] ids);
    }
}