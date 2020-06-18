using System;
using System.Collections.Generic;

namespace Test2.Entities
{
    public partial class Championship
    {
        public Championship()
        {
            ChampionshipTeam = new HashSet<ChampionshipTeam>();
        }

        public int IdChampionship { get; set; }
        public string OfficialName { get; set; }
        public int Year { get; set; }

        public virtual ICollection<ChampionshipTeam> ChampionshipTeam { get; set; }
    }
}
