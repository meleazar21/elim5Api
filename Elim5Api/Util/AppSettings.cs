using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elim5Api.Util
{
    /// <summary>
    /// Class that has retrieve
    /// the configs values from the appsettings
    /// </summary>
    /// <remarks>Autor: Eleazar Martinez</remarks>
    public class AppSettings
    {
        /// <summary>
        /// private key
        /// </summary>
        public string privateKey { get; set; }

        /// <summary>
        /// Email configured from the api analytics
        /// </summary>
        public string googleEmailApi { get; set; }
    }
}
