using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Interfaces;

namespace DataAccess.EFCore.Repositories
{
    /// <summary>
    /// Generic repository
    /// </summary>
    /// <remarks>Autor: Eleazar Martinez</remarks>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly EfContext _db;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="db">context</param>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        public GenericRepository(EfContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Method to add an entity to the table
        /// </summary>
        /// <param name="entity">entity to insert</param>
        /// <remarks>Autor: Eleazar Martinez</remarks>tity to the table
        /// </summary>
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        /// <summary>
        /// Method to insert a range of entities
        /// </summary>
        /// <param name="entities">Entities to insert</param>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        public void AddRange(IEnumerable<T> entities)
        {
            _db.Set<T>().AddRange(entities);
        }

        /// <summary>
        /// Method to find or filter an entity by
        /// a filter or expresion
        /// </summary>
        /// <param name="expression">expresion</param>
        /// <returns>entity or entities that matches the expr
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().Where(expression);
        }

        /// <summary>
        /// Get all the entities in the table
        /// </summary>
        /// <returns>all the entities</returns>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        /// <summary>
        /// Get the entity by id
        /// </summary>
        /// <param name="id">id of the entity to return</param>
        /// <returns>Entity</returns>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        public T GetById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        /// <summary>
        /// Method to remove an specific entity
        /// </summary>
        /// <param name="entity">Entity to be removed</param>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        public void Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Method to remove a range of entities
        /// </summary>
        /// <param name="entities">entities to remove</param>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        public void RemoveRange(IEnumerable<T> entities)
        {
            _db.Set<T>().RemoveRange(entities);
        }

        /// <summary>
        /// Method for commit all the save
        /// in the repository
        /// </summary>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
