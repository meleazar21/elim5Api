using DataAccess.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Dto.Response
{
    /// <summary>
    /// Response for the chart
    /// </summary>
    /// <remarks>Autor: Eleazar Martinez</remarks>
    public class ChartResponseDto : ResponseDto
    {
        /// <summary>
        /// Data for the chart
        /// </summary>
        public ChartDto Data { get; set; }
    }
}
