using System;
namespace DataAccess.Response
{

    /// <summary>
    /// DTO for response
    /// </summary>
    /// <remarks>Autor: Eleazar Martinez</remarks>
    public class ResponseDto
    {
        /// <summary>
        /// Response's Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Indicate if the result was successed or failed
        /// </summary>
        public bool Success { get; set; }
    }
}
