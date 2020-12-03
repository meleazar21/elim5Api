using DataAccess.Response;
using System.Collections.Generic;

namespace DataAccess.Dto.Response
{
    /// <summary>
    /// Dto for charts
    /// </summary>
    /// <remarks>Autor: Eleazar Martinez</remarks>
    public class ChartDto 
    {
        /// <summary>
        /// Labels for the chart
        /// </summary>
        public List<string> Labels { get; set; }

        /// <summary>
        /// DataSet
        /// </summary>
        public List<DatasetsDto> Datasets { get; set; }

        /// <summary>
        /// Constructor for the DTO
        /// </summary>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        public ChartDto() 
        {
            Labels = new List<string>();
            Datasets = new List<DatasetsDto>();
        }
    }
}
