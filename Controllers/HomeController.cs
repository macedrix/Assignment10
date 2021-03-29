using Assignment10.Models;
using Assignment10.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //Set the context
        private BowlingLeagueContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(long? teamid, string teamname, int pageNum = 1)
        {
            //How many items on the page?
            int pageSize = 5;

            //Set the ViewModel properties
            return View(new IndexViewModel
            {
                //Only select the Bowlers for that team selected
                Bowlers = _context.Bowlers
                .Where(t => t.TeamId == teamid || teamid == null)
                .OrderBy(b => b.BowlerFirstName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList(),

                pageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,

                    //get full count only if a team hasn't been selected, otherwise, only get them for that team
                    TotalNumItems = (teamid == null ? _context.Bowlers.Count() : _context.Bowlers.Where(t => t.TeamId == teamid).Count())
                },

                TeamName = teamname
            }) ;
           
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
