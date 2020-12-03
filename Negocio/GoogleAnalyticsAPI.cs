using System;
using System.Collections.Generic;
using System.Text;
using Google.Apis.Analytics.v3;
using Google.Apis.Analytics.v3.Data;
using Google.Apis.Services;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Auth.OAuth2;
using System.Collections.Generic;
using System.Linq;
using Business.Classes;
using DataAccess.Response;
using DataAccess.Dto.Response;
using DataAccess.Dto;

namespace Business
{
    /// <summary>
    /// Api for Google analytics
    /// </summary>
    /// <remarks>Autor: Eleazar Martinez</remarks>
    public class GoogleAnalyticsAPI
    {
        /// <summary>
        /// Service
        /// </summary>
        public AnalyticsService Service { get; set; }

        /// <summary>
        /// Google Analitic API
        /// </summary>
        /// <param name="keyPath">keypath </param>
        /// <param name="accountEmailAddress">account emailAddress</param>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        public GoogleAnalyticsAPI(string privateKey, string accountEmailAddress)
        {
            var credentials = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(accountEmailAddress)
               {
                   Scopes = new[] { AnalyticsService.Scope.AnalyticsReadonly }
               }.FromPrivateKey(privateKey));

            Service = new AnalyticsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
            });
        }

        /// <summary>
        /// Method to get the analytic data
        /// </summary>
        /// <param name="profileId"></param>
        /// <param name="dimensions">profile Id</param>
        /// <param name="metrics">metrics</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <returns>Analytic Data Point</returns>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        public ChartResponseDto GetAnalyticsData(string profileId, string[] dimensions, string[] metrics, DateTime startDate, DateTime endDate)
        {
            var responseDto = new ChartResponseDto();
            try
            {
                AnalyticDataPoint data = new AnalyticDataPoint();

                if (!profileId.Contains("ga:")) profileId = string.Format("ga:{0}", profileId);

                //Make initial call to service.
                //Then check if a next link exists in the response,
                //if so parse and call again using start index param.
                GaData response = null;
                do
                {
                    int startIndex = 1;
                    if (response != null && !string.IsNullOrEmpty(response.NextLink))
                    {
                        Uri uri = new Uri(response.NextLink);
                        var paramerters = uri.Query.Split('&');
                        string s = paramerters.First(i => i.Contains("start-index")).Split('=')[1];
                        startIndex = int.Parse(s);
                    }

                    var request = BuildAnalyticRequest(profileId, dimensions, metrics, startDate, endDate, startIndex);
                    response = request.Execute();
                    data.ColumnHeaders = response.ColumnHeaders;
                    if (response.Rows != null) data.Rows.AddRange(response.Rows);

                } while (!string.IsNullOrEmpty(response.NextLink));

                ConvertToChartResponse(response, responseDto);
                responseDto.Success = true;

            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                responseDto.Message = ex.Message;
            }

            return responseDto;
        }

        /// <summary>
        /// Method to convert the data of the google api
        /// to a chart
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="response">response</param>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        private void ConvertToChartResponse(GaData data, ChartResponseDto response)
        {
            ChartDto chart = new ChartDto();

            DatasetsDto dataSet = new DatasetsDto();
            dataSet.Label = "Top Users Search";

            dataSet.BackgroundColor.Add("rgba(255, 99, 132, 0.6)");
            dataSet.BackgroundColor.Add("rgba(54, 162, 235, 0.6)");
            dataSet.BackgroundColor.Add("rgba(255, 206, 86, 0.6)");

            foreach (var row in data.Rows)
            {
                chart.Labels.Add(row[2]);
                dataSet.Data.Add(Convert.ToInt32(row[3]));
            }
            chart.Datasets.Add(dataSet);

            response.Data = chart;
        }

        /// <summary>
        /// Method to build Analytic Request
        /// </summary>
        /// <param name="profileId">profile id</param>
        /// <param name="dimensions">dimension</param>
        /// <param name="metrics">metrcis</param>
        /// <param name="startDate">stardate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="startIndex">startIndex</param>
        /// <returns>BuildAnalyticRequest</returns>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        private DataResource.GaResource.GetRequest BuildAnalyticRequest(string profileId, string[] dimensions, string[] metrics,
                                                                          DateTime startDate, DateTime endDate, int startIndex)
        {
            DataResource.GaResource.GetRequest request = Service.Data.Ga.Get(profileId, startDate.ToString("yyyy-MM-dd"),
                                                                                endDate.ToString("yyyy-MM-dd"), string.Join(",", metrics));
            request.Dimensions = string.Join(",", dimensions);
            request.StartIndex = startIndex;
            return request;
        }

        /// <summary>
        /// GetAvailable profile
        /// </summary>
        /// <returns>List of profiles</returns>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        public IList<Profile> GetAvailableProfiles()
        {
            var response = Service.Management.Profiles.List("~all", "~all").Execute();
            return response.Items;
        }

    }
}
