using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    /// <summary>
    /// Interface for the generic
    /// Respository
    /// </summary>
    /// <remarks>Autor: Eleazar Martinez</remarks>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Get the entity by id
        /// </summary>
        /// <param name="id">id of the entity to return</param>
        /// <returns>Entity</returns>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        T GetById(int id);

        /// <summary>
        /// Get all the entities in the table
        /// </summary>
        /// <returns>all the entities</returns>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Method to find or filter an entity by
        /// a filter or expresion
        /// </summary>
        /// <param name="expression">expresion</param>
        /// <returns>entity or entities that matches the expresion</returns>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Method to add an entity to the table
        /// </summary>
        /// <param name="entity">entity to insert</param>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        void Add(T entity);

        /// <summary>
        /// Method to insert a range of entities
        /// </summary>
        /// <param name="entities">Entities to insert</param>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Method to remove an specific entity
        /// </summary>
        /// <param name="entity">Entity to be removed</param>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        void Remove(T entity);

        /// <summary>
        /// Method to remove a range of entities
        /// </summary>
        /// <param name="entities">entities to remove</param>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        void RemoveRange(IEnumerable<T> entities);

        /// <summary>
        /// Method for commit the changes
        /// </summary>
        /// <remarks>Author: Eleazar Martinez</remarks>
        void Save();
    }
}
