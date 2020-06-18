using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2.DTOs.Requests;
using Test2.DTOs.Responses;

namespace Test2.Services
{
    public interface IDbService
    {
        public List<ChampionshipResponse> GetTeams(int id);
        public int AddplayerToTeam(int id, PlayerRequest pr);
    }
}
