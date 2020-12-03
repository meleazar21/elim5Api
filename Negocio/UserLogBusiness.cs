using System;
using DataAccess;
using DataAccess.EFCore.Repositories;
using DataAccess.Response;
using Domain.Entities;
using Domain.Interfaces;

namespace Business
{
    /// <summary>
    /// Business logic for the UserLog Entity
    /// </summary>
    /// <remarks>Autor: Eleazar Martinez</remarks>
    public class UserLogBusiness
    {
        /// <summary>
        /// Repository for userLog
        /// </summary>
        private IUserLogRepository userLogRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        public UserLogBusiness(EfContext db)
        {
            userLogRepository = new UserLogRepository(db);
        }

        /// <summary>
        /// Method to save the user
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>boolean value indicating if the save was successfully</returns>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        public ResponseDto SaveUserInfo(string username)
        {
            var response = new ResponseDto();
            try
            {
                UserLog log = new UserLog();
                log.username = username;
                log.user_date = DateTime.Now;

                userLogRepository.Add(log);
                userLogRepository.Save();

                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error: {ex.Message}";
            }
            return response;
        }
    }
}
