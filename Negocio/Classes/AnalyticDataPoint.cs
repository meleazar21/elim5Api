using Google.Apis.Analytics.v3.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Classes
{
    /// <summary>
    /// Analytic Data point class
    /// </summary>
    /// <remarks>Autor: Eleazar Martinez</remarks>
    public class AnalyticDataPoint
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        public AnalyticDataPoint()
        {
            Rows = new List<IList<string>>();
        }

        /// <summary>
        /// ColumnHeaders
        /// </summary>
        public IList<GaData.ColumnHeadersData> ColumnHeaders { get; set; }

        /// <summary>
        /// Rows
        /// </summary>
        public List<IList<string>> Rows { get; set; }
    }
}
