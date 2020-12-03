using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    /// <summary>
    /// User class
    /// </summary>
    /// <remarks>Autor: Eleazar Martinez</remarks>
    public class UserLog
    {
        /// <summary>
        /// Primary key of the record
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// username
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// Date of user login
        /// </summary>
        public DateTime user_date { get; set; }
    }
}
