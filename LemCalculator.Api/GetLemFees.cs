using LemCalculator.Api.utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace LemCalculator.Api
{
    public static class GetLemFees
    {
        [FunctionName("GetLemFees")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]HttpRequest req, ILogger log)
        {
            log.LogInformation("Function has been trigger and the function processed a request.");
            try
            {
                var elmData = new ParseDataFile();
                return new OkObjectResult($"{JsonConvert.SerializeObject(elmData.LoadJson().ToList())}");
            }
            catch (Exception)
            {
                return new BadRequestObjectResult("Something un-expected has happened.");
            }
        }
    }
}