using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Dto
{
    /// <summary>
    /// Datasets DTO
    /// </summary>
    /// <remarks>Autor: Eleazar Martinez</remarks>
    public class DatasetsDto
    {
     
        /// <summary>
        /// Labels
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Data of the records
        /// </summary>
        public List<int> Data { get; set; }

        /// <summary>
        /// Color for the bars
        /// </summary>
        public List<string> BackgroundColor { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        public DatasetsDto() 
        {
            Data = new List<int>();
            BackgroundColor = new List<string>();
        }
    }
}
