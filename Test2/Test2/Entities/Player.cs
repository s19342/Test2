using System;
using System.Collections.Generic;

namespace Test2.Entities
{
    public partial class Player
    {
        public Player()
        {
            PlayerTeam = new HashSet<PlayerTeam>();
        }

        public int IdPlayer { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<PlayerTeam> PlayerTeam { get; set; }
    }
}
