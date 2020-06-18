using Forma1.Data;
using Forma1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Forma1.Services
{
    public class TeamService : ITeamService
    {
        Context context;

        public TeamService(Context context)
        {
            this.context = context;
        }

        public void Add(Team team)
        {
            if (team is null)
            {
                throw new ArgumentNullException(nameof(Add));
            }

            context.Teams.Add(team);
            context.SaveChanges();
        }

        public IEnumerable<Team> GetAll()
        {
            return context.Teams.ToList();
        }

        public Team GetById(int id)
        {
            var team = context.Teams.Where(t => t.Id.Equals(id)).SingleOrDefault();
            return team;
        }

        public void RemoveById(int id)
        {
            var team = GetById(id);
            context.Teams.Remove(team);
            context.SaveChanges();
        }

        public void Update(Team team)
        {
            var oldTeam = GetById(team.Id);
            oldTeam = team;
            context.SaveChanges();
        }
    }
}
