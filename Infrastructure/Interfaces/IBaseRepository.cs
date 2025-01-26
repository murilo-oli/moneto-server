using System;
using System.Linq.Expressions;
using Domain.Entities;

public interface IBaseRepository<T> where T : Base
{
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task<T> Remove(T entity);
    Task<T?> Get(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>> GetAll();
}