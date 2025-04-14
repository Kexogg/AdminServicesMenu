using System.Linq.Expressions;
using AdminServicesMenu.Core.Domain;

namespace AdminServicesMenu.Core.Repositories;

/// <summary>
///     Репозиторий сущности
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
public interface IRepository<TEntity> where TEntity : class
{
    /// <summary>
    ///     Получаем кол-во объектов ДЛЯ ЛЕНИ
    /// </summary>
    /// <returns>Кол-во объектов ДЛЯ ЛЕНИ</returns>
    long GetTotalCount();
    
    /// <summary>
    ///     Получение всех сущностей их хранилища
    /// </summary>
    /// <returns>Все сущности в хранилище</returns>
    IQueryable<TEntity> GetAll();

    /// <summary>
    ///     Получаем объект по id
    /// </summary>
    /// <param name="id">ID</param>
    /// <returns>TEntity</returns>
    Task<TEntity?> GetById(string id);

    /// <summary>
    ///     Добавление сущности в хранилище
    /// </summary>
    /// <param name="item">Сущность</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Сущность после добавления</returns>
    Task<TEntity> AddAsync(TEntity item, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Добавление указанных сущностей
    /// </summary>
    /// <param name="entities">Сущности</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task AddAllAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Обновление сущности
    /// </summary>
    /// <param name="item">Сущность</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task<TEntity?> UpdateAsync(TEntity item, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Удаление сущности
    /// </summary>
    /// <param name="itemId">ID Сущности</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task DeleteAsync(string itemId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Удаление указанных сущностей
    /// </summary>
    /// <param name="items">Сущности</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task DeleteAllAsync(IEnumerable<TEntity> items, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Удаление сущностей по условию
    /// </summary>
    /// <param name="predicate">Условие выборки сущностей для удаления</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task DeleteAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}