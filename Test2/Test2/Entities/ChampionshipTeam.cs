using System;
using System.Collections.Generic;

namespace Test2.Entities
{
    public partial class ChampionshipTeam
    {
        public int IdChampionship { get; set; }
        public int IdTeam { get; set; }
        public float Score { get; set; }

        public virtual Championship IdChampionshipNavigation { get; set; }
        public virtual Team IdTeamNavigation { get; set; }
    }
}
