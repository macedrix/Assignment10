using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Models.ViewModels
{
    public class IndexViewModel
    {
        //All properties we need in the Index View
        public List<Bowler> Bowlers {get; set;}
        public PageNumberingInfo pageNumberingInfo { get; set; }
        public string TeamName { get; set; }
    }
}
