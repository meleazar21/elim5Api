using System;
using System.Linq;
using Business;
using DataAccess;
using Elim5Api.Constants;
using Elim5Api.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Elim5Api.Controllers
{
    /// <summary>
    /// Controller for the entity
    /// UserLog
    /// </summary>
    /// <remarks>Autor: Eleazar Martinez</remarks>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserLogController : ControllerBase
    {

        private readonly AppSettings _appSettings;

        /// <summary>
        /// Constructor for the controller
        /// </summary>
        /// <param name="appSettings">AppSettings</param>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        public UserLogController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Method to get the metrics for the dashboard
        /// </summary>
        /// <param name="username">username of the user</param>
        /// <returns>response that contains the metrics</returns>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        [HttpGet("SaveUser")]
        [AllowAnonymous]
        public IActionResult SaveUser(string username)
        {
            UserLogBusiness business = new UserLogBusiness(new EfContext());
            var response = business.SaveUserInfo(username);
            return Ok(response);
        }

        /// <summary>
        /// Method to get the metrics for the dashboard
        /// </summary>
        /// <param name="username">username of the user</param>
        /// <returns>response that contains the metrics</returns>
        /// <remarks>Autor: Eleazar Martinez</remarks>
        [HttpGet("GetMetrics")]
        [AllowAnonymous]
        public IActionResult GetMetrics()
        {
            GoogleAnalyticsAPI googleApi = new GoogleAnalyticsAPI(_appSettings.privateKey, _appSettings.googleEmailApi);
            var metrics = new string[] { "ga:totalEvents", };
            var dimensions = new string[] { "ga:eventCategory", "ga:eventAction", "ga:eventLabel" };
            var data = googleApi.GetAnalyticsData(ConfigConstants.ViewId, dimensions, metrics, DateTime.Now.Date.AddDays((int)Enums.DaysToQueryEnum.fifteen), DateTime.Now.Date );
            return Ok(data);
        }

    }
}
