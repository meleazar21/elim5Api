using System;
using Domain.Entities;
using Domain.Interfaces;

namespace DataAccess.EFCore.Repositories
{
    /// <summary>
    /// Repository for the User entity
    /// </summary>
    /// <remarks>Autor: Eleazar Martinez</remarks>
    public class UserLogRepository : GenericRepository<UserLog>, IUserLogRepository
    {
        /// <summary>
        /// Repository constructor
        /// </summary>
        /// <param name="_db">Db Context</param>
        /// <remarks>Auto: Eleazar Martinez</remarks>
        public UserLogRepository(EfContext _db) : base(_db)
        {
        }
    }
}
