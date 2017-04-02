using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HappyBuddhaSite.Controllers
{
    public class ChartDataFormat
    {
        public int SprintNumber { get; set; }
        public double MyScore { get; set; }
        public double CompareScore { get; set; }
    }
    
    [Authorize]
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View("ByIndividual");
        }

        public dynamic GetChartDataTeam()
        {
            //dummy data for testing
            var chartData = new List<ChartDataFormat>();
            chartData.Add(new ChartDataFormat() { SprintNumber = 1, MyScore = 7.8, CompareScore = 8.8 });
            chartData.Add(new ChartDataFormat() { SprintNumber = 2, MyScore = 10.9, CompareScore = 11.5 });
            chartData.Add(new ChartDataFormat() { SprintNumber = 3, MyScore = 25.4, CompareScore = 22.4 });
            chartData.Add(new ChartDataFormat() { SprintNumber = 4, MyScore = 4.7, CompareScore = 5.8 });
            chartData.Add(new ChartDataFormat() { SprintNumber = 5, MyScore = 31.9, CompareScore = 26.6 });
            chartData.Add(new ChartDataFormat() { SprintNumber = 6, MyScore = 44.8, CompareScore = 32.6 });

            return chartData;
        }

        public dynamic GetChartDataCompany()
        {
            //dummy data for testing
            var chartData = new List<ChartDataFormat>();
            chartData.Add(new ChartDataFormat() { SprintNumber = 1, MyScore = 7.8, CompareScore = 98.8 });
            chartData.Add(new ChartDataFormat() { SprintNumber = 2, MyScore = 3.9, CompareScore = 51.5 });
            chartData.Add(new ChartDataFormat() { SprintNumber = 3, MyScore = 25.4, CompareScore = 42.4 });
            chartData.Add(new ChartDataFormat() { SprintNumber = 4, MyScore = 6.4, CompareScore = 15.8 });
            chartData.Add(new ChartDataFormat() { SprintNumber = 5, MyScore = 31.9, CompareScore = 26.6 });
            chartData.Add(new ChartDataFormat() { SprintNumber = 6, MyScore = 44.8, CompareScore = 32.6 });

            return chartData;
        }
    }
}
