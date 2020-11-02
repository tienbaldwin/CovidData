using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Covid.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CovidController : ControllerBase
    {

        private readonly ILogger<CovidController> _logger;
        private Covid.Business.CovidAPIHelper _covidAPIHelper;

        public CovidController(ILogger<CovidController> logger)
        {
            _logger = logger;
            _covidAPIHelper = new Business.CovidAPIHelper();
        }

        [HttpGet]
        public List<Business.Model.StatesData> Get()
        {
            //var result = _curveFitHelper.CurveFitToCovidData();
            var result = _covidAPIHelper.CompileStatesData();
            return result;
        }
    }
}
