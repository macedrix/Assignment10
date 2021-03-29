using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment10
{
    public partial class MatchGame
    {
        public long MatchId { get; set; }
        public long GameNumber { get; set; }
        public long? WinningTeamId { get; set; }

        public virtual TourneyMatch Match { get; set; }
    }
}
