using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Covid.Business
{
    public class CovidAPIHelper
    {
        private string AllStateInfoURL = @"https://covidtracking.com/api/v1/states/info.json";
        private string IndividualStateDataURL = @"https://covidtracking.com/api/v1/states/{0}/daily.json";
        public dynamic GetAllStateInfo()
        {
            WebClient webClient = new WebClient();
            var result = webClient.DownloadString(AllStateInfoURL);
            dynamic parsedJson = JsonConvert.DeserializeObject(result);
            return parsedJson;
        }

        public dynamic RetrieveAStatesData(string stateAbbreviation)
        {
            WebClient webClient = new WebClient();

            //Console.WriteLine("Getting Individual State Data 1 {0}", stateAbbreviation);

            var theURL = string.Format(IndividualStateDataURL, stateAbbreviation);

            //Console.WriteLine(theURL);

            var result = webClient.DownloadString(theURL);

            //Console.WriteLine("Getting Individual State Data 2 {0}", stateAbbreviation);

            dynamic parsedJson = JsonConvert.DeserializeObject(result);

            //Console.WriteLine("Getting Individual State Data 3 {0}", stateAbbreviation);

            return parsedJson;
        }

        public List<Model.StatesData> CompileStatesData()
        {
            List<Model.StatesData> result = new List<Model.StatesData>();
            dynamic allStateInfo = GetAllStateInfo();
            for (var i = 0; i < allStateInfo.Count; i++)
            {
                IEnumerable<dynamic> dataForCurrentState = RetrieveAStatesData(allStateInfo[i].state.ToString().ToLower());
                List<DateTime?> dates = new List<DateTime?>();
                List<double?> cases = new List<double?>();
                List<double?> newCases = new List<double?>();
                List<double?> deaths = new List<double?>();
                List<double?> newDeaths = new List<double?>();
                List<DaysData> allDaysData = new List<DaysData>();

                foreach (var dateData in dataForCurrentState)
                {
                    string currentDate = dateData.date.ToString();
                    string formattedDate = string.Format("{0}-{1}-{2}", currentDate.Substring(0, 4)
                                                                      , currentDate.Substring(4, 2)
                                                                      , currentDate.Substring(6, 2));
                    DaysData dataForTheCurrentDate = new DaysData();

                    var currentParsedDate = DateTime.Parse(formattedDate);

                    dates.Add(currentParsedDate);

                    dataForTheCurrentDate.TheDate = currentParsedDate;
                    var v1 = dateData.positiveCasesViral.ToString();

                    if (string.IsNullOrWhiteSpace(v1))
                    {
                        v1 = dateData.positive.ToString();
                    }

                    var v2 = dateData.positiveIncrease.ToString();
                    var v3 = dateData.death.ToString();
                    var v4 = dateData.deathIncrease.ToString();

                    if (string.IsNullOrWhiteSpace(v1))
                    {
                        cases.Add(null);

                        dataForTheCurrentDate.TotalCases = null;
                    }
                    else
                    {
                        cases.Add(double.Parse(v1));

                        dataForTheCurrentDate.TotalCases = double.Parse(v1);
                    }

                    if (string.IsNullOrWhiteSpace(v2))
                    {
                        newCases.Add(null);

                        dataForTheCurrentDate.NewCases = null;
                    }
                    else
                    {

                        newCases.Add(double.Parse(v2));

                        dataForTheCurrentDate.NewCases = double.Parse(v2);
                    }

                    if (string.IsNullOrWhiteSpace(v3))
                    {
                        deaths.Add(null);

                        dataForTheCurrentDate.TotalDeaths = null;
                    }
                    else
                    {
                        deaths.Add(double.Parse(v3));

                        dataForTheCurrentDate.TotalDeaths = double.Parse(v3);
                    }

                    if (string.IsNullOrWhiteSpace(v4))
                    {
                        newDeaths.Add(null);

                        dataForTheCurrentDate.NewDeaths = null;
                    }
                    else
                    {
                        newDeaths.Add(double.Parse(v4));

                        dataForTheCurrentDate.NewDeaths = double.Parse(v4);
                    }

                    allDaysData.Add(dataForTheCurrentDate);
                }  
                
                Model.StatesData currentStateData = new Model.StatesData()
                {
                    StateAbbreviation = allStateInfo[i].state,
                    StateName = allStateInfo[i].name,
                    AllDaysData = allDaysData,
                    Dates = dates.ToArray(),
                    MostRecentNewCases = newCases.Where(t => t.HasValue).First(),
                    MostRecentTotalCases = cases.Where(t => t.HasValue).First(),
                    MostRecentNewDeaths = newDeaths.Where(t => t.HasValue).First(),
                    MostRecentTotalDeaths = deaths.Where(t => t.HasValue).First(),
                };

                result.Add(currentStateData);
            }
            return result;
        }
    }
}
