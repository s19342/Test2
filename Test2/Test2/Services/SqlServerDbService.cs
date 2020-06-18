using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test2.DTOs.Requests;
using Test2.DTOs.Responses;
using Test2.Entities;

namespace Test2.Services
{
    public class SqlServerDbService :IDbService
    {
        
        private readonly TeamContext _dbContext;

        public SqlServerDbService(TeamContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddplayerToTeam(int id, PlayerRequest pr)
        {
            int birthyear = pr.birthDate.Year;
            var maxAge = _dbContext.Team.Where(e => e.IdTeam == id).Select(f => f.MaxAge).FirstOrDefault();
            int currentYear = DateTime.Today.Year;
            int age = birthyear - currentYear;

            if((currentYear - birthyear) > maxAge)
            {
                return 0;
            }

            var playerExists = _dbContext.Player.Any(p => p.FirstName == pr.firstName && p.Lastname == pr.lastName);
            

            if(!playerExists)
            {
                return 1;
            }

            int playerId = Convert.ToInt32(_dbContext.Player.Where(p => p.FirstName == pr.firstName && p.Lastname == pr.lastName).Select(p => p.IdPlayer));

            var teamAssigned = _dbContext.PlayerTeam.Any(e => e.IdPlayer == playerId);

            if(teamAssigned)
            {
                return 2;
            }

            _dbContext.PlayerTeam.Add(new PlayerTeam
            {
                IdPlayer = playerId,
                IdTeam = id,
                NumOnShirt = pr.numOnShirt,
                Comment = pr.comment
            });

            _dbContext.SaveChanges();

            return 3;
        }

        public List<ChampionshipResponse> GetTeams(int id)
        {
            var findId = _dbContext.Championship.Where(s => s.IdChampionship == id).ToList();

            if(findId.Count == 0)
            {
                return null;
            }

            var temp = _dbContext.ChampionshipTeam.Include(s => s.IdChampionshipNavigation)
                                                    .ThenInclude(f => f.ChampionshipTeam)
                                                    .Where(s => s.IdChampionship == 1)
                                                    .Select(s => new ChampionshipResponse

                                                    {
                                                        Score = s.Score,
                                                        TeamName = s.IdTeamNavigation.TeamName
                                                    }).OrderBy(r => r.Score).ToList();
                                                    



            return temp;
        }
    }
}
