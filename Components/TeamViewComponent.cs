using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Components
{
    public class TeamViewComponent : ViewComponent
    {
        //database context
        private BowlingLeagueContext context;
        public TeamViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;   
        }

        //What happens when you call this view component
        public IViewComponentResult Invoke()
        {
            //Set the ViewBag equal to the teamname that was sent in so you can access it in the view
            ViewBag.SelectedTeam = RouteData?.Values["teamname"];
            return View(context.Teams.Distinct().OrderBy(x => x.TeamName));
        }
    }
}
