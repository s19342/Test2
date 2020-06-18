using System;
using System.Collections.Generic;

namespace Test2.Entities
{
    public partial class PlayerTeam
    {
        public int IdPlayer { get; set; }
        public int IdTeam { get; set; }
        public int NumOnShirt { get; set; }
        public string Comment { get; set; }

        public virtual Player IdPlayerNavigation { get; set; }
        public virtual Team IdTeamNavigation { get; set; }
    }
}
