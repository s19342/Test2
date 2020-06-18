using System;
using System.Collections.Generic;

namespace Test2.Entities
{
    public partial class Team
    {
        public Team()
        {
            ChampionshipTeam = new HashSet<ChampionshipTeam>();
            PlayerTeam = new HashSet<PlayerTeam>();
        }

        public int IdTeam { get; set; }
        public string TeamName { get; set; }
        public int MaxAge { get; set; }

        public virtual ICollection<ChampionshipTeam> ChampionshipTeam { get; set; }
        public virtual ICollection<PlayerTeam> PlayerTeam { get; set; }
    }
}
